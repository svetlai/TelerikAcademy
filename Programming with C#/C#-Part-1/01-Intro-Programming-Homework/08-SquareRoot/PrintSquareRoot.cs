namespace SquareRoot
{
    using System;

    /// <summary>
    /// Problem 8. Square Root
    /// Create a console application that calculates and prints the square root of the number 12345.
    /// Find in Internet “how to calculate square root in C#”.
    /// </summary>
    public class PrintSquareRoot
    {
        public static void Main()
        {
            double number = 12345;
            double squareRoot = Math.Sqrt(number);

            Console.WriteLine("The square root of {0} is {1:0.00}", number, squareRoot);
        }
    }
}
