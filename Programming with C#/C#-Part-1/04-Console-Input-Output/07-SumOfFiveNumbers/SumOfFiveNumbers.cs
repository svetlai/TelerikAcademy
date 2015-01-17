namespace SumOfFiveNumbers
{
    using System;
    using System.Globalization;
    using System.Threading;

    /// <summary>
    /// Problem 7. Sum of 5 Numbers
    /// Write a program that enters 5 numbers (given in a single line, separated by a space), calculates and prints their sum.
    /// Examples:
    /// |      numbers      |  sum  |
    /// |-------------------|-------|
    /// | 1 2 3 4 5         | 15    |
    /// | 10 10 10 10 10    | 50    |
    /// | 1.5 3.14 8.2 -1 0 | 11.84 |
    /// </summary>
    public class SumOfFiveNumbers
    {
        public static void Main()
        {
            Console.WriteLine("Problem 7. Sum of 5 Numbers \nWrite a program that enters 5 numbers (given in a single line, separated by a space), calculates and prints their sum.");
            Console.WriteLine();

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Enter 5 numbers separated by space: ");

            string line = Console.ReadLine();

            string[] numbers = line.Split(' ');
            double sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                sum += double.Parse(numbers[i]);
            }

            Console.WriteLine("Sum: {0}", sum);
        }
    }
}
