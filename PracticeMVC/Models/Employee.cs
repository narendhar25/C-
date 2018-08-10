using PracticeMVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeMVC.Models
{
    public class Employee:IEmployee
    {
        public Employee GetEmployee(int Id)
        {
            return new Employee();
        }
    }
}