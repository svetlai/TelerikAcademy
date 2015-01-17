namespace ExchangeVariableValues
{
    using System;

    /// <summary>
    /// Problem 9. Exchange Variable Values
    /// Declare two integer variables a and b and assign them with 5 and 10 and after that exchange their values by using some programming logic.
    /// Print the variable values before and after the exchange.
    /// </summary>
    public class ExchangeVariableValues
    {
        public static void Main()
        {
            int firstNumber = 5;
            int secondNumber = 10;

            Console.WriteLine("Initial integer values: {0}, {1}", firstNumber, secondNumber);

            int temp = firstNumber;

            firstNumber = secondNumber;
            secondNumber = temp;

            Console.WriteLine("Exchanged integer values: {0}, {1}", firstNumber, secondNumber);
        }
    }
}
