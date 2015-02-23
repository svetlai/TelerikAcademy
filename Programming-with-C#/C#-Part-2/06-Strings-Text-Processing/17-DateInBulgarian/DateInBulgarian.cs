namespace DateInBulgarian
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Problem 17. Date in Bulgarian
    /// Write a program that reads a date and time given in the format: `day.month.year hour:minute:second` and prints the date and time after `6` hours and `30` minutes (in the same format) along with the day of week in Bulgarian.
    /// </summary>
    public class DateInBulgarian
    {
        public static void Main()
        {
            Console.WriteLine("Problem 17. Date in Bulgarian \nWrite a program that reads a date and time given in the format: `day.month.year hour:minute:second` and prints the date and time after `6` hours and `30` minutes (in the same format) along with the day of week in Bulgarian.\n");
            
            // 22.02.2015 6:15:21
            DateTime date = ReadDateFromTheConsole();
            DateTime newDate = AddTime(date, 6, 30);
            PrintDate(newDate, new CultureInfo("bg-BG"));
        }

        public static DateTime AddTime(DateTime date, int hours, int minutes = 0, int seconds = 0)
        {
            return date.AddHours(hours)
                .AddMinutes(minutes)
                .AddSeconds(seconds);
        }

        public static DateTime ReadDateFromTheConsole()
        {
            Console.Write("Please enter a date in the format day.month.year hour:minute:second: ");

            DateTime date;
            if (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                throw new FormatException("Input was not in the correct format.");
            }

            return date;
        }

        public static void PrintDate(DateTime date, CultureInfo culture)
        {
            Console.WriteLine("{0:dd.MM.yyyy H:mm:ss} {1}", date, date.ToString("dddd", culture));
        }
    }
}
