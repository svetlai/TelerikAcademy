namespace SumOfThreeNumbers
{
    using System;
    using System.Globalization;
    using System.Threading;

    public class SumOfThreeNumbers
    {
        /// <summary>
        /// Problem 1. Sum of 3 Numbers
        /// Write a program that reads 3 real numbers from the console and prints their sum.
        /// Examples:
        /// a	b	c	sum
        /// 3	4	11	18
        /// -2	0	3	1
        /// 5.5	4.5	20.1	30.1
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Problem 1. Sum of 3 Numbers \nWrite a program that reads 3 real numbers from the console and prints their sum.");

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            try
            {
                Console.Write("Enter first integer: ");
                double first = double.Parse(Console.ReadLine());

                Console.Write("Enter second integer: ");
                double second = double.Parse(Console.ReadLine());

                Console.Write("Enter third integer: ");
                double third = double.Parse(Console.ReadLine());

                double sum = first + second + third;

                Console.WriteLine("{0,5} | {1,5} | {2,5} | {3,5}", first, second, third, sum);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
