namespace MinMaxSumAverageOfNNumbers
{
    using System;

    /// <summary>
    /// Problem 3. Min, Max, Sum and Average of N Numbers
    /// Write a program that reads from the console a sequence of `n` integer numbers and returns the minimal, the maximal number, the sum and the average of all numbers (displayed with 2 digits after the decimal point).
    /// The input starts by the number `n` (alone in a line) followed by `n` lines, each holding an integer number.
    /// The output is like in the examples below.
    /// Example 1:
    /// | input | output     |
    /// |-------|------------|
    /// | 3     | min = 1    |
    /// | 2     | max = 5    |
    /// | 5     | sum = 8    |
    /// | 1     | avg = 2.67 |
    /// Example 2:
    /// | input | output     |
    /// |-------|------------|
    /// | 2     | min = -1   |
    /// | -1    | max = 4    |
    /// | 4     | sum = 3    |
    /// |       | avg = 1.50 |
    /// </summary>
    public class MinMaxSumAverageOfNNumbers
    {
        public static void Main()
        {
            Console.WriteLine("Problem 3. Min, Max, Sum and Average of N Numbers \nWrite a program that reads from the console a sequence of `n` integer numbers and returns the minimal, the maximal number, the sum and the average of all numbers (displayed with 2 digits after the decimal point). The input starts by the number `n` (alone in a line) followed by `n` lines, each holding an integer number.\n");

            // Read input numbers from the console and add them to an array
            Console.WriteLine("Please enter a positive integer N for sequence length:");

            int n;
            if (!int.TryParse(Console.ReadLine(), out n) || n < 1)
            {
                Console.WriteLine("Input not in the correct format.");
                return;
            }

           // Console.WriteLine("Please, enter {0} numbers:", n);

            // Add all numbers into an array
            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                // Console.Write("{0}: ", i + 1);
                numbers[i] = int.Parse(Console.ReadLine());
            }

            // Find the maximal and minimal integer from the sequence
            int max = int.MinValue;
            int min = int.MaxValue;
            long sum = 0;           

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }

                if (numbers[i] < min)
                {
                    min = numbers[i];
                }

                sum += numbers[i];
            }

            double avg = sum / n;

            Console.WriteLine("min = {0}", min);
            Console.WriteLine("max = {0}", max);
            Console.WriteLine("sum = {0}", sum);
            Console.WriteLine("avg = {0}", avg);
        }
    }
}
