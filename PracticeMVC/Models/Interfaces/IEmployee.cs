using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeMVC.Models.Interfaces
{
    public interface IEmployee
    {
        Employee GetEmployee(int Id);
    }
}
