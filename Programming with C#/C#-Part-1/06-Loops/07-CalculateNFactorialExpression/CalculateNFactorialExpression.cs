namespace CalculateNFactorialExpression
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Problem 7. Calculate N! / (K! * (N-K)!)
    /// In combinatorics, the number of ways to choose k different members out of a group of n different elements (also known as the number of combinations) is calculated by the following formula: formula For example, there are 2598960 ways to withdraw 5 cards out of a standard deck of 52 cards.
    /// Your task is to write a program that calculates n! / (k! * (n-k)!) for given n and k (1 < k < n < 100). Try to use only two loops.
    /// Examples:
    /// n	k	n! / (k! * (n-k)!)
    /// 3	2	3
    /// 4	2	6
    /// 10	6	210
    /// 52	5	2598960
    /// </summary>
    public class CalculateNFactorialExpression
    {
        public static void Main()
        {
            Console.WriteLine("Problem 7. Calculate N! / (K! * (N-K)!) \nIn combinatorics, the number of ways to choose k different members out of a group of n different elements (also known as the number of combinations) is calculated by the following formula: formula For example, there are 2598960 ways to withdraw 5 cards out of a standard deck of 52 cards. \nYour task is to write a program that calculates n! / (k! * (n-k)!) for given n and k (1 < k < n < 100). Try to use only two loops.\n");

            Console.Write("Enter an integer n so that 1 < n < 100: ");

            int n;
            if (!int.TryParse(Console.ReadLine(), out n) || n <= 1 || n >= 100)
            {
                Console.WriteLine("Input not in the correct format or range.");
                return;
            }

            Console.Write("Enter an integer k so that 1 < k < n: ");

            int k;
            if (!int.TryParse(Console.ReadLine(), out k) || k <= 1 || k >= n)
            {
                Console.WriteLine("Input not in the correct format or range.");
                return;
            }

            BigInteger numerator = 1;
            BigInteger denominator = 1;

            if (k > n - k)
            {
                for (int i = n; i > k; i--)
                {
                    numerator *= i;
                }

                for (int i = n - k; i > 0; i--)
                {
                    denominator *= i;
                }
            }
            else
            {
                for (int i = n; i > n - k; i--)
                {
                    numerator *= i;
                }

                for (int i = k; i > 0; i--)
                {
                    denominator *= i;
                }
            }

            BigInteger result = numerator / denominator;

            // slower way
            //result = CalculateFactorial(n) / (CalculateFactorial(k) * CalculateFactorial(n - k));

            Console.WriteLine("n! / (k! * (n-k)!) = {0}", result);
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
