namespace WcfServiceDay.Web
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IServiceDay
    {

        [OperationContract]
        string GetDay(DateTime date);
    }
}
