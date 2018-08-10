using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTestMvc.Models
{
    public interface IEmployee
    {
        Employee GetEmployee(int Id);
    }
}
