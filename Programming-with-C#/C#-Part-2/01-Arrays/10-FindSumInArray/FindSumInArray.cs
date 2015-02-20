namespace FindSumInArray
{
    using System;
    using System.Linq;
    using System.Text;

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

        public static void Main()
        {
            int[] input = { 4, 3, 1, 4, 2, 5, 8 };
            int sum = 11;
            int[] sequence = FindSequenceOfSumS(input, sum);

            DisplayExample(input, sum, sequence);
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

        private static void DisplayExample(int[] input, int sum, int[] sequence)
        {
            StringBuilder print = new StringBuilder();
            string border = new string('-', 60);

            print.AppendLine("Problem 10. Find sum in array \nWrite a program that finds in given array of integers a sequence of given sum `S` (if present).");

            // display examples
            print.AppendLine("Example: ")
                .AppendLine(border)
                .AppendLine(string.Format("{0,30} | {1,15}", "input", "result"))
                .AppendLine(string.Format("{0,30} | {1,15}", string.Join(" ", input), string.Join(" ", sequence)))
                .AppendLine(border);

            Console.Write(print.ToString());

            // test with your input
            Console.Write("Try it yourself! \nEnter a sequence of integer numbers separated by space: ");
            input = ConvertStringOfIntsToArray(Console.ReadLine());

            Console.Write("Enter target sum S: ");
            int s;
            if (!int.TryParse(Console.ReadLine(), out s))
            {
                Console.WriteLine(FormatException);
            }

            int[] result = FindSequenceOfSumS(input, s);

            print.Clear()
                .AppendLine(border);

            if (result != null)
            {
                print.AppendLine(string.Format("{0,30} | {1,15}", string.Join(" ", input), string.Join(" ", result)));
            }
            else
            {
                print.AppendLine(string.Format("{0,30} | {1,15}", string.Join(" ", input), "No sequence found."));
            }

            print.AppendLine(border);

            Console.Write(print.ToString());
        }
    }
}
