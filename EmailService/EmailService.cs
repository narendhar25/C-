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
        private string key = "96374584712547893347Mykeys*#@12";
        private EmailConfiguration configuration = null;
        #endregion

        #region Constructor
        public MailService()
        {
            this.configuration = GetConfiguration();
        }
        #endregion

        #region Public Methods
        public void ReadFromExcel()
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
        public Tuple<List<string>, List<List<string>>> ReadFromGoogleSheet()
        {
            try
            {
                string credPath = "token.json";
                string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
                FileStream fileStream = new FileStream(Environment.CurrentDirectory + "//credentials.json", FileMode.Open, FileAccess.Read);
                UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(fileStream).Secrets, Scopes, "narendhar.pannala@ggktech.com", CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                // Create Google Sheets API service.
                var service = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Console App",
                });

                // Define request parameters.
                String spreadsheetId = "19LrX4c6aCUI6K7Clx8utP-VdOXbO5gPkz35P_qnsUCM";
                String range = "A:AZ";
                SpreadsheetsResource.ValuesResource.GetRequest request =
                        service.Spreadsheets.Values.Get(spreadsheetId, range);
                ValueRange response = request.Execute();
                IList<IList<Object>> values = response.Values;
                List<string> columns = (from p in values[0] select p.ToString()).ToList();

                values.RemoveAt(0);
                List<List<string>> rows = values.Select(s => s.Select(a => a.ToString()).ToList()).ToList();
                return new Tuple<List<string>, List<List<string>>>(columns, rows);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool SaveConfig()
        {
            try
            {
                configuration.Password = CryptoEngine.Encrypt(configuration.Password, key);
                FileStream file = null;
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

        }
        public void SendMail(Tuple<List<string>, List<List<string>>> data, EmailConfiguration configuration)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            string messageBody = FormatMesssage(data.Item1, data.Item2);
            mail.From = new MailAddress(configuration.From);
            configuration.To.ForEach(s =>
            {
                mail.To.Add(s);
            });
            configuration.CC.ForEach(s =>
            {
                mail.CC.Add(s);
            });
            mail.Subject = configuration.Subject;
            mail.Body = configuration.EmailBody;
            if (!string.IsNullOrWhiteSpace(messageBody))
            {
                mail.Body += "<br><br>" + messageBody.ToString();
            }
            mail.IsBodyHtml = true;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(configuration.From, configuration.Password);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
        #endregion

        #region Private Mathods
        private EmailConfiguration GetConfiguration()
        {

            try
            {
                FileStream file = null;
                if (File.Exists(filePath))
                {
                    FileStream textReader = new FileStream(filePath, FileMode.Open);
                    XmlSerializer ser = new XmlSerializer(typeof(EmailConfiguration));
                    EmailConfiguration configuration = (EmailConfiguration)ser.Deserialize(textReader);
                    configuration.Password = CryptoEngine.Decrypt(configuration.Password, key);
                    file.Close();
                    return configuration;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private string FormatMesssage(List<string> columns, List<List<string>> rows)
        {
            StringBuilder textBody = new StringBuilder();
            textBody.AppendFormat(" <table border=" + 1 + " cellspacing=" + 0 + " style='table-layout:fixed;font-size:10pt;font-family:arial,sans,sans-serif;width:0px;border-collapse:collapse;border:none'>", tablestyles);
            textBody.Append("<colgroup>");
            for (int colcount = 0; colcount < columns.Count; colcount++)
            {
                textBody.Append("<col width='auto'>");
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
