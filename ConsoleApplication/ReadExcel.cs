using System;
using System.Collections.ObjectModel;
using Excel = Microsoft.Office.Interop.Excel;

namespace ConsoleApplication
{
    public class ReadExcel
    {
        Excel.Application xlApp;
        Excel.Workbook xlWorkbook;
        Excel.Worksheet xlWorksheet;
        Excel.Range xlRange;

        public Collection<Details> ExcelToObject()
        {
            Collection<Details> data = null;
            try
            {
                xlApp = new Excel.Application();
                xlWorkbook = xlApp.Workbooks.Open("C:/Users/narendhar.pannala/Desktop/Book1.xlsx");
                xlWorksheet = xlWorkbook.Worksheets.Item[0];
                xlRange = xlWorksheet.UsedRange;
                int rw = xlRange.Rows.Count;
                data = new Collection<Details>();
                for (int count = 1; count < rw; count++)
                {
                    data.Add(new Details
                    {
                        Name = (string)xlWorksheet.Cells[count, 0],
                        Address = (string)xlWorksheet.Cells[count, 1],
                        Age = (int)xlWorksheet.Cells[count, 2]
                    });
                }
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
            }

            return data;
        }
    }
    public class Details
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }

    }
}
