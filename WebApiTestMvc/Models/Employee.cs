using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiTestMvc.Models
{
    public class Employee : IEmployee
    {
        [Display(Name = "Employee Name")]
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Married { get; set; }

        public Employee GetEmployee(int Id)
        {
            return new Employee();
        }
    }
}