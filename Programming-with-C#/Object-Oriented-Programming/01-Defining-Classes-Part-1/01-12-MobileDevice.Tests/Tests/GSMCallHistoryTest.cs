namespace MobileDevice.Tests
{
    using System;
    using System.Linq;
    using System.Text;

    using MobileDevice.Models;

    public class GSMCallHistoryTest
    {
        private const decimal PricePerMinute = 0.37m;
        private static readonly string Border = new string('-', 60);

        public static void TestCallHistory()
        {
            StringBuilder sb = new StringBuilder();
            Manufacturer nokia = new Manufacturer("Nokia", "USA");
            GSM lumia = new GSM("Lumia", nokia, 250, new Battery(), new Display());

            lumia.CallHistory.Add(new Call("12345", 230));
            lumia.CallHistory.Add(new Call("12345", 50));
            lumia.CallHistory.Add(new Call("12345", 180));

            sb.AppendLine("Call history: ");
            foreach (var call in lumia.CallHistory)
            {
                sb.AppendLine(call.ToString());
            }

            sb.AppendLine(Border);

            decimal totalPrice = lumia.CalculateTotalCallPrice(PricePerMinute);
            sb.AppendFormat("Total price all: {0}", totalPrice)
                .AppendLine()
                .AppendLine(Border);

            sb.AppendLine("To remove: ");
            Call longestCall = FindLongestCall(lumia);
            lumia.CallHistory.Remove(longestCall);

            sb.AppendLine(longestCall.ToString())
                .AppendLine(Border);

            totalPrice = lumia.CalculateTotalCallPrice(PricePerMinute);
            sb.AppendFormat("Total price after removal: {0}", totalPrice)
                .AppendLine()
                .AppendLine(Border);

            lumia.CallHistory.Clear();
            sb.AppendLine("Call history after clearing: ");
            foreach (var call in lumia.CallHistory)
            {
                sb.AppendLine(call.ToString());
            }

            Console.WriteLine(sb.ToString());
        }

        private static Call FindLongestCall(GSM gsm)
        {
            uint longest = uint.MinValue;
            foreach (var call in gsm.CallHistory)
            {
                if (call.Duration > longest)
                {
                    longest = call.Duration;
                }
            }

            Call longestCall = gsm.CallHistory.FirstOrDefault(c => c.Duration == longest);

            return longestCall;
        }
    }
}
