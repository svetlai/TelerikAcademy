namespace CurrentDateAndTime
{
    using System;

    /// <summary>
    /// Problem 14.* Current Date and Time
    /// Create a console application that prints the current date and time. Find out how in Internet.
    /// </summary>
    public class CurrentDateAndTime
    {
        public static void Main()
        {
            DateTime currentDate = DateTime.Now;

            Console.WriteLine(currentDate);
        }
    }
}
