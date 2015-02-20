namespace BinaryToHexadecimal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Problem 6. binary to hexadecimal
    /// Write a program to convert binary numbers to hexadecimal numbers (directly).
    /// </summary>
    public class BinaryToHexadecimal
    {
        private static readonly Dictionary<string, char> BinaryToHex = new Dictionary<string, char>()
        { 
            { "0000", '0' },
            { "0001", '1' },
            { "0010", '2' },
            { "0011", '3' },
            { "0100", '4' },
            { "0101", '5' },
            { "0110", '6' },
            { "0111", '7' },
            { "1000", '8' },
            { "1001", '9' },
            { "1010", 'A' },
            { "1011", 'B' },
            { "1100", 'C' },
            { "1101", 'D' },
            { "1110", 'E' },
            { "1111", 'F' },
        };

        public static void Main()
        {
            Console.WriteLine("Problem 6. binary to hexadecimal \nWrite a program to convert binary numbers to hexadecimal numbers (directly). \n");

            Console.Write("Please enter a binary number (example: 1001): ");

            // 11111111111111111111111111111000
            string binaryNumber = Console.ReadLine();

            if (binaryNumber.Any(a => a > '1' || a < '0'))
            {
                Console.WriteLine("Input was not in the correct format.");
                return;
            }

            string hexNumber = ConvertBinaryToHexadecimal(binaryNumber);

            Console.WriteLine("Hex: {0}", hexNumber);

            // test with the built in conversion 
            // Console.WriteLine(Convert.ToString(Convert.ToInt32(binaryNumber, 2), 16));
        }

        public static string ConvertBinaryToHexadecimal(string binaryNumber, int numberOfBits = 32)
        {
            StringBuilder result = new StringBuilder();
            binaryNumber = binaryNumber.PadLeft(numberOfBits, '0');

            for (int i = 0; i < numberOfBits / 4; i++)
            {
                string hexDigitInBinary = binaryNumber.Substring(i * 4, 4);

                if (!BinaryToHex.ContainsKey(hexDigitInBinary))
                {
                    throw new ArgumentException("Input was not in the correct format.");
                }

                result.Append(BinaryToHex[hexDigitInBinary]);
            }

            return result.ToString()
                .TrimStart('0');
        }
    }
}
