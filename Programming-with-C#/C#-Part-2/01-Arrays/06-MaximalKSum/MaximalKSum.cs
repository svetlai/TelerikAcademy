namespace MaximalKSum
{
    using System;

    /// <summary>
    /// Problem 6. Maximal K sum
    /// Write a program that reads two integer numbers `N` and `K` and an array of `N` elements from the console.
    /// Find in the array those `K` elements that have maximal sum.
    /// </summary>
    public class MaximalKSum
    {
        private const string FormatExceptionMessage = "Input not in the correct format or range.";

        public static void Main()
        {
            DisplayExample();
        }

        public static int[] GetMaximalSubsetSumOfKElemnts(int[] array, int elementsCount)
        {
            int[] sequence = new int[elementsCount];

            Array.Sort(array);

            for (int i = array.Length - 1, j = elementsCount - 1; i >= 0 && j >= 0; i--, j--)
            {
                sequence[j] = array[i];
            }

            return sequence;
        }

        private static void DisplayExample()
        {
            Console.WriteLine("Problem 6. Maximal K sum \nWrite a program that reads two integer numbers `N` and `K` and an array of `N` elements from the console. \nFind in the array those `K` elements that have maximal sum.\n");

            Console.Write("Enter a positive integer number n: ");

            int n;
            if (!int.TryParse(Console.ReadLine(), out n) || n < 1)
            {
                Console.WriteLine(FormatExceptionMessage);
                return;
            }

            Console.WriteLine("Enter {0} integer numbers: ", n);

            int[] input = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} --> ", i + 1);

                if (!int.TryParse(Console.ReadLine(), out input[i]))
                {
                    Console.WriteLine(FormatExceptionMessage);
                    return;
                }
            }

            Console.Write("Enter a positive integer number k so that 0 < k < n: ");

            int k;
            if (!int.TryParse(Console.ReadLine(), out k) || k < 0 || k > n)
            {
                Console.WriteLine(FormatExceptionMessage);
                return;
            }

            int[] maximalSumElements = GetMaximalSubsetSumOfKElemnts(input, k);
            string border = new string('-', 60);

            Console.WriteLine(border);
            Console.WriteLine("{0,30} | {1,15}", "input", "result");
            Console.WriteLine("{0,30} | {1,15}", string.Join(" ", input), string.Join(" ", maximalSumElements));
            Console.WriteLine(border);
        }
    }
}
