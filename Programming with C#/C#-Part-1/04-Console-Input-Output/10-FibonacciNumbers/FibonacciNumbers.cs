namespace FibonacciNumbers
{
    using System;

    /// <summary>
    /// Problem 10.	Fibonacci Numbers
    /// Write a program that reads a number `n` and prints on the console the first `n` members of the Fibonacci sequence (at a single line, separated by comma and space - `, `) : `0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, â€¦`.
    /// Note: You may need to learn how to use loops.
    /// Examples:
    /// |   n  |        comments        |
    /// |:----:|------------------------|
    /// | 1    | 0                      |
    /// | 3    | 0 1 1                  |
    /// | 10   | 0 1 1 2 3 5 8 13 21 34 |
    /// </summary>
    public class FibonacciNumbers
    {
        public static void Main()
        {
            Console.WriteLine("Problem 10. Fibonacci Numbers \nWrite a program that reads a number `n` and prints on the console the first `n` members of the Fibonacci sequence (at a single line, separated by comma and space - `, `) : `0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, â€¦`.");
            Console.WriteLine();

            Console.Write("Enter an integer number for the numbers count (n): ");

            int n;

            if (!int.TryParse(Console.ReadLine(), out n))
            {
                throw new FormatException("Invalid format. You must enter an integer number.");
            }

            long[] fibonacci = GetFirstNFibonacciNumbers(n);

            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} ", fibonacci[i]);
            }
            
            Console.WriteLine();

            //Console.WriteLine(string.Join(" ", fibonacci));
        }

        /// <summary>
        /// Gets the first n members of the Fibonacci sequence
        /// </summary>
        /// <param name="n">Number of Fibonacci sequence members</param>
        /// <returns>An array with a n number of the Fibonacci sequence members</returns>
        public static long[] GetFirstNFibonacciNumbers(int n)
        {
            long[] fibonacci = new long[Math.Max(n, 2)];
            fibonacci[0] = 0;
            fibonacci[1] = 1;

            for (int i = 2; i < n; i++)
            {
                fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
            }

            return fibonacci;
        }
    }
}
