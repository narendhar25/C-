using PracticeMVC.Models;
using PracticeMVC.Models.Interfaces;
using System;
using System.Web.Mvc;

namespace PracticeMVC.Controllers
{
    public class HomeController : BaseController
    {
        private IEmployee _employee = null;

        public HomeController(IEmployee employee)
        {
            //_employee = employee;
        }
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            try
            {
               // Employee employee = _employee.GetEmployee(10);
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
            
        }
        public ActionResult Login()
        {
            return View("Login");
        }
        
    }
}