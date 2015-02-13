namespace NFactorial
{
    using System;
    using System.Linq;

    /// <summary>
    /// Problem 10. N Factorial
    /// Write a program to calculate `n!` for each `n` in the range [`1..100`].
    /// Hint: Implement first a method that multiplies a number represented as array of digits by given integer number.
    /// </summary>
    public class NFactorial
    {
        private const string InvalidFormatMsg = "Input was not in the correct format: 0 < n <= 100";

        public static void Main()
        {
            Console.WriteLine("Problem 10. N Factorial \nWrite a program to calculate `n!` for each `n` in the range [`1..100`].\n");

            Console.Write("Enter a positive integer number n: ");

            int n;
            if (!int.TryParse(Console.ReadLine(), out n) || n < 1)
            {
                Console.WriteLine(InvalidFormatMsg);
                return;
            }

            long nFactorial = CalculateNFactorial(n);
            Console.WriteLine("Factorial of {0}: {1}", n, nFactorial);
        }

        public static long CalculateNFactorial(int number)
        {
            if (number < 1 || number > 100)
            {
                throw new ArgumentException(InvalidFormatMsg);
            }

            long result = 1;
            char[] digits;

            for (int i = number; i > 0; i--)
            {
                digits = ConvertNumberToArrayOfDigits(i);
                result = MultiplyArrayOfDigitsByNumber(digits, result);
            }

            return result;
        }

        private static long MultiplyArrayOfDigitsByNumber(char[] array, long multiplyBy)
        {
            int[] digits = array.Select(x => x - '0').ToArray();
            long result = 0;

            for (int i = 0; i < digits.Length; i++)
            {
                result += digits[i] * multiplyBy * (long)Math.Pow(10, i);
            }

            return result;
        }

        private static char[] ConvertNumberToArrayOfDigits(int number)
        {
            string numberAsString = number.ToString();

            for (int i = 0; i < numberAsString.Length; i++)
            {
                if (!char.IsDigit(numberAsString[i]))
                {
                    throw new ArgumentException(InvalidFormatMsg);
                }
            }

            char[] digits = numberAsString.ToCharArray();
            Array.Reverse(digits);

            return digits;
        }

        // alternative:
        // public static long CalculateNFactorial(int n)
        // {
        //     if (n < 1 || n > 100)
        //     {
        //         throw new ArgumentException(InvalidFormatMsg);
        //     }
           
        //     long result = 1;
           
        //     for (int i = 1; i <= n; i++)
        //     {
        //         result *= i;
        //     }
           
        //     return result;
        // }
    }
}
