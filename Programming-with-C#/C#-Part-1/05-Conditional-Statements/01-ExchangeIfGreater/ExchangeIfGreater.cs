namespace ExchangeIfGreater
{
    using System;

    /// <summary>
    /// Problem 1. Exchange If Greater
    /// Write an if-statement that takes two double variables a and b and exchanges their values if the first one is greater than the second one. As a result print the values a and b, separated by a space.
    /// Examples:
    /// | a    | b   | result  |
    /// |------|-----|---------|
    /// | 5    | 2   | 2 5     |
    /// | 3    | 4   | 3 4     |
    /// | 5.5  | 4.5 | 4.5 5.5 |
    /// </summary>
    public class ExchangeIfGreater
    {
        private const string FormatExceptionMessage = "Input not in the correct format.";

        public static void Main()
        {
            Console.WriteLine("Problem 1. Exchange If Greater \nWrite an if-statement that takes two double variables a and b and exchanges their values if the first one is greater than the second one. As a result print the values a and b, separated by a space.\n");

            // display examples
            double[] numbersA = { 5, 3, 5, 5 };
            double[] numbersB = { 2, 4, 4.5 };

            Console.WriteLine("{0,5} | {1,5} | {2,10}", "a", "b", "result");

            for (int i = 0; i < numbersA.Length && i < numbersB.Length; i++)
            {
                Console.Write("{0,5} | {1,5} | ", numbersA[i], numbersB[i]);

                if (numbersA[i] > numbersB[i])
                {
                    double temp = numbersA[i];
                    numbersA[i] = numbersB[i];
                    numbersB[i] = temp;
                }

                Console.WriteLine("{0,5} {1,5}", numbersA[i], numbersB[i]);
            }

            Console.WriteLine();

            // read inputs from the console and make calculations based on them
            Console.WriteLine("Try it yourself!");

            Console.Write("Enter an integer number a: ");
            double a;

            if (!double.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine(FormatExceptionMessage); // throw new FormatException(formatExceptionMessage);
                return;
            }

            Console.Write("Enter a second integer number b: ");
            double b;

            if (!double.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine(FormatExceptionMessage); // throw new FormatException(formatExceptionMessage);
                return;
            }

            Console.Write("{0,5} | {1,5} | ", a, b);

            if (a > b)
            {
                double temp = a;
                a = b;
                b = temp;
            }

            Console.WriteLine("{0,5} {1,5}", a, b);
        }
    }
}
