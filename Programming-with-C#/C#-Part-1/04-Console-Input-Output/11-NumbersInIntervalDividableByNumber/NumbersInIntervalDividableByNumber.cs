namespace NumbersInIntervalDividableByNumber
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Problem 11.* Numbers in Interval Dividable by Given Number
    /// Write a program that reads two positive integer numbers and prints how many numbers `p` exist between them such that the reminder of the division by `5` is `0`.
    /// Examples:
    /// | start | end |  p |                                         comments                                         |
    /// |:-----:|:---:|:--:|------------------------------------------------------------------------------------------|
    /// | 17    | 25  | 2  | 20, 25                                                                                   |
    /// | 5     | 30  | 6  | 5, 10, 15, 20, 25, 30                                                                    |
    /// | 3     | 33  | 6  | 5, 10, 15, 20, 25, 30                                                                    |
    /// | 3     | 4   | 0  | -                                                                                        |
    /// | 99    | 120 | 5  | 100, 105, 110, 115, 120                                                                  |
    /// | 107   | 196 | 18 | 110, 115, 120, 125, 130, 135, 140, 145, 150, 155, 160, 165, 170, 175, 180, 185, 190, 195 |
    /// </summary>
    public class NumbersInIntervalDividableByNumber
    {
        public static void Main()
        {
            const string FormatExceptionMessage = "Number not in the correct format. Please enter a positive integer number.";
            const string ArgumentExceptionMessage = "Second number must be bigger than first.";

            Console.WriteLine("Problem 11.* Numbers in Interval Dividable by Given Number \nWrite a program that reads two positive integer numbers and prints how many numbers `p` exist between them such that the reminder of the division by `5` is `0`.");
            Console.WriteLine();

            // Read and parse first integer
            Console.Write("Enter the first positive integer number: ");
            string firstLine = Console.ReadLine();
            int first;

            if (!int.TryParse(firstLine, out first) || first < 0)
            {
                throw new FormatException(FormatExceptionMessage);
            }

            // Read and parse second integer
            Console.Write("Enter the second positive integer number: ");
            string secondLine = Console.ReadLine();
            int second;

            if (!int.TryParse(secondLine, out second) || second < 0)
            {
                throw new FormatException(FormatExceptionMessage);
            }

            // Check if second is bigger than first
            if (second < first)
            {
                throw new ArgumentException(ArgumentExceptionMessage);
            }

            // Count numbers with reminder 0
            int counter = 0;
            List<int> dividableNumbers = new List<int>();

            for (int i = first + 1; i <= second; i++)
            {
                if (i % 5 == 0)
                {
                    counter++;
                    dividableNumbers.Add(i);
                }
            }

            // Print result
            Console.WriteLine("{0,5} | {1,5} | {2,5} | {3}", "start", "end", "p", "comments");
            Console.WriteLine("{0,5} | {1,5} | {2,5} | {3}", first, second, counter, string.Join(" ", dividableNumbers));
        }
    }
}
