namespace LeapYear
{
    using System;

    /// <summary>
    /// Problem 1. Leap year
    /// Write a program that reads a year from the console and checks whether it is a leap one.
    /// Use `System.DateTime`.
    /// </summary>
    public class LeapYear
    {
        public static void Main()
        {
            Console.WriteLine("Problem 1. Leap year \nWrite a program that reads a year from the console and checks whether it is a leap one. \nUse `System.DateTime`.\n");

            int year = ReadYearFromConsole();

            bool isLeapYear = IsLeapYear(year);

            Console.WriteLine("Is leap year? --> {0}", isLeapYear);
        }

        public static bool IsLeapYear(int year)
        {
            if (year < 1 || year > 9999)
            {
                throw new ArgumentException("Invalid input. Year must be between 1 and 9999");
            }

            return DateTime.IsLeapYear(year);
        }

        private static int ReadYearFromConsole()
        {
            Console.Write("Enter year: ");

            int year;
            if (!int.TryParse(Console.ReadLine(), out year))
            {
                throw new ArgumentException("Input was not in the correct format.");
            }

            return year;
        }
    }
}
