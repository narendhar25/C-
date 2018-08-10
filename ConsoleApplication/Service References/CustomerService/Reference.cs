﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApplication.CustomerService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CustomerService.ICustomerService")]
    public interface ICustomerService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetCustomer", ReplyAction="http://tempuri.org/ICustomerService/GetCustomerResponse")]
        string GetCustomer(int CustomerID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetCustomer", ReplyAction="http://tempuri.org/ICustomerService/GetCustomerResponse")]
        System.Threading.Tasks.Task<string> GetCustomerAsync(int CustomerID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetCustomerData", ReplyAction="http://tempuri.org/ICustomerService/GetCustomerDataResponse")]
        StudentService.Customer GetCustomerData(int CustomerID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetCustomerData", ReplyAction="http://tempuri.org/ICustomerService/GetCustomerDataResponse")]
        System.Threading.Tasks.Task<StudentService.Customer> GetCustomerDataAsync(int CustomerID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICustomerServiceChannel : ConsoleApplication.CustomerService.ICustomerService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CustomerServiceClient : System.ServiceModel.ClientBase<ConsoleApplication.CustomerService.ICustomerService>, ConsoleApplication.CustomerService.ICustomerService {
        
        public CustomerServiceClient() {
        }
        
        public CustomerServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CustomerServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CustomerServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CustomerServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetCustomer(int CustomerID) {
            return base.Channel.GetCustomer(CustomerID);
        }
        
        public System.Threading.Tasks.Task<string> GetCustomerAsync(int CustomerID) {
            return base.Channel.GetCustomerAsync(CustomerID);
        }
        
        public StudentService.Customer GetCustomerData(int CustomerID) {
            return base.Channel.GetCustomerData(CustomerID);
        }
        
        public System.Threading.Tasks.Task<StudentService.Customer> GetCustomerDataAsync(int CustomerID) {
            return base.Channel.GetCustomerDataAsync(CustomerID);
        }
    }
}
