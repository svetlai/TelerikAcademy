namespace HexadecimalToDecimal
{
    using System;

    using BinaryToDecimal;
    using Helper;
    using HexadecimalToBinary;

    /// <summary>
    /// Problem 4. Hexadecimal to decimal
    /// Write a program to convert hexadecimal numbers to their decimal representation.
    /// </summary>
    public class HexadecimalToDecimal
    {
        public static void Main()
        {
            Console.WriteLine("Problem 4. Hexadecimal to decimal \nWrite a program to convert hexadecimal numbers to their decimal representation.\n");

            Console.Write("Please enter a hexadecimal number (example: 1AE3): ");
            string hexNumber = Console.ReadLine().ToUpper();

            int decimalNumber = ConvertHexadecimalToDecimal(hexNumber);

            Console.WriteLine("Decimal: {0}", decimalNumber);

            // test with the built in conversion
            // Console.WriteLine("Decimal: {0}", Convert.ToInt32(hexNumber, 16));
        }

        public static int ConvertHexadecimalToDecimal(string hexNumber)
        {
            string binary = HexadecimalToBinary.ConvertHexadecimalToBinary(hexNumber);
            int decimalNumber = BinaryToDecimal.ConvertBinaryToDecimal(binary);

            return decimalNumber;
        }

        // alternative - for positive numbers only
        public static uint ConvertPositiveHexadecimalToDecimal(string hexNumber)
        {
            if (hexNumber.StartsWith("0x") || hexNumber.StartsWith("0X"))
            {
                hexNumber = hexNumber.Substring(2);
            }

            int hexDigit;
            uint decimalNumber = 0;

            for (int i = hexNumber.Length - 1, j = 0; i >= 0 && j < hexNumber.Length; i--, j++)
            {
                if (!int.TryParse(hexNumber[i].ToString(), out hexDigit))
                {
                    switch (hexNumber[i])
                    {
                        case 'A':
                            hexDigit = 10;
                            break;
                        case 'B':
                            hexDigit = 11;
                            break;
                        case 'C':
                            hexDigit = 12;
                            break;
                        case 'D':
                            hexDigit = 13;
                            break;
                        case 'E':
                            hexDigit = 14;
                            break;
                        case 'F':
                            hexDigit = 15;
                            break;
                        default:
                            throw new ArgumentException("Input not in the correct format.");
                    }
                }

                // hex to decimal: FE = 14 * 16^0 + 15 * 16^1 = 254
                decimalNumber += (uint)(hexDigit * ExtensionMethods.Pow(16, j));
            }

            return decimalNumber;
        }
    }
}
