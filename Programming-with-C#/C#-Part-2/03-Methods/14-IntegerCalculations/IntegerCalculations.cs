namespace IntegerCalculations
{
    using System;
    using System.Linq;

    /// <summary>
    /// Problem 14. Integer calculations
    /// Write methods to calculate `minimum`, `maximum`, `average`, `sum` and `product` of given set of integer numbers.
    /// Use variable number of arguments.
    /// </summary>
    public class IntegerCalculations
    {
        private static readonly string Border = new string('-', 60);

        public static void Main()
        {
            Console.WriteLine("Problem 14. Integer calculations \nWrite methods to calculate `minimum`, `maximum`, `average`, `sum` and `product` of given set of integer numbers. \nUse variable number of arguments.");
            
            Console.WriteLine("Example: ");
            Console.WriteLine(Border);
            Console.WriteLine("Input: {1,-30} | Minimum: {0} ", FindMinimum(1, 2, 3, 4), "1, 2, 3, 4");
            Console.WriteLine("Input: {1,-30} | Maximum: {0}", FindMaximum(5, 2, 4), "5, 2, 4");
            Console.WriteLine("Input: {1,-30} | Average: {0}", FindAverage(8, 6, 3, 8, 2, 7), "8, 6, 3, 8, 2, 7");
            Console.WriteLine("Input: {1,-30} | Sum: {0}", FindSum(6, 2, 8, 2, 5), "6, 2, 8, 2, 5");
            Console.WriteLine("Input: {1,-30} | Product: {0}", FindProduct(1, 6, 3, 5, 2, 7), "1, 6, 3, 5, 2, 7");
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
    }
}
