namespace NumbersNotDivisibleBy3And7
{
    using System;

    /// <summary>
    /// Problem 2. Numbers Not Divisible by 3 and 7
    /// Write a program that enters from the console a positive integer `n` and prints all the numbers from `1` to `n` not divisible by `3` and `7`, on a single line, separated by a space.
    /// Examples:
    /// | n  | output       |
    /// |----|--------------|
    /// | 3  | 1 2          |
    /// | 10 | 1 2 4 5 8 10 |
    /// </summary>
    public class NumbersNotDivisibleBy3And7
    {
        public static void Main()
        {
            Console.WriteLine("Problem 2. Numbers Not Divisible by 3 and 7 \nWrite a program that enters from the console a positive integer `n` and prints all the numbers from `1` to `n` not divisible by `3` and `7`, on a single line, separated by a space.\n");

            Console.Write("Please enter a positive integer N: ");

            int n;

            if (!int.TryParse(Console.ReadLine(), out n) || n < 1)
            {
                Console.WriteLine("Input not in the correct format.");
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                if (i % 3 != 0 && i % 7 != 0)
                {
                    Console.Write("{0} ", i);
                }
            }

            Console.WriteLine();
        }
    }
}
