namespace FindSumInArray
{
    using System;
    using System.Linq;

    /// <summary>
    /// Problem 10. Find sum in array
    /// Write a program that finds in given array of integers a sequence of given sum `S` (if present).
    /// Example:
    /// |        array        |  S |  result |
    /// |---------------------|----|---------|
    /// | 4, 3, 1, **4, 2, 5**, 8 | 11 | 4, 2, 5 |
    /// </summary>
    public class FindSumInArray
    {
        private const string FormatException = "Input not in the correct format.";
        private static readonly string Border = new string('-', 60);

        public static void Main()
        {
            Console.WriteLine("Problem 10. Find sum in array \nWrite a program that finds in given array of integers a sequence of given sum `S` (if present).");

            // display examples
            Console.WriteLine("Example: ");
            int[] array = { 4, 3, 1, 4, 2, 5, 8 };
            int sum = 11;
            int[] sequence = FindSequenceOfSumS(array, sum);

            Console.WriteLine(Border);
            Console.WriteLine("{0,30} | {1,15}", "input", "result");
            Console.WriteLine("{0,30} | {1,15}", string.Join(" ", array), string.Join(" ", sequence));
            Console.WriteLine(Border);

            // test with your input
            Console.Write("Try it yourself! \nEnter a sequence of integer numbers separated by space: ");
            int[] input = ConvertStringOfIntsToArray(Console.ReadLine());

            Console.Write("Enter target sum S: ");
            int s;
            if (!int.TryParse(Console.ReadLine(), out s))
            {
                Console.WriteLine(FormatException);
            }

            int[] result = FindSequenceOfSumS(input, s);

            Console.WriteLine(Border);

            if (result != null)
            {
                Console.WriteLine("{0,30} | {1,15}", string.Join(" ", input), string.Join(" ", result));
            }
            else
            {
                Console.WriteLine("{0,30} | {1,15}", string.Join(" ", input), "No sequence found.");
            }

            Console.WriteLine(Border);
        }

        public static int[] FindSequenceOfSumS(int[] array, int sum)
        {
            int startIndex = 0;
            int endIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int currentSum = array[i];
                startIndex = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (currentSum == sum)
                    {
                        endIndex = j - 1;
                        int[] sequence = array.Skip(startIndex).Take(endIndex - startIndex + 1).ToArray();

                        return sequence;
                    }

                    currentSum += array[j];
                }
            }

            return null;
        }

        private static int[] ConvertStringOfIntsToArray(string text)
        {
            return Array.ConvertAll(text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
        }
    }
}
