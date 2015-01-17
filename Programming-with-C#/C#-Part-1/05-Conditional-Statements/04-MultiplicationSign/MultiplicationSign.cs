namespace MultiplicationSign
{
    using System;
    using System.Globalization;
    using System.Threading;

    /// <summary>
    /// Problem 4. Multiplication Sign
    /// Write a program that shows the sign (+, - or 0) of the product of three real numbers, without calculating it.
    /// Use a sequence of `if` operators.
    /// Examples:
    /// | a    | b    | c    | result |
    /// |------|------|------|:------:|
    /// | 5    | 2    | 2    | +      |
    /// | -2   | -2   | 1    | +      |
    /// | -2   | 4    | 3    | -      |
    /// | 0    | -2.5 | 4    | 0      |
    /// | -1   | -0.5 | -5.1 | -      |
    /// </summary>
    public class MultiplicationSign
    {
        public static void Main()
        {
            Console.WriteLine("Problem 4. Multiplication Sign \nWrite a program that shows the sign (+, - or 0) of the product of three real numbers, without calculating it. Use a sequence of `if` operators.\n");

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // display examples
            double[] numbersA = { 5, -2, -2, 0, -1 };
            double[] numbersB = { 2, -2, 4, -2.5, -0.5 };
            double[] numbersC = { 2, 1, 3, 4, -5.1 };

            string result;

            Console.WriteLine("{0,5} | {1,5} | {2,5} | {3,5}", "a", "b", "c", "result");

            for (int i = 0; i < numbersA.Length && i < numbersB.Length && i < numbersC.Length; i++)
            {
                result = CheckMultiplicationSign(numbersA[i], numbersB[i], numbersC[i]);

                Console.WriteLine("{0,5} | {1,5} | {2,5} | {3,5}", numbersA[i], numbersB[i], numbersC[i], result);
            }

            Console.WriteLine();

            // read inputs from the console and make calculations based on them
            Console.WriteLine("Try it yourself!");

            double a = 0;
            double b = 0;
            double c = 0;

            try
            {
                Console.Write("Enter an integer number a: ");
                a = double.Parse(Console.ReadLine());

                Console.Write("Enter a second integer number b: ");
                b = double.Parse(Console.ReadLine());

                Console.Write("Enter a third integer number c: ");
                c = double.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            result = CheckMultiplicationSign(a, b, c);
            Console.WriteLine("{0,5} | {1,5} | {2,5} | {3,5}", a, b, c, result);
        }

        public static string CheckMultiplicationSign(double a, double b, double c)
        {
            if (a == 0 || b == 0 || c == 0)
            {
                return "0";
            }

            bool negative = (a < 0 && b > 0 && c > 0)
               || (a > 0 && b < 0 && c > 0)
               || (a > 0 && b > 0 && c < 0);

            if (negative)
            {
                return "-";
            }
            else
            {
                return "+";
            }
        }
    }
}
