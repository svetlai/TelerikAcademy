namespace BiggestOfFiveNumbers
{
    using System;

    /// <summary>
    /// Problem 6. The Biggest of Five Numbers
    /// Write a program that finds the biggest of five numbers by using only five if statements.
    /// Examples:
    /// | a    | b    | c    |  d |   e  | biggest |
    /// |------|------|------|:--:|:----:|---------|
    /// | 5    | 2    | 2    | 4  | 1    | 5       |
    /// | -2   | -22  | 1    | 0  | 0    | 1       |
    /// | -2   | 4    | 3    | 2  | 0    | 4       |
    /// | 0    | -2.5 | 0    | 5  | 5    | 5       |
    /// | -3   | -0.5 | -1.1 | -2 | -0.1 | -0.1    |
    /// </summary>
    public class BiggestOfFiveNumbers
    {
        public static void Main()
        {
            Console.WriteLine("Problem 6. The Biggest of Five Numbers \nWrite a program that finds the biggest of five numbers by using only five if statements.\n");

            double[] numbers = new double[5];

            Console.WriteLine("Enter five numbers:");

            for (int i = 0; i < 5; i++)
            {
                Console.Write("{0}: ", i + 1);
                numbers[i] = double.Parse(Console.ReadLine());
            }

            double max = double.MinValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            Console.WriteLine("Biggest: {0}", max);
        }
    }
}
