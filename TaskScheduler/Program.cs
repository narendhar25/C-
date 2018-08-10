using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskScheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            string path = Path.GetFullPath("D:\\test") + "\\" + DateTime.Now.ToString("MM_dd_yyyy_HH_mm") + "_Log.txt";
            try
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                }
            }
            catch (Exception ex)
            {
                Console.Write("Error :"+ex.Message);
                throw;
            }
        }
    }
}
