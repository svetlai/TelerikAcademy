namespace AgeAfterTenYears
{
    using System;

    /// <summary>
    /// Problem 15.* Age after 10 Years
    /// Write a program to read your birthday from the console and print how old you are now and how old you will be after 10 years.
    /// </summary>
    public class AgeAfterTenYears
    {
        public static void Main()
        {
            Console.Write("Enter your birthday in the format dd/mm/yyyy: ");

            string input = Console.ReadLine();
            
            DateTime birthday = DateTime.Now;
            
            try
            {
                birthday = DateTime.Parse(input);
            }
            catch (Exception e)
            {
                Console.WriteLine("The entered input was invalid. Date cannot be processed.");
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }

            DateTime today = DateTime.Today;
            DateTime dateInTenYears = today.AddYears(10);

            int age = dateInTenYears.Year - birthday.Year;

            // if birthday has not passed this year - subtract a year
            if (birthday.AddYears(age) > today)
            {
                age--;
            }
            
            Console.WriteLine("Your age in 10 years will be: {0}", age);
        }
    }
}
