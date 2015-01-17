namespace HexadecimalToDecimalNumber
{
    using System;

    /// <summary>
    /// Problem 15. Hexadecimal to Decimal Number
    /// Using loops write a program that converts a hexadecimal integer number to its decimal form.
    /// The input is entered as string. The output should be a variable of type long.
    /// Do not use the built-in .NET functionality.
    /// Examples:
    /// hexadecimal	decimal
    /// FE	254
    /// 1AE3	6883
    /// 4ED528CBB4	338583669684
    /// </summary>
    public class HexadecimalToDecimalNumber
    {
        public static void Main()
        {
            Console.WriteLine("Problem 15. Hexadecimal to Decimal Number \nUsing loops write a program that converts a hexadecimal integer number to its decimal form. \nThe input is entered as string. The output should be a variable of type long. \nDo not use the built-in .NET functionality.\n");

            Console.Write("Please enter a hexadecimal number (example: 1AE3): ");
            string hexNumber = Console.ReadLine();

            int hexDigit;
            long asDecimal = 0;

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
                        default: Console.WriteLine("Input not in the correct format.");
                            return;
                    }
                }

                // hex to decimal: FE = 14 * 16^0 + 15 * 16^1 = 254
                asDecimal += (long)(hexDigit * Math.Pow(16, j));
            }

            Console.WriteLine("Decimal: {0}", asDecimal);
        }
    }
}
