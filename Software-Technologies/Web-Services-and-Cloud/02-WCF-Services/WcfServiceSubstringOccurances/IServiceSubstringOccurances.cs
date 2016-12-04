namespace WcfServiceSubstringOccurances
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;

    [ServiceContract]
    public interface IServiceSubstringOccurances
    {
        [OperationContract]
        int CountSubstringOccurances(string substring, string text);
    }
}
