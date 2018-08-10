using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiTestMvc.Models;

namespace WebApiTestMvc.Controllers
{
    //[SessionState(System.Web.SessionState.SessionStateBehavior.Disabled)]
    public class HomeController : Controller
    {
        private IEmployee _employee = null;
        public HomeController()
        {
            //_employee = employee;
        }
        // GET: Home
        //[WebApiTestMvc.App_Start.Filter]
        public ActionResult Index()
        {
            //Employee employee = _employee.GetEmployee(10);
            //Session["TempData"] = "TempData";
            //ViewData["ViewData"] = "ViewData";
            //ViewBag.ViewBag = "ViewBag";
            //TempData["TempData"] = "TempData";
            return View();
        }
        public ActionResult Emp()
        {
            //Employee emp = new Employee() {
            //    Name="Narendhar",
            //    Age=0,
            //    Married=false
            //};
            return View();
        }
        public ActionResult Details(Employee emp)
        {
            return View();
        }
        public ActionResult Redirect()
        {
            
            string ViewBag = TempData["TempData"] as string;
            return View();
        }
    }
}