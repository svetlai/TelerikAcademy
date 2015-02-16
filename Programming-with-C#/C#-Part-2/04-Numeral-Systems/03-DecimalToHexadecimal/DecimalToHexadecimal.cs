namespace DecimalToHexadecimal
{
    using System;
    
    using BinaryToHexadecimal;
    using DecimalToBinary;   
    using Helper;

    /// <summary>
    /// Problem 3. Decimal to hexadecimal
    /// Write a program to convert decimal numbers to their hexadecimal representation.
    /// </summary>
    public class DecimalToHexadecimal
    {
        public static void Main()
        {
            Console.WriteLine("Problem 3. Decimal to hexadecimal \nWrite a program to convert decimal numbers to their hexadecimal representation.\n");

            Console.Write("Please enter a decimal integer number: ");

            int decimalNumber;
            if (!int.TryParse(Console.ReadLine(), out decimalNumber))
            {
                Console.WriteLine("Input not in the correct format.");
                return;
            }

            string result = ConvertDecimalToHexadecimal(decimalNumber);

            Console.WriteLine("Hex: {0}", result);

            // test with the built in conversion
            // Console.WriteLine("Hex: {0}", Convert.ToString(decimalNumber, 16));
        }

        public static string ConvertDecimalToHexadecimal(int decimalNumber)
        {
            string binary = DecimalToBinary.ConvertDecimalToBinary(decimalNumber);
            string result = BinaryToHexadecimal.ConvertBinaryToHexadecimal(binary);
  
            return result;
        }

        // alternative - for non-negative decimal numbers only
        public static string ConvertDecimalToHexadecimal(uint decimalNumber)
        {
            // decimal to hex
            // 6883 = 6883 / 16 = 430, reminder 3;
            // 430 / 16 = 26, reminder 14 --> E;
            // 26 / 16 = 1, reminder 10 -- > A;
            // 1 / 16 = 0, reminder 1 = 1AE3 (reversed);
            string result = string.Empty;
            string hexDigit;

            while (decimalNumber != 0)
            {
                if (decimalNumber % 16 < 9)
                {
                    hexDigit = (decimalNumber % 16).ToString();
                }
                else
                {
                    switch (decimalNumber % 16)
                    {
                        case 10:
                            hexDigit = "A";
                            break;
                        case 11:
                            hexDigit = "B";
                            break;
                        case 12:
                            hexDigit = "C";
                            break;
                        case 13:
                            hexDigit = "D";
                            break;
                        case 14:
                            hexDigit = "E";
                            break;
                        case 15:
                            hexDigit = "F";
                            break;
                        default:
                            result = "Input not in the correct format.";
                            return result;
                    }
                }

                decimalNumber = decimalNumber / 16;
                result += hexDigit;
            }

            result = ExtensionMethods.ReverseString(result);

            return result;
        }
    }
}
