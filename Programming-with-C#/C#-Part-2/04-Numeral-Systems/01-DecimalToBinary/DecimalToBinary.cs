namespace DecimalToBinary
{
    using System;

    using Helper;
    using System.Text;

    /// <summary>
    /// Problem 1. Decimal to binary
    /// Write a program to convert decimal numbers to their binary representation.
    /// </summary>
    public class DecimalToBinary
    {
        private const int NumberOfBits = 32;

        public static void Main()
        {
            Console.WriteLine("Problem 1. Decimal to binary \nWrite a program to convert decimal numbers to their binary representation.\n");

            // read input from the console
            Console.Write("Please enter a decimal integer number: ");

            int decimalNumber;
            if (!int.TryParse(Console.ReadLine(), out decimalNumber))
            {
                Console.WriteLine("Input not in the correct format.");
                return;
            }

            string result = ConvertDecimalToBinary(decimalNumber);

            Console.WriteLine("Binary: {0}", result);

            // test with the built in conversion
            // Console.WriteLine("Binary: {0}", Convert.ToString(decimalNumber, 2));
        }

        public static string ConvertDecimalToBinary(int decimalNumber)
        {
            bool isNegative = decimalNumber < 0;
            decimalNumber = Math.Abs(decimalNumber);

            StringBuilder sb = new StringBuilder();

            // decimal to binary: 
            // 5 = 5 / 2 = 2 reminder 1; 
            // 2 / 2 = 1 reminder 0; 
            // 1 / 2 = 0 reminder 1 = 101 (reversed);
            while (decimalNumber != 0)
            {
                sb.Append(decimalNumber % 2);
                decimalNumber = decimalNumber / 2;
            }

            string result = ExtensionMethods.ReverseString(sb.ToString());
            
            if (isNegative)
            {
                result = ExtensionMethods.InvertBinaryNumber(result, NumberOfBits);
                result = ExtensionMethods.AddBinaryNumbers(result, "1", NumberOfBits);
            }

            return result;
        }
    }
}
