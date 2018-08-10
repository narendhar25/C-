using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBAPI.Models;
using System.Web.Http.Cors;

namespace WEBAPI.Controllers
{
    public class HomeController : ApiController
    {

        [EnableCors(origins: "http://mywebclient.azurewebsites.net", headers: "*", methods: "*")]
        public Collection<StudentDetails> GetDetails(int id)
        {
            Collection<StudentDetails> details = null;
            try
            {
                details = new Collection<StudentDetails>();
                Random rd = new Random(1);
                for (int count = 0; count < 10; count++)
                {
                    int temp = rd.Next(100, 10000);
                    details.Add(new StudentDetails()
                    {
                        ID = temp,
                        FirstName = "FName"+ temp,
                        LastName = "LName"+ temp
                    });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return details;
        }
        [HttpGet]
        public StudentDetails Details(int id)
        {
            StudentDetails detail = null;
            try
            {
                detail = new StudentDetails()
                {
                    ID = id,
                    FirstName = "FName" + id,
                    LastName = "LName" + id
                };
            }
            catch (Exception ex)
            {
                throw;
            }
            return detail;
        }
        [HttpPut]
        public StudentDetails Update(StudentDetails student)
        {
            StudentDetails detail = null;
            try
            {
               
            }
            catch (Exception ex)
            {
                throw;
            }
            return detail;
        }
        
    }
}
