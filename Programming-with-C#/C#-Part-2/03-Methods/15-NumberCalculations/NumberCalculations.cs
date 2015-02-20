namespace NumberCalculations
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading;

    /// <summary>
    /// Problem 15.* Number calculations
    /// Modify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.)
    /// Use generic method (read in Internet about generic methods in C#).
    /// </summary>
    public class NumberCalculations
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InstalledUICulture;

            double min = FindMinimum<double>(1.5, 2.3, 3, 4);
            byte max = FindMaximum<byte>(5, 2, 4);
            float average = FindAverage<float>(8f, 6.2f, 3f, 8f, 2f, 7f);
            decimal sum = FindSum<decimal>(6.3m, 2.1m, 8m, 2m, 5m);
            int product = FindProduct<int>(1, 3, 5);

            DisplayExample(min, max, average, sum, product);
        }

        public static T FindMinimum<T>(params T[] input) where T : IComparable
        {
            return input.Min();
        }

        public static T FindMaximum<T>(params T[] input) where T : IComparable
        {
            return input.Max();
        }

        public static T FindAverage<T>(params T[] input) where T : IComparable
        {
            dynamic sum = default(T);

            for (int i = 0; i < input.Length; i++)
            {
                sum += input[i];
            }

            return sum / input.Length;
        }

        public static T FindSum<T>(params T[] input) where T : IComparable
        {
            dynamic sum = default(T);

            for (int i = 0; i < input.Length; i++)
            {
                sum += input[i];
            }

            return sum;
        }

        public static T FindProduct<T>(params T[] input) where T : IComparable<T>
        {
            dynamic result = 1;

            for (int i = 0; i < input.Length; i++)
            {
                result *= input[i];
            }

            return result;
        }

        private static int[] ConvertStringOfIntsToArray(string text)
        {
            return Array.ConvertAll(text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
        }

        private static void DisplayExample(double min, byte max, float average, decimal sum, int product)
        {
            StringBuilder print = new StringBuilder();
            string border = new string('-', 60);

            print.AppendLine("Problem 15.* Number calculations \nModify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.) \nUse generic method (read in Internet about generic methods in C#).");

            print.AppendLine("Problem 14. Integer calculations \nWrite methods to calculate `minimum`, `maximum`, `average`, `sum` and `product` of given set of integer numbers. \nUse variable number of arguments.")
                .AppendLine("Example: ")
                .AppendLine(border)
                .AppendLine(string.Format("Input double: {1,-30} | Minimum: {0} ", min, "1.5, 2.3, 3, 4"))
                .AppendLine(string.Format("Input byte: {1,-30}   | Maximum: {0}", max, "5, 2, 4"))
                .AppendLine(string.Format("Input float: {1,-30}  | Average: {0}", average, "8f, 6.2f, 3f, 8f, 2f, 7f"))
                .AppendLine(string.Format("Input decimal: {1,-30}| Sum: {0}", sum, "6.3m, 2.1m, 8m, 2m, 5m"))
                .AppendLine(string.Format("Input int: {1,-30}    | Product: {0}", product, "1, 6, 3, 5, 2, 7"))
                .AppendLine(border);

            Console.WriteLine(print.ToString());

            // test with your input
            Console.Write("Try it yourself! \nEnter a sequence of integer numbers separated by space: ");
            int[] input = ConvertStringOfIntsToArray(Console.ReadLine());

            print.Clear()
                .AppendLine(border)
                .AppendLine(string.Format("Input: {1,-30} | Minimum: {0} ", FindMinimum(input), string.Join(", ", input)))
                .AppendLine(string.Format("Input: {1,-30} | Maximum: {0}", FindMaximum(input), string.Join(", ", input)))
                .AppendLine(string.Format("Input: {1,-30} | Average: {0}", FindAverage(input), string.Join(", ", input)))
                .AppendLine(string.Format("Input: {1,-30} | Sum: {0}", FindSum(input), string.Join(", ", input)))
                .AppendLine(string.Format("Input: {1,-30} | Product: {0}", FindProduct(input), string.Join(", ", input)))
                .AppendLine(border);

            Console.WriteLine(print.ToString());
        }
    }
}
