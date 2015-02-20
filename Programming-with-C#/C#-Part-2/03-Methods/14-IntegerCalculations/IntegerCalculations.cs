namespace IntegerCalculations
{
    using System;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Problem 14. Integer calculations
    /// Write methods to calculate `minimum`, `maximum`, `average`, `sum` and `product` of given set of integer numbers.
    /// Use variable number of arguments.
    /// </summary>
    public class IntegerCalculations
    {
        public static void Main()
        {
            int min = FindMinimum(1, 2, 3, 4);
            int max = FindMaximum(5, 2, 4);
            int average = FindAverage(8, 6, 3, 8, 2, 7);
            int sum = FindSum(6, 2, 8, 2, 5);
            long product = FindProduct(1, 6, 3, 5, 2, 7);

            DisplayExample(min, max, average, sum, product);
        }

        public static int FindMinimum(params int[] numbers)
        {
            return numbers.Min();
        }

        public static int FindMaximum(params int[] numbers)
        {
            return numbers.Max();
        }

        public static int FindAverage(params int[] numbers)
        {
            return (int)numbers.Average();
        }

        public static int FindSum(params int[] numbers)
        {
            return numbers.Sum();
        }

        public static long FindProduct(params int[] numbers)
        {
            long result = 1;
            for (int i = 0; i < numbers.Length; i++)
            {
                result *= numbers[i];
            }

            return result;
        }

        private static int[] ConvertStringOfIntsToArray(string text)
        {
            return Array.ConvertAll(text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
        }

        private static void DisplayExample(int min, int max, int average, int sum, long product)
        {
            StringBuilder print = new StringBuilder();
            string border = new string('-', 60);

            print.AppendLine("Problem 14. Integer calculations \nWrite methods to calculate `minimum`, `maximum`, `average`, `sum` and `product` of given set of integer numbers. \nUse variable number of arguments.")
                .AppendLine("Example: ")
                .AppendLine(border)
                .AppendLine(string.Format("Input: {1,-30} | Minimum: {0} ", min, "1, 2, 3, 4"))
                .AppendLine(string.Format("Input: {1,-30} | Maximum: {0}", max, "5, 2, 4"))
                .AppendLine(string.Format("Input: {1,-30} | Average: {0}", average, "8, 6, 3, 8, 2, 7"))
                .AppendLine(string.Format("Input: {1,-30} | Sum: {0}", sum, "6, 2, 8, 2, 5"))
                .AppendLine(string.Format("Input: {1,-30} | Product: {0}", product, "1, 6, 3, 5, 2, 7"))
                .AppendLine(border);

            Console.WriteLine(print.ToString());

            // test with your input
            Console.Write("Try it yourself! \nEnter a sequence of integer numbers separated by space: ");
            int[] input = ConvertStringOfIntsToArray(Console.ReadLine());

            min = FindMinimum(input);
            max = FindMaximum(input);
            average = FindAverage(input);
            sum = FindSum(input);
            product = FindProduct(input);

            print.Clear()
                .AppendLine(border)
                .AppendLine(string.Format("Input: {1,-30} | Minimum: {0} ", min, string.Join(", ", input)))
                .AppendLine(string.Format("Input: {1,-30} | Maximum: {0}", max, string.Join(", ", input)))
                .AppendLine(string.Format("Input: {1,-30} | Average: {0}", average, string.Join(", ", input)))
                .AppendLine(string.Format("Input: {1,-30} | Sum: {0}", sum, string.Join(", ", input)))
                .AppendLine(string.Format("Input: {1,-30} | Product: {0}", product, string.Join(", ", input)))
                .AppendLine(border);

            Console.WriteLine(print.ToString());
        }
    }
}
