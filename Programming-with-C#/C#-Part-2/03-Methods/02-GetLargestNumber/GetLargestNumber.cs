namespace GetLargestNumber
{
    using System;

    /// <summary>
    /// Problem 2. Get largest number
    /// Write a method `GetMax()` with two parameters that returns the larger of two integers.
    /// Write a program that reads `3` integers from the console and prints the largest of them using the method `GetMax()`.
    /// </summary>
    public class GetLargestNumber
    {
        private const string InvalidFormatMsg = "Input was not in the correct format.";

        public static void Main()
        {
            Console.WriteLine("Problem 2. Get largest number \nWrite a method `GetMax()` with two parameters that returns the larger of two integers. \nWrite a program that reads `3` integers from the console and prints the largest of them using the method `GetMax()`.\n");

            Console.Write("Enter a positive integer number: ");

            int first;
            if (!int.TryParse(Console.ReadLine(), out first))
            {
                Console.WriteLine(InvalidFormatMsg);
                return;
            }

            Console.Write("Enter a positive integer number: ");

            int second;
            if (!int.TryParse(Console.ReadLine(), out second))
            {
                Console.WriteLine(InvalidFormatMsg);
                return;
            }

            Console.Write("Enter a positive integer number: ");

            int third;
            if (!int.TryParse(Console.ReadLine(), out third))
            {
                Console.WriteLine(InvalidFormatMsg);
                return;
            }          

            int max = GetMax(first, GetMax(second, third));

            Console.WriteLine("The largest number is: {0}", max);
        }

        public static int GetMax(int first, int second)
        {
            return first > second ? first : second;
        }
    }
}
