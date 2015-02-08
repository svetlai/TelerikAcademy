namespace SubsetKWithSumS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Problem 17.* Subset K with sum S
    /// Write a program that reads three integer numbers `N`, `K` and `S` and an array of `N` elements from the console.
    /// Find in the array a subset of `K` elements that have sum `S` or indicate about its absence.
    /// </summary>
    public class SubsetKWithSumS
    {
        private const string FormatExceptionMessage = "Input not in the correct format or range.";
        private static readonly string Border = new string('-', 60);
        private static bool hasSubsetSum = false;
        private static List<int[]> allSubsets = new List<int[]>();

        public static void Main()
        {
            Console.WriteLine("Problem 17.* Subset K with sum S \nWrite a program that reads three integer numbers `N`, `K` and `S` and an array of `N` elements from the console. \nFind in the array a subset of `K` elements that have sum `S` or indicate about its absence.");

            // display examples
            Console.WriteLine("Example:");
            int[] array = { 2, 1, 2, 4, 3, 5, 2, 6 };
            int k = 4;
            int sum = 14;

            int[] currentSubset = new int[array.Length];

            CurrentSum(array, k, sum, 0, 0, 0, currentSubset);

            string result = hasSubsetSum ? "yes" : "no";

            Console.WriteLine(Border);
            Console.WriteLine("{0,3} | {1,30} | {2,3} | {3,3} | {4,3}", "N", "input", "K", "S", "result");
            Console.WriteLine("{0,3} | {1,30} | {2,3} | {3,3} | {4,3}", array.Length, string.Join(" ", array), k, sum, result);
            Console.WriteLine(Border);

            // test with your input
            Console.Write("Try it yourself! \nEnter a positive integer number n: ");

            int n;
            if (!int.TryParse(Console.ReadLine(), out n) || n < 1)
            {
                Console.WriteLine(FormatExceptionMessage);
            }

            Console.WriteLine("Enter {0} integer numbers: ", n);

            int[] input = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} --> ", i + 1);

                if (!int.TryParse(Console.ReadLine(), out input[i]))
                {
                    Console.WriteLine(FormatExceptionMessage);
                }
            }

            Console.Write("Enter a positive integer number k so that 0 < k < n: ");

            if (!int.TryParse(Console.ReadLine(), out k) || k < 0 || k > n)
            {
                Console.WriteLine(FormatExceptionMessage);
                return;
            }

            Console.Write("Enter a sum s: ");

            if (!int.TryParse(Console.ReadLine(), out sum))
            {
                Console.WriteLine(FormatExceptionMessage);
                return;
            }

            hasSubsetSum = false;
            CurrentSum(input, k, sum, 0, 0, 0, currentSubset);
            result = hasSubsetSum ? "yes" : "no";

            Console.WriteLine(Border);
            Console.WriteLine("{0,3} | {1,30} | {2,3} | {3,3} | {4,3}", n, string.Join(" ", input), k, sum, result);
            Console.WriteLine(Border);
        }

        // Using Толя's approach: http://stackoverflow.com/questions/14575931/sum-of-k-elements-in-array-that-equates-to-n
        public static void CurrentSum(int[] numbers, int numsCount, int targetSum, int sumSoFar, int numsUsed, int startIndex, int[] currentSubset)
        {
            if (sumSoFar == targetSum && numsUsed == numsCount)
            {
                hasSubsetSum = true;
                GatherAllSubsets(numsUsed, currentSubset);
            }

            if (startIndex >= numbers.Length)
            {
                return;
            }

            for (int i = startIndex; i < numbers.Length; i++)
            {
                // Include i'th number to current subset
                currentSubset[numsUsed] = numbers[i];
                CurrentSum(numbers, numsCount, targetSum, sumSoFar + numbers[i], numsUsed + 1, i + 1, currentSubset);
            }
        }

        /// <summary>
        /// Adds all subsets to a list
        /// </summary>
        /// <param name="count"></param>
        /// <param name="currentSubset"></param>
        public static void GatherAllSubsets(int count, int[] currentSubset)
        {
            int[] subset = new int[count];

            for (int i = 0; i < count; i++)
            {
                subset[i] = currentSubset[i];
            }

            allSubsets.Add(subset);
        }

        private static int[] ConvertStringOfIntsToArray(string text)
        {
            return Array.ConvertAll(text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
        }
    }
}
