namespace PrintStatistics
{
    using System;

    public class Statistics
    {
        public static void Main()
        {
            double[] numbers = new double[]
            {
                1, 2, 3
            };

            int count = numbers.Length;

            PrintStatistics(numbers, count);
        }

        public static void PrintStatistics(double[] numbers, int count)
        {
            double maxValue = GetMax(numbers, count);
            PrintMax(maxValue);

            double minValue = GetMin(numbers, count);
            PrintMin(minValue);

            double sum = GetSum(numbers, count);
            PrintAverage(sum / count);
        }

        private static double GetMax(double[] numbers, int count)
        {
            double maxValue = 0;

            for (int i = 0; i < count; i++)
            {
                if (numbers[i] > maxValue)
                {
                    maxValue = numbers[i];
                }
            }

            return maxValue;
        }

        private static double GetMin(double[] numbers, int count)
        {
            double minValue = 0;

            for (int i = 0; i < count; i++)
            {
                if (numbers[i] < minValue)
                {
                    minValue = numbers[i];
                }
            }

            return minValue;
        }

        private static double GetSum(double[] numbers, int count)
        {
            double sum = 0;

            for (int i = 0; i < count; i++)
            {
                sum += numbers[i];
            }

            return sum;
        }

        private static void PrintMax(double number)
        {
            Console.WriteLine("Maximum number is {0}", number);
        }

        private static void PrintMin(double number)
        {
            Console.WriteLine("Minimum number is {0}", number);
        }

        private static void PrintAverage(double number)
        {
            Console.WriteLine("Sum is {0}", number);
        }
    }
}
