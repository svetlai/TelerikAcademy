namespace MobileDevice.Tests
{
    using System;
    using System.Text;

    using MobileDevice.Models;

    public class GSMTest
    {
        public static void TestGSM()
        {
            StringBuilder sb = new StringBuilder();

            Manufacturer htc = new Manufacturer("HTC", "USA");
            Manufacturer lg = new Manufacturer("LG", "USA");
            Manufacturer nokia = new Manufacturer("Nokia", "USA");

            GSM[] gsms = new GSM[3];

            GSM evo3D = new GSM("Evo 3D", htc, 500, new Battery(BatteryType.LiIon, 40, 30), new Display(5, 1500));
            GSM nexus = new GSM("Nexus 5", lg, 300, new Battery(BatteryType.LiIon, 50, 20), new Display(6, 10000));
            GSM lumia = new GSM("Lumia", nokia, 250, new Battery(), new Display());

            gsms[0] = evo3D;
            gsms[1] = nexus;
            gsms[2] = lumia;

            foreach (var gsm in gsms)
            {
                sb.AppendLine(gsm.ToString());
                sb.AppendLine();
            }

            sb.AppendLine(GSM.IPhone4S.ToString());
            Console.WriteLine(sb.ToString());
        }
    }
}
