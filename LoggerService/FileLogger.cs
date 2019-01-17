using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LoggerService
{
    public class FileLogger : LoggerBase
    {
        public override void Log(Exception exception)
        {
            StreamWriter fileStream = null;
            try
            {
                string filePath = this.Config.filePath;
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }
                using (fileStream = new StreamWriter(filePath, true))
                {
                    fileStream.WriteLine("");
                    fileStream.WriteLine(DateTime.Now.ToString());
                    fileStream.WriteLine("----------------------------------------------------");
                    fileStream.WriteLine(exception.Message);
                    fileStream.WriteLine(exception.StackTrace);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
        }
    }
}
