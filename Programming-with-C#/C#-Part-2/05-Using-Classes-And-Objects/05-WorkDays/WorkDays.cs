namespace WorkDays
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Problem 5. Workdays
    /// Write a method that calculates the number of workdays between today and given date, passed as parameter.
    /// Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.
    /// </summary>
    public class WorkDays
    {
        public static void Main()
        {
            Console.WriteLine("Problem 5. Workdays \nWrite a method that calculates the number of workdays between today and given date, passed as parameter. \nConsider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.\n");
            
            var holidays = GetListOfHolidays(DateTime.Now.Year);

            // 2015, 3, 28
            Console.Write("Enter an end date in the format YYYY.MM.DD: ");
            
            DateTime endDate;
            if (!DateTime.TryParse(Console.ReadLine(), out endDate))
            {
                Console.WriteLine("Input was not in the correct format.");
            }

            int workDays = CalculateWorkdays(DateTime.Now, endDate, holidays);
            Console.WriteLine("Total workdays: {0}", workDays);
        }

        public static int CalculateWorkdays(DateTime startDate, DateTime endDate, List<DateTime> holidays)
        {
            if (endDate < startDate)
            {
                throw new ArgumentException("End date cannot be before start date.");
            }

            DateTime currentDate = startDate;

            int workDays = 0;          

            while (currentDate <= endDate)
            {
                if (currentDate.Year != holidays[0].Year)
                {
                    for (int i = 0; i < holidays.Count; i++)
                    {
                        holidays[i] = holidays[i].AddYears(currentDate.Year - holidays[i].Year);
                    }
                }

                if (holidays.Contains(currentDate.Date) || currentDate.DayOfWeek == DayOfWeek.Saturday || currentDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    currentDate = currentDate.AddDays(1);
                    continue;
                }
                else
                {
                    workDays++;
                }

                currentDate = currentDate.AddDays(1);
            }

            return workDays;
        }

        public static List<DateTime> GetListOfHolidays(int year)
        {
            return new List<DateTime> 
            { 
                new DateTime(year, 2, 18), 
                new DateTime(year, 3, 3), 
                new DateTime(year, 5, 1), 
                new DateTime(year, 5, 6), 
                new DateTime(year, 5, 24), 
                new DateTime(year, 9, 6), 
                new DateTime(year, 9, 22), 
                new DateTime(year, 12, 24), 
                new DateTime(year, 12, 25), 
                new DateTime(year, 12, 26), 
            };
        }
    }
}
