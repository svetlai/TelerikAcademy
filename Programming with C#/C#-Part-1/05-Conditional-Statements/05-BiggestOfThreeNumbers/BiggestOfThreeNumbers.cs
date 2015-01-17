namespace BiggestOfThreeNumbers
{
    using System;
    using System.Globalization;
    using System.Threading;

    /// <summary>
    /// Problem 5. The Biggest of 3 Numbers
    /// Write a program that finds the biggest of three numbers.
    /// Examples:
    /// | a    | b    | c    | biggest |
    /// |------|------|------|:-------:|
    /// | 5    | 2    | 2    | 5       |
    /// | -2   | -2   | 1    | 1       |
    /// | -2   | 4    | 3    | 4       |
    /// | 0    | -2.5 | 5    | 5       |
    /// | -0.1 | -0.5 | -1.1 | -0.1    |
    /// </summary>
    public class BiggestOfThreeNumbers
    {
        public static void Main()
        {
            Console.WriteLine("Problem 5. The Biggest of 3 Numbers \nWrite a program that finds the biggest of three numbers.\n");

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // display examples
            double[] numbersA = { 5, -2, -2, 0, -1 };
            double[] numbersB = { 2, -2, 4, -2.5, -0.5 };
            double[] numbersC = { 2, 1, 3, 4, -5.1 };

            string result;

            Console.WriteLine("{0,5} | {1,5} | {2,5} | {3,5}", "a", "b", "c", "result");

            for (int i = 0; i < numbersA.Length && i < numbersB.Length && i < numbersC.Length; i++)
            {
                result = FindBiggestOfThree(numbersA[i], numbersB[i], numbersC[i]);

                Console.WriteLine("{0,5} | {1,5} | {2,5} | {3,5}", numbersA[i], numbersB[i], numbersC[i], result);
            }

            Console.WriteLine();

            // read inputs from the console and make calculations based on them
            Console.WriteLine("Try it yourself!");

            int a = 0;
            int b = 0;
            int c = 0;

            try
            {
                Console.Write("Enter an integer number a: ");
                a = int.Parse(Console.ReadLine());

                Console.Write("Enter a second integer number b: ");
                b = int.Parse(Console.ReadLine());

                Console.Write("Enter a third integer number c: ");
                c = int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            result = FindBiggestOfThree(a, b, c);
            Console.WriteLine("{0,5} | {1,5} | {2,5} | {3,5}", a, b, c, result);
        }

        public static string FindBiggestOfThree(double a, double b, double c)
        {
            if (a >= b)
            {
                if (a > c)
                {
                    if (a == b)
                    {
                        return "a and b are equal";
                    }
                    else
                    {
                        return a.ToString();
                    }
                }
                else if (a == c)
                {
                    if (b == c)
                    {
                        return "a, b and c are equal";
                    }
                    else
                    {
                        return "a and c are equal";
                    }
                }
                else
                {
                    return c.ToString();
                }
            }
            else
            {
                if (b > c)
                {
                    return b.ToString();
                }
                else if (b == c)
                {
                    return "b and c are equal";
                }
                else
                {
                    return c.ToString();
                }
            }
        }
    }
}
