namespace BinaryToDecimal
{
    using System;
    using System.Linq;

    using Helper;

    /// <summary>
    /// Problem 2. Binary to decimal
    /// Write a program to convert binary numbers to their decimal representation.
    /// </summary>
    public class BinaryToDecimal
    {
        public static void Main()
        {
            Console.WriteLine("Problem 2. Binary to decimal \nWrite a program to convert binary numbers to their decimal representation.\n");

            Console.Write("Please enter a binary number (example: 1001): ");

            // test with negative: 11111111111111111111111111111000
            string binaryNumber = Console.ReadLine();

            if (binaryNumber.Any(a => a > '1' || a < '0'))
            {
                Console.WriteLine("Input was not in the correct format.");
                return;
            }

            int decimalNumber = ConvertBinaryToDecimal(binaryNumber);

            Console.WriteLine("Decimal: {0}", decimalNumber);

            // test with the built in conversion
            // Console.WriteLine("Decimal: {0}", Convert.ToInt32(binaryNumber, 2));
        }

        public static int ConvertBinaryToDecimal(string binaryNumber, int numberOfBits = 32)
        {
            binaryNumber = binaryNumber.PadLeft(numberOfBits, '0');
            bool isNegative = false;

            // check if binary number is negative; if yes - subtract one and invert it (two's-component)
            if (binaryNumber[0] == '1')
            {
                binaryNumber = ExtensionMethods.SubtractBinaryNumbers(binaryNumber, "1", numberOfBits);
                binaryNumber = ExtensionMethods.InvertBinaryNumber(binaryNumber, numberOfBits);
                isNegative = true;
            }

            int decimalNumber = 0;

            for (int i = binaryNumber.Length - 1, j = 0; i >= 0 && j < binaryNumber.Length; i--, j++)
            {
                // binary to decimal: 0101 = 1 * 2^0 + 0 * 2^1 + 1 * 2^2 + 0 * 2^3 = 5
                decimalNumber += (int)((binaryNumber[i] - '0') * ExtensionMethods.Pow(2, j));   // binary[i] - '0' converts a character to number
            }

            if (isNegative)
            {
                decimalNumber = decimalNumber * -1;
            }

            return decimalNumber;
        }
    }
}
