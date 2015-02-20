namespace SumIntegers
{
    using System;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Problem 6. Sum integers
    /// You are given a sequence of positive integer values written into a string, separated by spaces.
    /// Write a function that reads these values from given string and calculates their sum.
    /// Example:
    /// |      input       | output |
    /// |------------------|:------:|
    /// | "43 68 9 23 318" | 461    |
    /// </summary>
    public class SumIntegers
    {
        public static void Main()
        {
            string input = "43 68 9 23 318";
            int[] inputAsArray = ConvertStringOfIntsToArray(input);
            long sum = SumSet(inputAsArray);

            DisplayExample(input, inputAsArray, sum);
        }

        public static int[] ConvertStringOfIntsToArray(string text)
        {
            return Array.ConvertAll(text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
        }

        public static long SumSet(int[] set)
        {
            return set.Sum();
        }

        private static void DisplayExample(string input, int[] inputAsArray, long sum)
        {
            StringBuilder print = new StringBuilder();
            string border = new string('-', 60);

            print.AppendLine(" Problem 6. Sum integers \nYou are given a sequence of positive integer values written into a string, separated by spaces. \nWrite a function that reads these values from given string and calculates their sum.\n");

            // print
            print.AppendLine("Example:")
                .AppendLine(border)
                .AppendLine(string.Format("{0,30} | {1,10}", "input", "result"))
                .AppendLine(string.Format("{0,30} | {1,10}", input, sum))
                .AppendLine(border);

            Console.WriteLine(print.ToString());

            // test with your input
            Console.Write("Try it yourself! \nEnter a sequence of integer numbers separated by space: ");

            input = Console.ReadLine();
            inputAsArray = ConvertStringOfIntsToArray(input);
            sum = SumSet(inputAsArray);

            // print
            print.Clear()
                .AppendLine(border)
                .AppendLine(string.Format("{0,30} | {1,10}", input, sum))
                .AppendLine(border);

            Console.WriteLine(print.ToString());
        }
    }
}
