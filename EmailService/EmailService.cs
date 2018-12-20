using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

namespace EmailService
{
    public class MailService
    {
        #region Private Variables
        private int[] width = { 100, 305, 100, 100, 213 };
        private string tablestyles = "table-layout:fixed;font-size:10pt;font-family:arial,sans,sans-serif;width:0px;border-collapse:collapse;border:none";
        private string filePath = Environment.CurrentDirectory + "\\EmailConfig.xml";
        private string key = "AAECAwQFBgcICQoLDA0ODw==";
        private EmailConfiguration configuration = null;
        #endregion

        #region Constructor
        public MailService()
        {
            this.configuration = GetConfiguration();
        }
        #endregion

        #region Public Methods
        public bool SaveConfig(EmailConfiguration configuration)
        {
            FileStream file = null;
            try
            {
                configuration.Password = CryptoEngine.Encrypt(configuration.Password, key);
                if (!File.Exists(filePath))
                    file = File.Create(filePath);
                else
                    file = File.OpenWrite(filePath);

                TextWriter textWriter = new StreamWriter(file);
                XmlSerializer ser = new XmlSerializer(typeof(EmailConfiguration));
                ser.Serialize(textWriter, configuration);
                file.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (file != null)
                {
                    file.Close();
                }
            }

        }
        public bool SendMail()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(configuration.From);
                configuration.To.ForEach(s =>
                {
                    mail.To.Add(s);
                });
                if (configuration.CC.Any())
                {
                    configuration.CC.ForEach(s =>
                    {
                        mail.CC.Add(s);
                    });
                }
                if (configuration.BCC.Any())
                {
                    configuration.BCC.ForEach(s =>
                    {
                        mail.Bcc.Add(s);
                    });
                }
                mail.Subject = configuration.Subject.Replace("{date}", DateTime.Now.ToString("dd-MM-yyyy"));
                mail.Body = GetEmailBody();
                mail.IsBodyHtml = true;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(configuration.From, configuration.Password);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }

