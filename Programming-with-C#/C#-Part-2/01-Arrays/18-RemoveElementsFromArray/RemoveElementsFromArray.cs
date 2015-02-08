namespace RemoveElementsFromArray
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Problem 18.* Remove elements from array
    /// Write a program that reads an array of integers and removes from it a minimal number of elements in such a way that the remaining array is sorted in increasing order.
    /// Print the remaining sorted array.
    /// Example:
    /// |           input           |     result    |
    /// |:-------------------------:|:-------------:|
    /// | 6, **1**, 4, **3**, 0, **3**, 6, **4**, **5** | 1, 3, 3, 4, 5 |
    /// </summary>
    public class RemoveElementsFromArray
    {
        private static readonly string Border = new string('-', 60);

        public static void Main()
        {
            Console.WriteLine("Problem 18.* Remove elements from array \nWrite a program that reads an array of integers and removes from it a minimal number of elements in such a way that the remaining array is sorted in increasing order. \nPrint the remaining sorted array.");

            // display examples
            Console.WriteLine("Example:");
            int[] array = { 6, 1, 4, 3, 0, 3, 6, 4, 5 };
            List<int> currentSubset = new List<int>();
            int[] longest = new int[0];

            FindLongestIncreasingSubset(array, 0, currentSubset, ref longest);

            Console.WriteLine(Border);
            Console.WriteLine("{0,30} | {1,15}", "input", "result");
            Console.WriteLine("{0,30} | {1,15}", string.Join(" ", array), string.Join(" ", longest));
            Console.WriteLine(Border);

            // test with your input
            Console.Write("Try it yourself! \nEnter a sequence of integer numbers separated by space: ");

            int[] input = ConvertStringOfIntsToArray(Console.ReadLine());
            longest = new int[0];
            FindLongestIncreasingSubset(input, 0, currentSubset, ref longest);

            Console.WriteLine(Border);
            Console.WriteLine("{0,30} | {1,15}", string.Join(" ", input), string.Join(" ", longest));
            Console.WriteLine(Border);
        }

        public static void FindLongestIncreasingSubset(int[] array, int startIndex, List<int> currentSubset, ref int[] longest)
        {
            if (currentSubset.Count > 1 && currentSubset[currentSubset.Count - 2] > currentSubset[currentSubset.Count - 1])
            {
                return;
            }

            if (currentSubset.Count >= longest.Length)
            {
                longest = new int[currentSubset.Count];
                currentSubset.CopyTo(longest);
            }

            for (int i = startIndex; i < array.Length; i++)
            {
                currentSubset.Add(array[i]);
                FindLongestIncreasingSubset(array, i + 1, currentSubset, ref longest);
                currentSubset.RemoveAt(currentSubset.Count - 1);
            }
        }

        private static int[] ConvertStringOfIntsToArray(string text)
        {
            return Array.ConvertAll(text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
        }
    }
}
