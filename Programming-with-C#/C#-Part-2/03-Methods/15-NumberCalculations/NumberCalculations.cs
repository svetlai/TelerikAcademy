namespace NumberCalculations
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// Problem 15.* Number calculations
    /// Modify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.)
    /// Use generic method (read in Internet about generic methods in C#).
    /// </summary>
    public class NumberCalculations
    {
        private static readonly string Border = new string('-', 60);

        public static void Main()
        {
            Console.WriteLine("Problem 15.* Number calculations \nModify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.) \nUse generic method (read in Internet about generic methods in C#).");

            Thread.CurrentThread.CurrentCulture = CultureInfo.InstalledUICulture;

            Console.WriteLine("Example: ");
            Console.WriteLine(Border);
            Console.WriteLine("Input double: {1,-30} | Minimum: {0} ", FindMinimum<double>(1.5, 2.3, 3, 4), "1.5, 2.3, 3, 4");
            Console.WriteLine("Input byte: {1,-30}   | Maximum: {0}", FindMaximum<byte>(5, 2, 4), "5, 2, 4");
            Console.WriteLine("Input float: {1,-30}  | Average: {0}", FindAverage<float>(8f, 6.2f, 3f, 8f, 2f, 7f), "8f, 6.2f, 3f, 8f, 2f, 7f");
            Console.WriteLine("Input decimal: {1,-30}| Sum: {0}", FindSum<decimal>(6.3m, 2.1m, 8m, 2m, 5m), "6.3m, 2.1m, 8m, 2m, 5m");
            Console.WriteLine("Input int: {1,-30}    | Product: {0}", FindProduct<int>(1, 3, 5), "1, 6, 3, 5, 2, 7");
            Console.WriteLine(Border);

            // test with your input
            Console.Write("Try it yourself! \nEnter a sequence of integer numbers separated by space: ");
            int[] input = ConvertStringOfIntsToArray(Console.ReadLine());

            Console.WriteLine(Border);
            Console.WriteLine("Input: {1,-30} | Minimum: {0} ", FindMinimum(input), string.Join(", ", input));
            Console.WriteLine("Input: {1,-30} | Maximum: {0}", FindMaximum(input), string.Join(", ", input));
            Console.WriteLine("Input: {1,-30} | Average: {0}", FindAverage(input), string.Join(", ", input));
            Console.WriteLine("Input: {1,-30} | Sum: {0}", FindSum(input), string.Join(", ", input));
            Console.WriteLine("Input: {1,-30} | Product: {0}", FindProduct(input), string.Join(", ", input));
            Console.WriteLine(Border);
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
    }
}
