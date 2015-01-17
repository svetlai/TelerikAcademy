namespace RandomizeNumbersOneToN
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Problem 12.* Randomize the Numbers 1…N
    /// Write a program that enters in integer n and prints the numbers 1, 2, …, n in random order.
    /// Examples:
    /// n	randomized numbers 1…n
    /// 3	2 1 3
    /// 10	3 4 8 2 6 7 9 1 10 5
    /// Note: The above output is just an example. Due to randomness, your program most probably will produce different results. You might need to use arrays.
    /// </summary>
    public class RandomizeNumbersOneToN
    {
        private static Random random = new Random();

        public static void Main()
        {
            Console.WriteLine("Problem 12.* Randomize the Numbers 1…N \nWrite a program that enters in integer n and prints the numbers 1, 2, …, n in random order.\n");

            Console.Write("Please enter a positive integer n: ");

            int n;
            if (!int.TryParse(Console.ReadLine(), out n) || n < 0)
            {
                Console.WriteLine("Input not in the correct format.");
                return;
            }

            int numberToPrint;
            HashSet<int> printedNumbers = new HashSet<int>();

            while (printedNumbers.Count < n)
            {
                numberToPrint = random.Next(1, n + 1);
                if (!printedNumbers.Contains(numberToPrint))
                {
                    Console.Write("{0} ", numberToPrint);
                    printedNumbers.Add(numberToPrint);
                }
            }

            Console.WriteLine();
        }
    }
}
