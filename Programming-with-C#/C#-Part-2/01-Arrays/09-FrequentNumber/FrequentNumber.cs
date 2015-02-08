namespace FrequentNumber
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Problem 9. Frequent number
    /// Write a program that finds the most frequent number in an array.
    /// Example:
    /// |                  input                |    result   |
    /// |---------------------------------------|-------------|
    /// | **4**, 1, 1, **4**, 2, 3, **4**, **4**, 1, 2, **4**, 9, 3 | 4 (5 times) |
    /// </summary>
    public class FrequentNumber
    {
        private static readonly string Border = new string('-', 60);

        public static void Main()
        {
            Console.WriteLine("Problem 9. Frequent number \nWrite a program that finds the most frequent number in an array.");

            Console.WriteLine("Example:");
            int[] array = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };
            KeyValuePair<int, int> mostFrequent = GetMostFrequentNumber(array);

            Console.WriteLine(Border);
            Console.WriteLine("{0,30} | {1,15}", "input", "result");
            Console.WriteLine("{0,30} | {1} ({2} times)", string.Join(" ", array), mostFrequent.Key, mostFrequent.Value);
            Console.WriteLine(Border);

            // test with your input
            Console.Write("Try it yourself! \nEnter a sequence of integer numbers separated by space: ");

            int[] input = ConvertStringOfIntsToArray(Console.ReadLine());
            KeyValuePair<int, int> result = GetMostFrequentNumber(input);

            Console.WriteLine(Border);
            Console.WriteLine("{0,30} | {1} ({2} times)", string.Join(" ", input), result.Key, result.Value);
            Console.WriteLine(Border);
        }

        public static KeyValuePair<int, int> GetMostFrequentNumber(int[] array)
        {
            int[] sorted = (int[])array.Clone();
            Array.Sort(sorted);

            int currentElement = array[0];
            int mostFrequent = currentElement;
            int count = 1;
            int maxCount = 1;

            for (int i = 1; i < sorted.Length; i++)
            {
                if (sorted[i] == currentElement)
                {
                    count++;

                    if (count > maxCount)
                    {
                        maxCount = count;
                        mostFrequent = currentElement;
                    }
                }
                else
                {
                    count = 1;
                    currentElement = sorted[i];
                }
            }

            return new KeyValuePair<int, int>(mostFrequent, maxCount);
        }

        private static int[] ConvertStringOfIntsToArray(string text)
        {
            return Array.ConvertAll(text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
        }
    }
}
