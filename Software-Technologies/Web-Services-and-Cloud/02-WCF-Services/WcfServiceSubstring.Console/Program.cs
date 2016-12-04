
namespace WcfServiceSubstring.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using System.Text;
    using System.Threading.Tasks;
    using WcfServiceSubstringOccurances;

    class Program
    {
        static void Main()
        {
            Uri serviceAddress = new Uri("http://localhost:8733/Design_Time_Addresses/WcfServiceSubstringOccurances/Service1/");
            ServiceHost selfHost = new ServiceHost(typeof(ServiceSubstringOccurances), serviceAddress);

            selfHost.AddServiceEndpoint(typeof(IServiceSubstringOccurances), new WSHttpBinding(), "SubstringOccurances Service");
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            selfHost.Description.Behaviors.Add(smb);

            using (selfHost)
            {
                selfHost.Open();
                System.Console.WriteLine("The service is started at endpoint " + serviceAddress);

                ServiceSubstringOccurances client = new ServiceSubstringOccurances();

                int occurances = client.CountSubstringOccurances("ha", "haha hoho hihi haha");
                Console.WriteLine("Number of occuranses of \"ha\" in \"haha hoho hihi haha\": {0}", occurances);
            }
        }
    }
}
