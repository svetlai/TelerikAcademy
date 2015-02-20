namespace FrequentNumber
{
    using System;
    using System.Collections.Generic;
    using System.Text;

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
        public static void Main()
        {
            int[] input = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };
            KeyValuePair<int, int> mostFrequent = GetMostFrequentNumber(input);

            DisplayExample(input, mostFrequent);
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

        private static void DisplayExample(int[] input, KeyValuePair<int, int> mostFrequent)
        {
            StringBuilder print = new StringBuilder();
            string border = new string('-', 60);

            print.AppendLine("Problem 9. Frequent number \nWrite a program that finds the most frequent number in an array.");

            print.AppendLine("Example:")
                .AppendLine(border)
                .AppendLine(string.Format("{0,30} | {1,15}", "input", "result"))
                .AppendLine(string.Format("{0,30} | {1} ({2} times)", string.Join(" ", input), mostFrequent.Key, mostFrequent.Value))
                .AppendLine(border);

            Console.Write(print.ToString());

            // test with your input
            Console.Write("Try it yourself! \nEnter a sequence of integer numbers separated by space: ");

            input = ConvertStringOfIntsToArray(Console.ReadLine());
            mostFrequent = GetMostFrequentNumber(input);

            print.Clear()
                .AppendLine(border)
                .AppendLine(string.Format("{0,30} | {1} ({2} times)", string.Join(" ", input), mostFrequent.Key, mostFrequent.Value))
                .AppendLine(border);

            Console.Write(print.ToString());
        }
    }
}
