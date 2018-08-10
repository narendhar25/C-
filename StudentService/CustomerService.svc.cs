using StudentService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace CustomerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CustomerService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CustomerService.svc or CustomerService.svc.cs at the Solution Explorer and start debugging.
    public class CustomerService : ICustomerService
    {
        public Customer GetCustomer(string CustomerID)
        {
            Customer cust= new Customer()
            {
                CustomerID = Convert.ToInt32(CustomerID),
                Name = "Name" + CustomerID,
                Type = CustomerType.GoldCustomer
            };
            //var serializer = new XmlSerializer(typeof(Customer));
            //StreamWriter writer = new StreamWriter("output.xml");
            //serializer.Serialize(writer, cust);
            //writer.Close();
            //JavaScriptSerializer ser = new JavaScriptSerializer();
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    return ser.Serialize(cust);
            //}
            return cust;
        }
        
    }
}
