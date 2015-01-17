namespace CalculateSequenceSum
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Problem 5. Calculate 1 + 1!/X + 2!/X2 + ... + N!/XN
    /// Write a program that, for a given two integer numbers `n` and `x`, calculates the sum `S = 1 + 1!/x + 2!/x2 + ... + n!/xn`.
    /// Use only one loop. Print the result with `5` digits after the decimal point.
    /// Examples:
    /// | n           | x          | S       |
    /// |-------------|------------|---------|
    /// | 3           | 2          | 2.75000 |
    /// | 4           | 3          | 2.07407 |
    /// | 5           | -4         | 0.75781 |
    /// </summary>
    public class CalculateSequenceSum
    {
        public static void Main()
        {
            Console.WriteLine("Problem 5. Calculate 1 + 1!/X + 2!/X2 + ... + N!/XN \nWrite a program that, for a given two integer numbers `n` and `x`, calculates the sum `S = 1 + 1!/x + 2!/x2 + ... + n!/xn`. \nUse only one loop. Print the result with `5` digits after the decimal point.\n");

            Console.Write("Enter an integer N: ");

            int n;
            if (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Input not in the correct format or range.");
                return;
            }

            Console.Write("Enter an integer X: ");

            int x;
            if (!int.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Input not in the correct format or range.");
                return;
            }

            BigInteger result = 1;
            double sum = 1;

            // using one loop
            for (int i = 1; i <= n; i++)
            {
                result *= i;
                sum += (double)result / Math.Pow(x, i);
            }

            // using a method for calculating factorial
            // for (int i = 1; i <= n; i++)
            // {
            //     sum += CalculateFactorial(i) / Math.Pow(x, i);
            // }

            Console.WriteLine("Sum: {0:F5}", sum);
        }

        // using loops
        public static BigInteger CalculateFactorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            BigInteger result = 1;

            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }

        // recursive
        // public static long CalculateFactorial(int n)
        // {
        //     if (n == 0)
        //     {
        //         return 1;
        //     }
           
        //     return n * CalculateFactorial(n - 1);
        // }
    }
}
