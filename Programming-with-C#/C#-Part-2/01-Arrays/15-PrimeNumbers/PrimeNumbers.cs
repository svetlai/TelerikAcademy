namespace PrimeNumbers
{
    using System;
    using System.Linq;

    /// <summary>
    /// Problem 15. Prime numbers
    /// Write a program that finds all prime numbers in the range [`1...10 000 000`]. Use the [Sieve of Eratosthenes](http://en.wikipedia.org/wiki/Sieve_of_Eratosthenes) algorithm.
    /// </summary>
    public class PrimeNumbers
    {
        private const string FormatExceptionMessage = "Input not in the correct format.";

        public static void Main()
        {
            Console.WriteLine("Problem 15. Prime numbers \nWrite a program that finds all prime numbers in the range [`1...10 000 000`]. Use the [Sieve of Eratosthenes](http://en.wikipedia.org/wiki/Sieve_of_Eratosthenes) algorithm.\n");

            int[] prime = GetPrimeNumbersInRange(1, 1000);  // try with 10000000
            Console.WriteLine(string.Join(" ", prime));
        }

        public static int[] GetPrimeNumbersInRange(int start, int end)
        {
            // Sieve of Eratosthenes algorithm
            int len = end - start;
            bool[] array = Enumerable.Repeat(true, len).ToArray();

            for (int i = 2; i < Math.Sqrt(len); i++)
            {
                if (array[i] == true)
                {
                    for (int j = i * i, k = 1; j < len; j = i * i + i * k, k++)
                    {
                        array[j] = false;
                    }
                }
            }

            // Select all values in the array that are true and add their indexes to a new array
            int[] prime = array.Select((value, index) => new { value, index })
                .Where(x => x.value == true && x.index > 0)
                .Select(x => x.index)
                .ToArray();

            // alternative:
            // var indexes = new List<int>();
            // var lastIndex = 0;

            // while ((lastIndex = Array.IndexOf(array, true, lastIndex)) > 0)
            // {
            //     indexes.Add(lastIndex);
            //     lastIndex++;
            // }

            // int[] prime = indexes.ToArray();

            return prime;
        }
    }
}
