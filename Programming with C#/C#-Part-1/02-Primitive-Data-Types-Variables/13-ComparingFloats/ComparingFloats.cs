namespace ComparingFloats
{
    using System;

    /// <summary>
    /// Problem 13.* Comparing Floats
    /// Write a program that safely compares floating-point numbers (double) with precision eps = 0.000001.
    /// Note: Two floating-point numbers a and b cannot be compared directly by a == b because of the nature of the floating-point arithmetic. Therefore, we assume two numbers are equal if they are more closely to each other than a fixed constant eps.
    /// </summary>
    public class ComparingFloats
    {
        public static void Main()
        {
            double[] firstNumbers = { 5.3, 5.00000001, 5.00000005, -0.0000007, -4.999999, 4.999999 };
            double[] secondNumbers = { 6.01, 5.00000003, 5.00000001, 0.00000007, -4.999998, 4.999998 };

            double eps = 0.000001;

            for (int i = 0; i < firstNumbers.Length && i < secondNumbers.Length; i++)
            {
                bool equal = Math.Abs(secondNumbers[i] - firstNumbers[i]) < eps;

                Console.WriteLine("a = {0,10}; b = {1,10} | Equal: {2}", firstNumbers[i], secondNumbers[i], equal);
            }
        }
    }
}
