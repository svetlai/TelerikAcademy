﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfServiceSubstring.Console.SubstringOccurancesServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SubstringOccurancesServiceReference.IServiceSubstringOccurances")]
    public interface IServiceSubstringOccurances {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceSubstringOccurances/CountSubstringOccurances", ReplyAction="http://tempuri.org/IServiceSubstringOccurances/CountSubstringOccurancesResponse")]
        int CountSubstringOccurances(string substring, string text);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceSubstringOccurances/CountSubstringOccurances", ReplyAction="http://tempuri.org/IServiceSubstringOccurances/CountSubstringOccurancesResponse")]
        System.Threading.Tasks.Task<int> CountSubstringOccurancesAsync(string substring, string text);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceSubstringOccurancesChannel : WcfServiceSubstring.Console.SubstringOccurancesServiceReference.IServiceSubstringOccurances, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceSubstringOccurancesClient : System.ServiceModel.ClientBase<WcfServiceSubstring.Console.SubstringOccurancesServiceReference.IServiceSubstringOccurances>, WcfServiceSubstring.Console.SubstringOccurancesServiceReference.IServiceSubstringOccurances {
        
        public ServiceSubstringOccurancesClient() {
        }
        
        public ServiceSubstringOccurancesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceSubstringOccurancesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceSubstringOccurancesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceSubstringOccurancesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int CountSubstringOccurances(string substring, string text) {
            return base.Channel.CountSubstringOccurances(substring, text);
        }
        
        public System.Threading.Tasks.Task<int> CountSubstringOccurancesAsync(string substring, string text) {
            return base.Channel.CountSubstringOccurancesAsync(substring, text);
        }
    }
}
