namespace HexadecimalToBinary
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Problem 5. Hexadecimal to binary
    /// Write a program to convert hexadecimal numbers to binary numbers (directly).
    /// </summary>
    public class HexadecimalToBinary
    {
        private static readonly Dictionary<char, string> HexToBinary = new Dictionary<char, string>()
        { 
            { '0', "0000" },
            { '1', "0001" },
            { '2', "0010" },
            { '3', "0011" },
            { '4', "0100" },
            { '5', "0101" },
            { '6', "0110" },
            { '7', "0111" },
            { '8', "1000" },
            { '9', "1001" },
            { 'A', "1010" },
            { 'B', "1011" },
            { 'C', "1100" },
            { 'D', "1101" },
            { 'E', "1110" },
            { 'F', "1111" },
        };

        public static void Main()
        {
            Console.WriteLine("Problem 5. Hexadecimal to binary \nWrite a program to convert hexadecimal numbers to binary numbers (directly).\n");

            Console.Write("Please enter a hexadecimal number (example: 1AE3): ");
            string hexNumber = Console.ReadLine().ToUpper();

            string binary = ConvertHexadecimalToBinary(hexNumber);

            Console.WriteLine("Binary: {0}", binary);

            // test with the built in conversion
            // Console.WriteLine("Binary: {0}", Convert.ToString(Convert.ToInt32(hexNumber, 16), 2).PadLeft(32, '0'));
        }

        public static string ConvertHexadecimalToBinary(string hexNumber)
        {
            if (hexNumber.StartsWith("0x") || hexNumber.StartsWith("0X"))
            {
                hexNumber = hexNumber.Substring(2);
            }

            StringBuilder binaryNumber = new StringBuilder();

            for (int i = 0; i < hexNumber.Length; i++)
            {
                if (!HexToBinary.ContainsKey(hexNumber[i]))
                {
                    throw new ArgumentException("Input was not in the correct format.");
                }

                binaryNumber.Append(HexToBinary[hexNumber[i]]);
            }

            return binaryNumber.ToString();
        }
    }
}
