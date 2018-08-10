using PracticeMVC.Models;
using PracticeMVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeMVC.Controllers
{
    public class HomeController : Controller
    {
        private IEmployee _employee = null;

        public HomeController(IEmployee employee)
        {
            _employee = employee;
        }
        // GET: Home
        public ActionResult Index()
        {
            Employee employee = _employee.GetEmployee(10);
            return View();
        }
    }
}