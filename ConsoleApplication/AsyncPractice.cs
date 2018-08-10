using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class AsyncPractice
    {
        public async Task<int> GetFileLength(string filepath)
        {
            int str=  await getFileStream(filepath);
            Console.WriteLine(str);
            return str;
        }
        async Task<int> getFileStream(string filepath)
        {
            int a = 0;
            int b = 1;
            Task<int> ta = null; //new Task<int>(() => 10);
            try
            {
              return await Task.Run(() => (b / a));
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);

            }
            return await ta;
           // FileStream file = File.OpenRead(filepath);

            //file.Read(new byte[file.Length],0,(int)file.Length)

        }
        public async void LogMessage(string message)
        {
           await Task.Run(()=> Console.WriteLine(message));
        }
    }
}
