namespace NullValuesArithmetic
{
    using System;

    /// <summary>
    /// Problem 12. Null Values Arithmetic
    /// Create a program that assigns null values to an integer and to a double variable.
    /// Try to print these variables at the console.
    /// Try to add some number or the null literal to these variables and print the result.
    /// </summary>
    public class NullValuesArithmetic
    {
        public static void Main()
        {
            int? firstNumber = null;
            double? secondNumber = null;

            Console.WriteLine("Null values: ");
            Console.WriteLine("{0}, {1}", firstNumber, secondNumber);   // prints nothing

            firstNumber = firstNumber + 1;
            secondNumber = secondNumber + 1.2;

            Console.WriteLine("After adding values: ");
            Console.WriteLine("{0}, {1}", firstNumber, secondNumber);   // still prints nothing
        }
    }
}
