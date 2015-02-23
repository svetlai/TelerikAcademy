namespace DateDifference
{
    using System;

    /// <summary>
    /// Problem 16. Date difference
    /// Write a program that reads two dates in the format: `day.month.year` and calculates the number of days between them.
    /// Example:
    /// Enter the first date: 27.02.2006
    /// Enter the second date: 3.03.2006
    /// Distance: 4 days
    /// </summary>
    public class DateDifference
    {
        public static void Main()
        {
            Console.WriteLine("Problem 16. Date difference \nWrite a program that reads two dates in the format: `day.month.year` and calculates the number of days between them.\n");
            
            DateTime firstDate = ReadDateFromTheConsole();
            DateTime secondDate = ReadDateFromTheConsole();

            double days = FindDateDifference(firstDate, secondDate);
            Console.WriteLine("Date difference: {0} days", days);
        }

        public static double FindDateDifference(DateTime firstDate, DateTime secondDate)
        {
            return (secondDate - firstDate).TotalDays;
        }

        public static DateTime ReadDateFromTheConsole()
        {
            Console.Write("Please enter a date in the format DD.MM.YYYY: ");

            DateTime date;
            if (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                throw new FormatException("Input was not in the correct format.");
            }

            return date;
        }
    }
}
