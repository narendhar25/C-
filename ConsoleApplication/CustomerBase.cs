using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public static class CreateInstance<T>
    {
        
        public static T Create()
        {
            return Activator.CreateInstance<T>();
        }
    }
}
