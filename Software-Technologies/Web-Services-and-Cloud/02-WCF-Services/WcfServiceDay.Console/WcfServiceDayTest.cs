namespace WcfServiceDay.Console
{
    using System;
    using WcfServiceDay.Console.DayServiceReference;

    public class WcfServiceDayTest
    {
        public static void Main()
        {
            ServiceDayClient client = new ServiceDayClient();

            string day = client.GetDay(DateTime.Now);

            Console.WriteLine("Today is: {0}", day);

            client.Close();
        }
    }
}
