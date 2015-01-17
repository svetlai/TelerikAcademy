namespace CatalanNumbers
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Problem 8. Catalan Numbers
    /// In combinatorics, the Catalan numbers are calculated by the following formula: catalan-formula
    /// Write a program to calculate the nth Catalan number by given n (1 < n < 100).
    /// Examples:
    /// n	Catalan(n)
    /// 0	1
    /// 5	42
    /// 10	16796
    /// 15	9694845
    /// </summary>
    public class CatalanNumbers
    {
        public static void Main()
        {
            Console.WriteLine("Problem 8. Catalan Numbers \nIn combinatorics, the Catalan numbers are calculated by the following formula: catalan-formula \nWrite a program to calculate the nth Catalan number by given n (1 < n < 100).\n");

            Console.Write("Enter an integer n so that 1 < n < 100: ");

            int n;
            if (!int.TryParse(Console.ReadLine(), out n) || n >= 100)
            {
                Console.WriteLine("Input not in the correct format or range.");
                return;
            }

            BigInteger result = CalculateCatalanNumber(n);
            Console.WriteLine(result);
        }

        public static BigInteger CalculateCatalanNumber(int n)
        {
            return CalculateFactorial(2 * n) / (CalculateFactorial(n + 1) * CalculateFactorial(n));
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
