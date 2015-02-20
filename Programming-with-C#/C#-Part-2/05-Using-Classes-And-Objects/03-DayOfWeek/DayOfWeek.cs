namespace DayOfWeek
{
    using System;

    /// <summary>
    /// Problem 3. Day of week
    /// Write a program that prints to the console which day of the week is today.
    /// Use `System.DateTime`.
    /// </summary>
    public class DayOfWeek
    {
        public static void Main()
        {
            Console.WriteLine("Problem 3. Day of week \nWrite a program that prints to the console which day of the week is today. \nUse `System.DateTime`.\n");
            
            DateTime today = DateTime.Now;

            var dayOfWeek = GetDay(today);

            Console.WriteLine("Today is {0}", dayOfWeek);
        }

        public static System.DayOfWeek GetDay(DateTime date)
        {
            return date.DayOfWeek;
        }
    }
}
