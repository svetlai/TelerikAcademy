namespace BinaryToDecimalNumber
{
    using System;

    /// <summary>
    /// Problem 13. Binary to Decimal Number
    /// Using loops write a program that converts a binary integer number to its decimal form.
    /// The input is entered as string. The output should be a variable of type long.
    /// Do not use the built-in .NET functionality.
    /// Examples:
    /// binary	decimal
    /// 0	0
    /// 11	3
    /// 1010101010101011	43691
    /// 1110000110000101100101000000
    /// </summary>
    public class BinaryToDecimalNumber
    {
        public static void Main()
        {
            Console.WriteLine("Problem 13. Binary to Decimal Number \nUsing loops write a program that converts a binary integer number to its decimal form. \nThe input is entered as string. The output should be a variable of type long. \nDo not use the built-in .NET functionality.\n");

            Console.Write("Please enter a binary number: ");
            string binary = Console.ReadLine();           

            long asDecimal = 0;
            for (int i = binary.Length - 1, j = 0; i >= 0 && j < binary.Length; i--, j++)
            {
                // binary to decimal: 0101 = 1 * 2^0 + 0 * 2^1 + 1 * 2^2 + 0 * 2^3 = 5
                asDecimal += (long)((binary[i] - '0') * Math.Pow(2, j));   // binary[i] - '0' converts a character to number
            }

            Console.WriteLine("Decimal: {0}", asDecimal);
        }
    }
}
