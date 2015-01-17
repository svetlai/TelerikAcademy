namespace TrailingZeroesInNFactorial
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Problem 18.* Trailing Zeroes in N!
    /// Write a program that calculates with how many zeroes the factorial of a given number n has at its end.
    /// Your program should work well for very big numbers, e.g. n=100000.
    /// Examples:
    /// n	trailing zeroes of n!	explaination
    /// 10	    2	                3628800
    /// 20	    4	                2432902008176640000
    /// 100000  24999	            think why
    /// </summary>
    public class TrailingZeroesInNFactorial
    {
        public static void Main()
        {
            Console.WriteLine("Problem 18.* Trailing Zeroes in N! \nWrite a program that calculates with how many zeroes the factorial of a given number n has at its end. \nYour program should work well for very big numbers, e.g. n=100000.\n");

            Console.Write("Please enter an integer number n: ");

            int n;
            if (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Input not in the correct format.");
                return;
            }

            // fast way - find the number of factors 5 in n! and since there are at least as much factors 2, this equivalents to the number of factors 10, each of which gives one more zero
            int zerosCount = CountTrailingZeroes(n);

            // slow way
            //BigInteger nFactorial = CalculateFactorial(n);

            //while (nFactorial % 10 == 0)
            //{
            //    zerosCount++;
            //    nFactorial = nFactorial / 10;
            //}

            Console.WriteLine("{0}! --> trailing zeroes : {1}", n, zerosCount);
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

        public static int CountTrailingZeroes(int n)
        {
            int zerosCount = 0;

            while (n > 0)
            {
                n = n / 5;
                zerosCount += n;
            }

            return zerosCount;
        }
    }
}
