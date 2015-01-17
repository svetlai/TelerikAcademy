namespace DecimalToHexadecimalNumber
{
    using System;

    /// <summary>
    /// Problem 16. Decimal to Hexadecimal Number
    /// Using loops write a program that converts an integer number to its hexadecimal representation.
    /// The input is entered as long. The output should be a variable of type string.
    /// Do not use the built-in .NET functionality.
    /// Examples:
    /// decimal	hexadecimal
    /// 254	FE
    /// 6883	1AE3
    /// 338583669684    4ED528CBB4
    /// </summary>
    public class DecimalToHexadecimalNumber
    {
        public static void Main()
        {
            Console.WriteLine("Problem 16. Decimal to Hexadecimal Number \nUsing loops write a program that converts an integer number to its hexadecimal representation. \nThe input is entered as long. The output should be a variable of type string. \nDo not use the built-in .NET functionality.\n");
            
            Console.Write("Please enter a decimal integer number: ");
            
            long asDecimal;
            if (!long.TryParse(Console.ReadLine(), out asDecimal))
            {
                Console.WriteLine("Input not in the correct format.");
                return;
            }

            // decimal to hex
            // 6883 = 6883 / 16 = 430, reminder 3;
            // 430 / 16 = 26, reminder 14 --> E;
            // 26 / 16 = 1, reminder 10 -- > A;
            // 1 / 16 = 0, reminder 1 = 1AE3 (reversed);
            string result = string.Empty;
            string hexDigit;

            while (asDecimal > 0)
            {
                if (asDecimal % 16 < 9)
                {
                    hexDigit = (asDecimal % 16).ToString();
                }
                else
                {
                    switch (asDecimal % 16)
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
                        default: Console.WriteLine("Input not in the correct format.");
                            return;
                    }
                }         

                asDecimal = asDecimal / 16;
                result += hexDigit;
            }

            // reverse result
            char[] hex = result.ToCharArray();
            Array.Reverse(hex);
            result = new string(hex);

            Console.WriteLine("Hex: {0}", result);
        }
    }
}
