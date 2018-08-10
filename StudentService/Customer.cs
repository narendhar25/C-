using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace StudentService
{
    [Serializable]
   [DataContract]
    public class Customer
    {
        [DataMember]
        public int CustomerID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public CustomerType Type { get; set; }

    }
    public enum CustomerType
    {
        GoldCustomer = 1,
        SilverCustomer = 2
    }
}