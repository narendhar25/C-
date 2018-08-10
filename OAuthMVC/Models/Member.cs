using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OAuthMVC.Models
{
    public class Member
    {
        public static string serverPath = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public bool IsExistingUser(string UserName, string ProviderUserId, string ProviderUserName)
        {
            bool result = false;
            SqlConnection sqlCon = null;
            try
            {
                sqlCon = new SqlConnection(serverPath);
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM USERDETAILS WHERE USERNAME='" + UserName + "' AND PROVIDERUSERID='" + ProviderUserId + "' AND PROVIDERNAME='" + ProviderUserName + "'",sqlCon);
                result= cmd.ExecuteNonQuery()>0;
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }
        public bool CreateUSer(string UserName, string ProviderUserId, string ProviderUserName)
        {
            bool result = false;
            SqlConnection sqlCon = null;
            try
            {
                sqlCon = new SqlConnection(serverPath);
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO USERDETAILS VALUES('"+ UserName + "','"+ ProviderUserId + "','"+ ProviderUserName + "')",sqlCon);
                result = cmd.ExecuteNonQuery() > 0;
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

    }
}