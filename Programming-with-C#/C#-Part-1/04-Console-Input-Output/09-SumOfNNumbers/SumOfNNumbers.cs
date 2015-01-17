namespace SumOfNNumbers
{
    using System;

    /// <summary>
    /// Problem 9.	Sum of n Numbers
    /// Write a program that enters a number `n` and after that enters more `n` numbers and calculates and prints their `sum`.
    /// Note: You may need to use a for-loop.
    /// Examples:
    /// | numbers | sum |
    /// |---------|-----|
    /// | 3       | 90  |
    /// | 20      |     |
    /// | 60      |     |
    /// | 10      |     |
    /// | 5       | 6.5 |
    /// | 2       |     |
    /// | -1      |     |
    /// | -0.5    |     |
    /// | 4       |     |
    /// | 2       |     |
    /// | 1       | 1   |
    /// | 1       |     | 
    /// </summary>
    public class SumOfNNumbers
    {
        public static void Main()
        {
            Console.WriteLine("Problem 9. Sum of n Numbers \nWrite a program that enters a number `n` and after that enters more `n` numbers and calculates and prints their `sum`.");
            Console.WriteLine();

            int numbersCount;

            Console.Write("Enter an integer number for the numbers count (n): ");

            if (!int.TryParse(Console.ReadLine(), out numbersCount))
            {
                throw new FormatException("Invalid format. You must enter an integer number.");
            }

            long sum = 0;
            int number;

            for (int i = 0; i < numbersCount; i++)
            {
                Console.Write("{0}: ", i + 1);
                number = int.Parse(Console.ReadLine());
                sum += number;
            }

            Console.WriteLine("Sum: {0}", sum);
        }
    }
}
