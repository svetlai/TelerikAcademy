namespace DatesInCanada
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    /// <summary>
    /// Problem 19. Dates from text in Canada
    /// Write a program that extracts from a given text all dates that match the format `DD.MM.YYYY`.
    /// Display them in the standard date format for Canada.
    /// </summary>
    public class DatesInCanada
    {
        public static void Main()
        {
            string text = "Lorem Ipsum has been the industry's invalid date test - 02.22.2014 standard dummy text 03.03.2015 ever since the 1500s 22.02.2014";
            var format = "dd.M.yyyy";
            var dates = ExtractDates(text, format, new CultureInfo("en-CA"));

            DisplayExample(text, format, dates); 
        }

        public static List<DateTime> ExtractDates(string text, string format, CultureInfo culture)
        {
            var dates = new List<DateTime>();
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                if (IsValidDate(word, format, culture))
                {
                    DateTime date = DateTime.ParseExact(word, format, culture, DateTimeStyles.None);
                    dates.Add(date);
                }
            }

            return dates;
        }

        private static bool IsValidDate(string date, string format, CultureInfo culture)
        {
            DateTime valid;
            if (DateTime.TryParseExact(date, format, culture, DateTimeStyles.None, out valid))
            {
                return true;
            }

            return false;
        }

        private static void DisplayExample(string text, string format, List<DateTime> dates)
        {
            StringBuilder print = new StringBuilder();
            string border = new string('-', 60);

            print.AppendLine("Problem 19. Dates from text in Canada \nWrite a program that extracts from a given text all dates that match the format `DD.MM.YYYY`. \nDisplay them in the standard date format for Canada.\n")
                .AppendLine("Example: ")
                .AppendLine(text)
                .AppendLine(border);

            foreach (var date in dates)
            {
                print.AppendLine(date.ToString());
            }

            print.AppendLine(border);

            Console.Write(print.ToString());              
        }
    }
}
