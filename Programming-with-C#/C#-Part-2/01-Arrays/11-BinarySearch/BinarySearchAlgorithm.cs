namespace BinarySearch
{
    using System;

    /// <summary>
    /// Problem 11. Binary search
    /// Write a program that finds the index of given element in a sorted array of integers by using the [Binary search](http://en.wikipedia.org/wiki/Binary_search_algorithm) algorithm.
    /// </summary>
    public class BinarySearchAlgorithm
    {
        private const string FormatExceptionMessage = "Input not in the correct format.";
        private static readonly string Border = new string('-', 60);

        public static void Main()
        {
            Console.WriteLine("Problem 11. Binary search \nWrite a program that finds the index of given element in a sorted array of integers by using the [Binary search](http://en.wikipedia.org/wiki/Binary_search_algorithm) algorithm.\n");

            Console.Write("Enter a sequence of integer numbers separated by space: ");

            int[] input = ConvertStringOfIntsToArray(Console.ReadLine());
            
            Console.Write("Enter a number to search for: ");

            int value;
            if (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine(FormatExceptionMessage);
            }

            int foundIndex = BinarySearch(input, value);
            string found = foundIndex > -1 ? foundIndex.ToString() : "not found";

            Console.WriteLine(Border);
            Console.WriteLine("{0,30} | {1,3}", "input", "found at index:");
            Console.WriteLine("{0,30} | {1,3}", string.Join(" ", input), found);
            Console.WriteLine(Border);
        }

        /// <summary>
        /// Binary search finds item in sorted array and returns index (zero based) of item. If item is not found returns -1.
        /// </summary>
        /// <param name="array">A sorted array of integers to search in</param>
        /// <param name="value">Searched value</param>
        /// <returns>The index of the value if found; -1 if not</returns>
        public static int BinarySearch(int[] array, int value)
        {
            int low = 0;
            int high = array.Length - 1;
            int midpoint = 0;

            while (low <= high)
            {
                midpoint = low + ((high - low) / 2);

                // check to see if value is equal to item in array
                if (value == array[midpoint])
                {
                    return midpoint;
                }
                else if (value < array[midpoint])
                {
                    high = midpoint - 1;
                }
                else
                {
                    low = midpoint + 1;
                }
            }

            // item was not found
            return -1;
        }

        private static int[] ConvertStringOfIntsToArray(string text)
        {
            return Array.ConvertAll(text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
        }
    }
}