            return true;
        }
        public EmailConfiguration GetEmailConfiguration()
        {
            return this.configuration;
        }

        public string GetEmailBody()
        {
            string message = "";
            string messageFromsheet = null;
            message = configuration.EmailBody;
            if (configuration.ReadFromGoogleSheet)
            {
                Tuple<List<string>, List<List<string>>> tuple = ReadFromGoogleSheet();
                messageFromsheet = FormatMesssage(tuple.Item1, tuple.Item2);
            }
            if (!string.IsNullOrWhiteSpace(messageFromsheet))
            {
                message += "<br><br>" + messageFromsheet.ToString();
            }
            return message;
        }
        #endregion

        #region Private Mathods
        private void ReadFromExcel()
        {
            try
            {
                List<List<string>> data = new List<List<string>>();
                List<string> columns = new List<string>();

                using (SpreadsheetDocument doc = SpreadsheetDocument.Open(@"D:\ZC Hours Log.xlsx", true))
                {
                    DocumentFormat.OpenXml.Spreadsheet.Sheet sheet = doc.WorkbookPart.Workbook.Sheets.GetFirstChild<DocumentFormat.OpenXml.Spreadsheet.Sheet>();

                    //Get the Worksheet instance.
                    Worksheet worksheet = (doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;

                    //Fetch all the rows present in the Worksheet.
                    IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();

                    int rowIdx = 0;
                    List<string> rowData = null;
                    //Loop through the Worksheet rows.
                    foreach (Row row in rows)
                    {
                        rowData = new List<string>();
                        if (!string.IsNullOrWhiteSpace(row.InnerText))
                        {
                            //Use the first row to add columns to DataTable.
                            if (row.RowIndex.Value == 1)
                            {
                                foreach (Cell cell in row.Descendants<Cell>())
                                {
                                    if (cell.CellValue != null)
                                        columns.Add(GetValue(doc, cell));
                                    else
                                        break;
                                }
                            }
                            else
                            {
                                //Add rows to DataTable.

                                foreach (Cell cell in row.Descendants<Cell>())
                                {
                                    if (cell.CellValue != null)
                                        rowData.Add(GetValue(doc, cell));
                                    else
                                        break;
                                }
                                data.Add(rowData);
                                rowIdx++;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private Tuple<List<string>, List<List<string>>> ReadFromGoogleSheet()
        {
            try
            {
                string credPath = "token.json";
                string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
                FileStream fileStream = new FileStream(Environment.CurrentDirectory + "//credentials.json", FileMode.Open, FileAccess.Read);
                UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(fileStream).Secrets, Scopes, configuration.From, CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                // Create Google Sheets API service.
                var service = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Console App",
                });

                // Define request parameters.
                string[] spreadsheetId = configuration.GoogleSheetURL.Split('/');//(configuration.GoogleSheetURL.LastIndexOf('/') + 1, (configuration.GoogleSheetURL.Length - configuration.GoogleSheetURL.LastIndexOf('/')) - 1);
                string range = "A:AZ";
                SpreadsheetsResource.ValuesResource.GetRequest request =
                        service.Spreadsheets.Values.Get(spreadsheetId[spreadsheetId.Length - 2], range);
                ValueRange response = request.Execute();
                IList<IList<Object>> values = response.Values;
                List<List<Object>> todaysStatus = new List<List<Object>>() ;
                GetTodayStatus(values,ref todaysStatus);
                List<string> columns = (from p in values[0] select p.ToString()).ToList();
                columns.RemoveRange(0, 2);
                columns.RemoveRange(5, 4);
                values.RemoveAt(0);
                List<List<string>> rows = values.Select(s => s.Select(a => a.ToString()).ToList()).ToList();
                return new Tuple<List<string>, List<List<string>>>(columns, rows);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private EmailConfiguration GetConfiguration()
        {
            FileStream textReader = null;
            try
            {
                if (File.Exists(filePath))
                {
                    textReader = new FileStream(filePath, FileMode.Open);
                    XmlSerializer ser = new XmlSerializer(typeof(EmailConfiguration));
                    EmailConfiguration configuration = (EmailConfiguration)ser.Deserialize(textReader);
                    configuration.Password = CryptoEngine.Decrypt(configuration.Password, key);
                    textReader.Close();
                    return configuration;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (textReader != null)
                {
                    textReader.Close();
                }
            }
        }
        private string FormatMesssage(List<string> columns, List<List<string>> rows)
        {
            StringBuilder textBody = new StringBuilder();
            textBody.AppendFormat(" <table border=" + 1 + " cellspacing=" + 0 + " style='table-layout:fixed;font-size:10pt;font-family:arial,sans,sans-serif;width:0px;border-collapse:collapse;border:none'>", tablestyles);
            textBody.Append("<colgroup>");
            for (int colcount = 0; colcount < columns.Count; colcount++)
            {
                textBody.AppendFormat("<col width='{0}'>", width[colcount]);
            }
            textBody.Append("<colgroup>");
            textBody.Append("<tbody>");

            textBody.Append("<tr>");
            string firstRowBorder = "border:1px solid rgb(0,0,0);overflow:hidden;padding:2px 3px;vertical-align:middle;font-weight:bold;white-space:normal;word-wrap:break-word;color:rgb(0,0,0);text-align:center";
            string rowBorder = "border-width:1px;border-style:solid;border-color:rgb(0,0,0) rgb(0,0,0) rgb(0,0,0) rgb(204,204,204);overflow:hidden;padding:2px 3px;vertical-align:middle;font-family:Arial;font-weight:bold;white-space:normal;word-wrap:break-word;color:rgb(0,0,0)";
            for (int colCount = 0; colCount < columns.Count; colCount++)
            {
                textBody.AppendFormat("<td style='{0}'>{1}</td>", colCount == 0 ? firstRowBorder : rowBorder, columns[colCount]);
            }
            textBody.Append("</tr>");
            firstRowBorder = "font-family:arial,sans-serif;margin:0px;border-width:1px;border-style:solid;border-color:rgb(204,204,204) rgb(0,0,0) rgb(0,0,0);overflow:hidden;padding:2px 3px;vertical-align:middle;text-decoration:underline;white-space:normal;word-wrap:break-word;color:rgb(17,85,204);text-align:center";
            rowBorder = "font-family:Arial;margin:0px;border-width:1px;border-style:solid;border-color:rgb(204,204,204) rgb(0,0,0) rgb(0,0,0) rgb(204,204,204);overflow:hidden;padding:2px 3px;vertical-align:middle;font-weight:normal;white-space:normal;word-wrap:break-word";
            foreach (var rowData in rows)
            {
                textBody.Append("<tr>");
                for (int rowCount = 0; rowCount < rowData.Count; rowCount++)
                {
                    textBody.AppendFormat("<td style='{0}'>{1}</td>", rowCount == 0 ? firstRowBorder : rowBorder, rowData[rowCount]);
                }

                textBody.Append("</tr>");
            }
            textBody.Append("</tbody>");
            return textBody.ToString();
        }
        private string GetValue(SpreadsheetDocument doc, Cell cell)
        {
            string value = cell.CellValue.InnerText;
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements.GetItem(int.Parse(value)).InnerText;
            }
            return value;
        }
        private void GetTodayStatus(IList<IList<Object>> Status,ref List<List<Object>> todaysStatus)
        {
            for(int count = 0; count < Status.Count; count++)
            {
                if (!string.IsNullOrWhiteSpace(Status[Status.Count - count].ElementAt(1).ToString()))
                {
                    todaysStatus.Add((List<Object>)Status[Status.Count - count]);
                    break;
                }
                else
                {
                    todaysStatus.Add((List<Object>)Status[Status.Count - count]);
                }
            }
            todaysStatus.Reverse();
        }

        #endregion

    }
    public class CryptoEngine
    {
        public static string Encrypt(string input, string key)
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public static string Decrypt(string input, string key)
        {
            byte[] inputArray = Convert.FromBase64String(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}
