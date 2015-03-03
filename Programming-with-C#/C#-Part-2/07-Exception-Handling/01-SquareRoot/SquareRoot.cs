namespace SquareRoot
{
    using System;

    /// <summary>
    /// Problem 1. Square root
    /// Write a program that reads an integer number and calculates and prints its square root.
    /// * If the number is invalid or negative, print `Invalid number`.
    /// * In all cases finally print `Good bye`.
    /// Use `try-catch-finally` block.
    /// </summary>
    public class SquareRoot
    {
        public static void Main()
        {
            Console.WriteLine("Problem 1. Square root \nWrite a program that reads an integer number and calculates and prints its square root. \nIf the number is invalid or negative, print `Invalid number`. \nIn all cases finally print `Good bye`. \nUse `try-catch-finally` block.\n");
            
            Console.Write("Please enter a number: ");

            try
            {         
                double number = double.Parse(Console.ReadLine());
                double squareRoot = CalculateSquareRoot(number);
                Console.WriteLine("The square root of {0} is {1}.", number, squareRoot);
            }
            catch
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }

        public static double CalculateSquareRoot(double number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number must be positve.");
            }

            return Math.Sqrt(number);
        }
    }
}
