namespace NumbersFromOneToN
{
    using System;

    /// <summary>
    /// Problem 8.	Numbers from 1 to n
    /// Write a program that reads an integer number `n` from the console and prints all the numbers in the interval `[1..n]`, each on a single line.
    /// Note: You may need to use a for-loop.
    /// Examples:
    /// | input | output |
    /// |-------|--------|
    /// | 3     | 1      |
    /// |       | 2      |
    /// |       | 3      |
    /// | 5     | 1      |
    /// |       | 2      |
    /// |       | 3      |
    /// |       | 4      |
    /// |       | 5      |
    /// | 1     | 1      |
    /// </summary>
    public class NumbersFromOneToN
    {
        public static void Main()
        {
            Console.WriteLine("Problem 8. Numbers from 1 to n \nWrite a program that reads an integer number `n` from the console and prints all the numbers in the interval `[1..n]`, each on a single line.");
            Console.WriteLine();

            int n;

            do
            {
                Console.Write("Enter an integer number n: ");
            }
            while (!int.TryParse(Console.ReadLine(), out n));

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}", i + 1);
            }
        }
    }
}
