namespace OneSystemToAnyOther
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Helper;

    /// <summary>
    /// Problem 7. One system to any other
    /// Write a program to convert from any numeral system of given base `s` to any other numeral system of base `d` (2 <=; `s`, `d` <=; 16).
    /// </summary>
    public class OneSystemToAnyOther
    {
        private const string Digits = "0123456789ABCDEF";
        private const string FormatExceptionMsg = "Input not in the correct format.";

        public static void Main()
        {
            int s = 12;
            int d = 3;
            string input = "A121";
            string result = ConvertNumeralSystemSToNumeralSystemD(s, d, input);

            DisplayExample(s, d, input, result);

            // test with the built in conversion
            // Console.WriteLine(Test());
        }

        public static string ConvertNumeralSystemSToNumeralSystemD(int baseOfS, int baseOfD, string number)
        {
            uint decimalNumber = ConvertNumeralSystemToDecimal(baseOfS, number);
            string result = ConvertDecimalToNumeralSystem(baseOfD, decimalNumber);

            return result;
        }

        private static uint ConvertNumeralSystemToDecimal(int baseOfSystem, string number)
        {
            if (baseOfSystem < 2 || baseOfSystem > 16)
            {
                throw new ArgumentException("Base must be between 2 and 16 inclusive.");
            }

            uint result = 0;
            for (int i = number.Length - 1, j = 0; i >= 0 && j < number.Length; i--, j++)
            {
                int index = Digits.IndexOf(number[i].ToString().ToUpper());

                if (index > (baseOfSystem - 1) || index < 0)
                {
                    throw new ArgumentException("The number you entered is not in the correct format.");
                }

                result += (uint)(index * ExtensionMethods.Pow(baseOfSystem, j));
            }

            return result;
        }  

        private static string ConvertDecimalToNumeralSystem(int baseOfSystem, uint decimalNumber)
        {
            if (baseOfSystem < 2 || baseOfSystem > 16)
            {
                throw new ArgumentException("Base must be between 2 and 16 inclusive.");
            }

            string result = string.Empty;
            char digit;

            while (decimalNumber != 0)
            {
                int digitIndex = Digits.IndexOf((decimalNumber % baseOfSystem).ToString());
                digit = Digits[digitIndex];
                result += digit;

                decimalNumber = (uint)(decimalNumber / baseOfSystem);
            }

            result = ExtensionMethods.ReverseString(result);

            return result;
        }

        /// <summary>
        /// Test method, comparing our methods with the built-in conversion methods
        /// </summary>
        /// <returns>True if valid; false if not</returns>
        private static bool IsSameAsBuiltInMethods()
        {
            string builtInBinary = Convert.ToString(256, 2);
            string binary = ConvertDecimalToNumeralSystem(2, 256);

            uint builtInToInt = Convert.ToUInt32("101", 2);
            uint toInt = ConvertNumeralSystemToDecimal(2, "101");

            string builtInHex = Convert.ToString(256, 16);
            string binaryToHex = ConvertNumeralSystemSToNumeralSystemD(2, 16, Convert.ToString(256, 2));

            return builtInBinary == binary && builtInToInt == toInt && builtInHex == binaryToHex;
        }

        private static void DisplayExample(int s, int d, string input, string result)
        {
            StringBuilder print = new StringBuilder();
            string border = new string('-', 60);

            print.AppendLine("Problem 7. One system to any other \nWrite a program to convert from any numeral system of given base `s` to any other numeral system of base `d` (2 <= `s`, `d` <=; 16).\n");

            // print
            print.AppendLine("Example:")
                .AppendLine(border)
                .AppendLine(string.Format("{0,3} | {1,3} | {2,15} | {3} ", "S", "D", "input", "result"))
                .AppendLine(string.Format("{0,3} | {1,3} | {2,15} | {3} ", s, d, input, result))
                .AppendLine(border);

            Console.WriteLine(print.ToString());

            // test with your input
            Console.Write("Try it yourself! \nPlease enter a base S so that 2 <= S <= 16: ");

            if (!int.TryParse(Console.ReadLine(), out s) || s < 2 || s > 16)
            {
                Console.WriteLine(FormatExceptionMsg);
                return;
            }

            Console.Write("Please enter a base D so that 2 <= D <= 16: ");

            if (!int.TryParse(Console.ReadLine(), out d) || d < 2 || d > 16)
            {
                Console.WriteLine(FormatExceptionMsg);
                return;
            }

            Console.Write("Please enter a number from numeral system S to convert to numeral system D: ");
            input = Console.ReadLine();

            result = ConvertNumeralSystemSToNumeralSystemD(s, d, input);

            // print
            print.Clear()
                .AppendLine(border)
                .AppendLine(string.Format("{0,3} | {1,3} | {2,15} | {3} ", s, d, input, result))
                .AppendLine(border);

            Console.WriteLine(print.ToString());
        }
    }
}
