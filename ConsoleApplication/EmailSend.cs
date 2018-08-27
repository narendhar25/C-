using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
namespace ConsoleApplication
{
    public class EmailSend
    {
        public void Send()
        {
            try
            {
                Dictionary<int, List<string>> data = new Dictionary<int, List<string>>();
                List<string> columns = new List<string>();
                string tablestyles = "table-layout:fixed;font-size:10pt;font-family:arial,sans,sans-serif;width:0px;border-collapse:collapse;border:none";
                string styles = "border:1px solid rgb(0,0,0);overflow:hidden;padding:2px 3px;vertical-align:middle;font-family:'Calibri Light';font-weight:bold;white-space:normal;word-wrap:break-word;color:rgb(0,0,0);text-align:center";
                int[] width = { 100, 305, 100, 100, 213 };
                //int rowCount = 0;
                //int colCount = 0;
                using (SpreadsheetDocument doc = SpreadsheetDocument.Open(@"D:\ZC Hours Log.xlsx", true))
                {
                    Sheet sheet = doc.WorkbookPart.Workbook.Sheets.GetFirstChild<Sheet>();

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
                                data.Add(rowIdx, rowData);
                                rowIdx++;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                StringBuilder textBody = new StringBuilder();
                textBody.AppendFormat(" <table border=" + 1 + " cellspacing=" + 0 + " style='table-layout:fixed;font-size:10pt;font-family:arial,sans,sans-serif;width:0px;border-collapse:collapse;border:none'>", tablestyles);
                textBody.Append("<colgroup>");
                for (int colcount = 0; colcount < width.Length; colcount++)
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
                foreach (var rowData in data)
                {
                    textBody.Append("<tr>");
                    for (int rowCount = 0; rowCount < rowData.Value.Count; rowCount++)
                    {
                        textBody.AppendFormat("<td style='{0}'>{1}</td>", rowCount == 0 ? firstRowBorder : rowBorder, rowData.Value[rowCount]);
                    }

                    textBody.Append("</tr>");
                }
                textBody.Append("</tbody>");
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("narendhar.pannala@ggktech.com");
                mail.To.Add("narendhar.pannala@ggktech.com");
                //mail.To.Add("harshikag@ggktech.com");
                mail.Subject = string.Format("Narendhar Pannala {0} status.", DateTime.Now.ToString("dd-MM-yyyy"));
                mail.Body = "Hi Hitesh,<br>Today i worked on following task/bug and their status.<br><br>" + textBody.ToString();
                mail.IsBodyHtml = true;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("narendhar.pannala@ggktech.com", "Nrn@96033");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {

            }
            //    xlApp = new Excel.Application();
            //xlWorkBook = xlApp.Workbooks.Open(@"D:\sheet.xlsx");
            //xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //range = xlWorkSheet.UsedRange;
            //rowCount = xlWorkSheet.Rows.Count;
            //colCount = xlWorkSheet.Columns.Count;

            //for(int row = 1; row < rowCount; row++)
            //{
            //    for(int col = 1; col < colCount; col++)
            //    {
            //        string value1 = (range.Cells[row, col] as Excel.Range).Value;
            //        string value2 = (range.Cells[row, col] as Excel.Range).Value2;
            //    }
            //}

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
    }
}
