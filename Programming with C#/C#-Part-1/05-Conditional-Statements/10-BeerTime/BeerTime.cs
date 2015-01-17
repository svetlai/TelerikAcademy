namespace BeerTime
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Problem 10.* Beer Time
    /// A beer time is after 1:00 PM and before 3:00 AM.
    /// Write a program that enters a time in format “hh:mm tt” (an hour in range [01...12], a minute in range [00…59] and AM / PM designator) and prints beer time or non-beer time according to the definition above or invalid time if the time cannot be parsed. 
    /// Note: You may need to learn how to parse dates and times.
    /// Examples:
    /// time	result
    /// 1:00 PM	beer time
    /// 4:30 PM	beer time
    /// 10:57 PM	beer time
    /// 8:30 AM	non-beer time
    /// 02:59 AM	beer time
    /// 03:00 AM	non-beer time
    /// 03:26 AM	non-beer time
    /// </summary>
    public class BeerTime
    {
        public static void Main()
        {
            Console.WriteLine("Problem 10.* Beer Time \nA beer time is after 1:00 PM and before 3:00 AM. \nWrite a program that enters a time in format “hh:mm tt” (an hour in range [01...12], a minute in range [00…59] and AM / PM designator) and prints beer time or non-beer time according to the definition above or invalid time if the time cannot be parsed. Note: You may need to learn how to parse dates and times.\n");
            
            Console.Write("Please enter time in the format \"h:mm tt\": ");
            string line = Console.ReadLine();

            Console.WriteLine(CheckIfBeerTime(line));           
        }

        /// <summary>
        /// Checks if entered time is between 1 and 3 PM
        /// </summary>
        /// <param name="time">A string in the format "h:mm tt"</param>
        /// <returns>A string indicating if it's beer time</returns>
        public static string CheckIfBeerTime(string time)
        {
            DateTime startTime = DateTime.Parse("1:00 PM");
            DateTime endTime = DateTime.Parse("3:00 PM");

            DateTime beerTime;
            if (DateTime.TryParseExact(time, "h:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out beerTime))
            {
                if (beerTime > startTime && beerTime < endTime)
                {
                    return "beer time";
                }
                else
                {
                    return "non-beer time";
                }
            }
            else
            {
                return "invalid time";
            }
        }
    }
}
