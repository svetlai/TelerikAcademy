namespace Delegates
{
    using System;
    using System.Threading;

    using Helper;

    /// <summary>
    /// Problem 7. Timer
    /// Using delegates write a class `Timer` that can execute certain method at each `t` seconds.
    /// </summary>
    public class TimerTest
    {
        public static void Main()
        {
            HelperMethods.DisplayTaskDescription(Constants.PathToTaskDescription);

            var timer = new Timer(1000);

            // using Action
            timer.Action = Greet;
            timer.RunAction("Mimi");

            //// using delegate
            // timer.TimerDelegate = new TimerDelegate(Greet); ;
            // timer.RunDelegate("Didi");
        }

        public static void Greet(string param)
        {
            Console.WriteLine("Hello, {0}!", param);
        }
    }
}
