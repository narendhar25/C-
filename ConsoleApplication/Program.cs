using ConsoleApplication;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ConsoleApplication
{
    class Program
    {
        //public static string str;
        //public static DateTime date;
        static void Main(string[] args)
        {
            EmailSend emailSend = new EmailSend();
            emailSend.Send();
            //AsyncClass dd = new AsyncClass();
            //Task<string> name =dd.GetString();
            //Console.WriteLine("NAme");
            //Console.WriteLine(name.Result+"after NAme");
            //PasswordHash passwordHash = new PasswordHash();
            //passwordHash.GeneratePasswordHash("Qwerty");
            //Customer dd= CreateInstance<Customer>.Create();
            //Type type=  dd.GetType();
            //PropertyInfo[] propertyInfo = type.GetProperties();
            //foreach(var property in propertyInfo)
            //{
            //    Console.WriteLine(property.Name+" "+property.PropertyType +" "+property.GetHashCode());
            //}
            //Console.Write(dd.GetType());
            //SaltGeneration.GenerateSalt();
            Console.ReadLine();
        }
        public async Task<Customer[]> GetCustomersAsync(List<int> IDs)
        {
            var things = IDs.Select(s => GetCustmer(s)).ToList();
            return await Task.WhenAll(things);
        }

        public async Task<Customer> GetCustmer(int id)
        {
            await Task.Delay(1000);
            return new Customer()
            {
                CustomerID = id,
                Name = "Name" + id,
                Type = CustomerType.GoldCustomer
            };
        }
    }
    public class AsyncClass
    {
        public async Task<string> GetString()
        {
            await Task.Delay(1000);
            return "Narendhar";
        }
    }
    class ApplicationHelper
    {
        RegistryKey LocalMachine;
        string uninstallKey;
        string strUninstallList2;

        public ApplicationHelper()
        {
            LocalMachine = Registry.LocalMachine;
            uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
        }

        public List<Software> getApplicationlist()
        {
            List<Software> softwares = new List<Software>();
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {

                            var displayName = Convert.ToString(sk.GetValue("DisplayName"));
                            var size = sk.GetValue("EstimatedSize");

                            Software software = new Software();
                            software.DisplayName = displayName == "" ? GetNameFromAbsoluteName(sk.Name) : displayName;
                            software.DisplayVersion = Convert.ToString(sk.GetValue("DisplayVersion "));
                            software.EstimatedSize = Convert.ToString(sk.GetValue("EstimatedSize"));
                            software.InstallDate = Convert.ToString(sk.GetValue("InstallDate"));
                            software.InstallLocation = Convert.ToString(sk.GetValue("InstallLocation"));
                            software.InstallSource = Convert.ToString(sk.GetValue("InstallSource"));
                            software.Publisher = Convert.ToString(sk.GetValue("Publisher"));
                            software.UninstallString = Convert.ToString(sk.GetValue("UninstallString"));
                            software.Version = Convert.ToString(sk.GetValue("Version"));
                            software.VersionMajor = Convert.ToString(sk.GetValue("VersionMajor"));
                            software.VersionMinor = Convert.ToString(sk.GetValue("VersionMinor"));
                            softwares.Add(software);
                        }
                        catch
                        {
                            Console.WriteLine("Something Went Wrong");
                        }
                    }
                }
            }
            return softwares;
        }
        private string GetNameFromAbsoluteName(string absoluteName)
        {
            return absoluteName.Substring(absoluteName.LastIndexOf('\\') + 1);
        }
    }
    class Software
    {
        public string DisplayName { get; set; }
        public string DisplayVersion { get; set; }
        public string Publisher { get; set; }
        public string VersionMinor { get; set; }
        public string VersionMajor { get; set; }
        public string Version { get; set; }
        public string InstallDate { get; set; }
        public string InstallLocation { get; set; }
        public string InstallSource { get; set; }
        public string EstimatedSize { get; set; }
        public string UninstallString { get; set; }
        public override string ToString()
        {
            return "DisplayName: " + DisplayName
                + ",DisplayVersion: " + DisplayVersion
                + ",InstallDate: " + InstallDate
                + ",Publisher: " + Publisher;
        }

    }
    public interface IService
    {
        void Serve();
    }

    public class Service : IService
    {
        public void Serve()
        {
            Console.WriteLine("Service called");
        }
    }

    public class Client
    {
        public IService service;
        public Client(IService service)
        {
            this.service = service;
        }
    }
    public class Client1
    {
        private string asd { get; set; }
        private IService service;
        public Service _Service
        {
            set
            {
                this.service = value;
            }
        }

        public void start()
        {

            Console.WriteLine("Start called");
            this.service.Serve();
        }
    }
    [Serializable]
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

    public class Base
    {
        public int Num1 { get; set; }
        public int Num2 { get; set; }

        public virtual int Add()
        {
            return (this.Num1 + this.Num2);
        }
    }

    public class Child : Base
    {
        public override int Add()
        {
            return (this.Num1 + this.Num2 + 10);
        }
    }

    public class Child2 : Base
    {
        public override int Add()
        {
            return (this.Num1 + this.Num2 + 20);
        }
    }

    public class Expose
    {
        public void CallRespectiveMethod(Base base1)
        {
            Console.WriteLine(base1.Add());
        }
    }

    public class PasswordHash
    {
        public string GeneratePasswordHash(string password)
        {
            Guid guid = new Guid();
            string salt=guid.ToString();
            return (salt + password).GetHashCode().ToString();
        }
    }
}

