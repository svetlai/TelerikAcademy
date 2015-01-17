namespace CalculateNFactorialKFactorial
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Problem 6. Calculate N! / K!
    /// Write a program that calculates n! / k! for given n and k (1 < k < n < 100).
    /// Use only one loop.
    /// Examples:
    /// n	k	n! / k!
    /// 5	2	60
    /// 6	5	6
    /// 8	3	6720
    /// </summary>
    public class CalculateNFactorialKFactorial
    {
        public static void Main()
        {
            Console.WriteLine("Problem 6. Calculate N! / K! \nWrite a program that calculates n! / k! for given n and k (1 < k < n < 100). \nUse only one loop.\n");

            Console.Write("Enter an integer n so that 1 < n < 100: ");

            int n;
            if (!int.TryParse(Console.ReadLine(), out n) || n <= 1 || n >= 100)
            {
                Console.WriteLine("Input not in the correct format or range.");
                return;
            }

            Console.Write("Enter an integer k so that 1 < k < n:");
            
            int k;
            if (!int.TryParse(Console.ReadLine(), out k) || k <= 1 || k > n)
            {
                Console.WriteLine("Input not in the correct format or range.");
                return;
            }

            BigInteger result = CalculateNFactorialKFactorialDivision(n, k);

            // slow way
            // result = CalculateFactorial(n) / CalculateFactorial(k); 

            Console.WriteLine("n!/k! = {0}", result);
        }

        public static BigInteger CalculateNFactorialKFactorialDivision(int n, int k)
        {
            if (n == 0)
            {
                return 1;
            }

            BigInteger result = 1;

            for (int i = n; i > k; i--)
            {
                result *= i;
            }

            return result;
        }

        public static BigInteger CalculateFactorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            BigInteger result = 1;

            for (int i = n; i > 0; i--)
            {
                result *= i;
            }

            return result;
        }
    }
}
