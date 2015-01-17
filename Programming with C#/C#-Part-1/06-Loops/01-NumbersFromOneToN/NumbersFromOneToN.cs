namespace NumbersFromOneToN
{
    using System;

    /// <summary>
    /// Problem 1. Numbers from 1 to N
    /// Write a program that enters from the console a positive integer `n` and prints all the numbers from `1` to `n`, on a single line, separated by a space.
    /// Examples:
    /// | n            | output    | 
    /// |--------------|-----------|
    /// | 3            | 1 2 3     | 
    /// | 5            | 1 2 3 4 5 |
    /// </summary>
    public class NumbersFromOneToN
    {
        public static void Main()
        {
            Console.WriteLine("Problem 1.	Numbers from 1 to N \nWrite a program that enters from the console a positive integer `n` and prints all the numbers from `1` to `n`, on a single line, separated by a space.\n");

            Console.Write("Please enter a positive integer N: ");

            int n;

            if (!int.TryParse(Console.ReadLine(), out n) || n < 1)
            {
                Console.WriteLine("Input not in the correct format.");
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                Console.Write("{0} ", i);
            }

            Console.WriteLine();
        }
    }
}
