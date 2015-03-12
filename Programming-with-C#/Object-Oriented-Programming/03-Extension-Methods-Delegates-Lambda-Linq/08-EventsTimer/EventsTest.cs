namespace EventsTimer
{
    using System;

    using Helper;

    public class EventsTest
    {
        public static void Main()
        {
            HelperMethods.DisplayTaskDescription(Constants.PathToTaskDescription);

            var timer = new Timer(1000);
            timer.TimeChanged += Tick;
            timer.Start(EventArgs.Empty);
        }

        public static void Tick(object sender, EventArgs e)
        {
            Console.WriteLine("Tick! Event sender: {0}", sender.ToString());
        }
    }
}
