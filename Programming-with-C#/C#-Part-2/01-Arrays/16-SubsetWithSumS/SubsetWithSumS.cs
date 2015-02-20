namespace SubsetWithSumS
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Problem 16.* Subset with sum S
    /// We are given an array of integers and a number `S`.
    /// Write a program to find if there exists a subset of the elements of the array that has a sum `S`.
    /// Example:
    /// |       input array      | S  |     result    |
    /// |:----------------------:|:--:|:-------------:|
    /// | 2, **1**, **2**, 4, 3, **5**, 2, **6** | 14 | yes |
    /// </summary>
    public class SubsetWithSumS
    {
        private const string FormatExceptionMessage = "Input not in the correct format.";
        private static bool hasSubsetSum = false;
        private static List<int[]> allSubsets = new List<int[]>();

        public static void Main()
        {
            int[] array = { 2, 1, 2, 4, 3, 5, 2, 6 };
            int sum = 14;

            int[] currentSubset = new int[array.Length];

            CurrentSum(array, sum, 0, 0, 0, currentSubset);

            string result = hasSubsetSum ? "yes" : "no";

            DisplayExample(array, sum, currentSubset, result);
        }

        // Using Толя's approach: http://stackoverflow.com/questions/14575931/sum-of-k-elements-in-array-that-equates-to-n
        public static void CurrentSum(int[] numbers, int targetSum, int sumSoFar, int numsUsed, int startIndex, int[] currentSubset)
        {
            if (sumSoFar == targetSum && numsUsed > 0) // numsUsed > 0 is nessecary only if the targeted sum is 0
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
                CurrentSum(numbers, targetSum, sumSoFar + numbers[i], numsUsed + 1, i + 1, currentSubset);
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

        private static void DisplayExample(int[] input, int sum, int[] currentSubset, string result)
        {
            StringBuilder print = new StringBuilder();
            string border = new string('-', 60);

            print.AppendLine("Problem 16.* Subset with sum S \nWe are given an array of integers and a number `S`.\nWrite a program to find if there exists a subset of the elements of the array that has a sum `S`.");

            // display examples
            print.AppendLine("Example:")
                .AppendLine(border)
                .AppendLine(string.Format("{0,30} | {1,3} | {2, 3}", "input", "S", "result"))
                .AppendLine(string.Format("{0,30} | {1,3} | {2, 3}", string.Join(" ", input), sum, result))
                .AppendLine(border);

            Console.Write(print.ToString());

            // test with your input
            Console.Write("Try it yourself! \nEnter a sequence of integer numbers separated by space: ");

            hasSubsetSum = false;
            input = ConvertStringOfIntsToArray(Console.ReadLine());

            Console.Write("Enter a sum S: ");

            if (!int.TryParse(Console.ReadLine(), out sum))
            {
                Console.WriteLine(FormatExceptionMessage);
                return;
            }

            CurrentSum(input, sum, 0, 0, 0, currentSubset);
            result = hasSubsetSum ? "yes" : "no";

            print.Clear()
                .AppendLine(border)
                .AppendLine(string.Format("{0,30} | {1,3} | {2, 3}", string.Join(" ", input), sum, result))
                .AppendLine(border);

            Console.Write(print.ToString());
        }
    }
}
