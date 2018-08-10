using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Cors;
using System.Web.Http.Cors;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Routing;

namespace AngularWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {
        public static string serverPath = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        
        [HttpPost]
        public LoginDetails Login(string UserName, string Password)
        {
            LoginDetails details = null;
            SqlConnection con = new SqlConnection(serverPath);
            con.Open();
            SqlCommand cmd = new SqlCommand(string.Format("SELECT IsAdmin FROM MyDetails WHERE FirstName='{0}' AND Password='{1}'", UserName, Password), con);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {

                rd.Read();
                details = new LoginDetails()
                {
                    isAdmin = Convert.ToBoolean(rd[0]),
                    isValidEmployee = true
                };

            }
            else
            {
                details = new LoginDetails()
                {
                    isAdmin = false,
                    isValidEmployee = false
                };
            }
            con.Close();
            return details;

        }
        [HttpGet]
        public Collection<EmployeeDetails> GetDetails(int id)
        {
            Collection<EmployeeDetails> details = null;
            try
            {
                details = new Collection<EmployeeDetails>();
                SqlConnection con = new SqlConnection(serverPath);
                con.Open();
                string queryString = string.Empty;
                if (id == 0)
                {
                    queryString = "SELECT * FROM MyDetails where ID!=11";
                }
                else
                {
                    queryString = "SELECT * FROM MyDetails WHERE ID=" + id;
                }
                SqlCommand cmd = new SqlCommand(queryString, con);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        details.Add(new EmployeeDetails()
                        {
                            ID = Convert.ToInt32(rd["ID"]),
                            FirstName = Convert.ToString(rd["FirstName"]),
                            LastName = Convert.ToString(rd["LastName"])
                        });
                    }
                }
                con.Close();
            }

            catch (Exception ex)
            {

                throw;
            }
            return details;
        }
        [HttpPost]
        public int SaveDetails(List<EmployeeDetails> employees)
        {
            int response = 0;
            try
            {
                if (employees != null && employees.Any())
                {
                    SqlConnection con = new SqlConnection(serverPath);
                    con.Open();
                    string queryString = string.Empty;
                    foreach (EmployeeDetails employee in employees)
                    {
                        if (employee.ID > 0)
                            queryString += string.Format("UPDATE MyDetails set FirstName='{0}',LastName='{1}' WHERE ID={2}", employee.FirstName, employee.LastName, employee.ID);
                        else
                            queryString += string.Format("INSERT INTO MyDetails(FirstName,LastName) VALUES('{0}','{1}')", employee.FirstName, employee.LastName);
                    }
                    SqlCommand cmd = new SqlCommand(queryString, con);
                    response = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            catch (Exception ex)
            {

                throw;
            }
            return response;
        }
        [HttpPost]
        public int DeleteEmployees(List<int> employees)
        {
            int response = 0;
            try
            {
                if (employees != null && employees.Any())
                {
                    SqlConnection con = new SqlConnection(serverPath);
                    con.Open();
                    string queryString = string.Empty;
                    foreach (int employee in employees)
                    {
                        queryString += string.Format("DELETE FROM MyDetails WHERE ID={0}", employee);
                    }
                    SqlCommand cmd = new SqlCommand(queryString, con);
                    response = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            catch (Exception ex)
            {

                throw;
            }
            return response;
        }

        #region Authentication

        #endregion
    }
    public class EmployeeDetails
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class LoginDetails
    {
        public bool isValidEmployee { get; set; }
        public bool isAdmin { get; set; }
    }
}
