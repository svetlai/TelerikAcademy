namespace RandomNumbersInGivenRange
{
    using System;

    /// <summary>
    /// Problem 11. Random Numbers in Given Range
    /// Write a program that enters 3 integers n, min and max (min = max) and prints n random numbers in the range [min...max].
    /// Examples:
    /// n	min	max	random numbers
    /// 5	0	1	1 0 0 1 1
    /// 10	10	15	12 14 12 15 10 12 14 13 13 11
    /// Note: The above output is just an example. Due to randomness, your program most probably will produce different results.
    /// </summary>
    public class RandomNumbersInGivenRange
    {
        private static Random random = new Random();

        public static void Main()
        {
            Console.WriteLine("Problem 11. Random Numbers in Given Range \nWrite a program that enters 3 integers n, min and max (min = max) and prints n random numbers in the range [min...max].\n");

            // read input from the console:
            int n = 0;
            int min = 0;
            int max = 0;

            Console.Write("Please enter a positive integer number n: ");

            try
            {
                n = int.Parse(Console.ReadLine());

                Console.Write("Please enter a min integer: ");
                min = int.Parse(Console.ReadLine());

                Console.Write("Please enter a max integer: ");
                max = int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            // generate n random numbers in the range [min ... max] and store them in an array
            int[] randomNumbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                randomNumbers[i] = random.Next(min, max);
            }

            Console.WriteLine(string.Join(" ", randomNumbers));
        }
    }
}
