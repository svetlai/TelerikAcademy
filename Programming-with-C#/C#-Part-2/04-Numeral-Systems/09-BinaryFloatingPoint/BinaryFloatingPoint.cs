namespace BinaryFloatingPoint
{
    using System;
    using System.Globalization;
    using System.Text;
    using System.Threading;

    using DecimalToBinary;

    /// <summary>
    /// Problem 9.* Binary floating-point
    /// Write a program that shows the internal binary representation of given 32-bit signed floating-point number in IEEE 754 format (the C# type `float`).
    /// Example:
    /// | number | sign | exponent |         mantissa        |
    /// |:------:|:----:|:--------:|:-----------------------:|
    /// | -27,25 | 1    | 10000011 | 10110100000000000000000 |
    /// </summary>
    public class BinaryFloatingPoint
    {
        private const string FormatExceptionMsg = "Input not in the correct format.";
        private static readonly string Border = new string('-', 60);

        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            float input = -27.25f;
            string binary = ConvertFloatToBinary(input);

            string sign = GetSign(binary);
            string exponent = GetExponent(binary);
            string mantissa = GetMantissa(binary);

            DisplayExample(input, binary, sign, exponent, mantissa);
        }

        // using LukeH's approach: http://stackoverflow.com/questions/8272733/how-do-i-turn-a-binary-string-into-a-float-or-double
        public static string ConvertFloatToBinary(float floatNumber)
        {
            byte[] bytes = BitConverter.GetBytes(floatNumber);
            int decimalNumber = BitConverter.ToInt32(bytes, 0);
            string binary = DecimalToBinary.ConvertDecimalToBinary(decimalNumber); // Convert.ToString(decimalNumber, 2);

            return binary;
        }

        public static string GetSign(string binary)
        {
            return binary[0].ToString();
        }

        public static string GetExponent(string binary)
        {
            return binary.Substring(1, 8);
        }

        public static string GetMantissa(string binary)
        {
            return binary.Substring(9);
        }

        private static void DisplayExample(float input, string binary, string sign, string exponent, string mantissa)
        {
            StringBuilder print = new StringBuilder();

            print.AppendLine("Problem 9.* Binary floating-point \nWrite a program that shows the internal binary representation of given 32-bit signed floating-point number in IEEE 754 format (the C# type `float`).");

            // print example
            print.AppendLine("Example:")
                .AppendLine(Border)
                .AppendLine(string.Format("{0,10} | {1,4} | {2,10} | {3}", "number", "sign", "exponent", "mantissa"))
                .AppendLine(string.Format("{0,10} | {1,4} | {2,10} | {3}", input, sign, exponent, mantissa))
                .AppendLine(Border);

            Console.Write(print.ToString());

            // read input from the console
            Console.Write("Try it yourself! \nPlease enter a floating-point number: ");

            if (!float.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine(FormatExceptionMsg);
                return;
            }

            binary = ConvertFloatToBinary(input);

            sign = GetSign(binary);
            exponent = GetExponent(binary);
            mantissa = GetMantissa(binary);

            // print result
            print.Clear()
                .AppendLine(Border)
                .AppendLine(string.Format("{0,10} | {1,4} | {2,10} | {3}", input, sign, exponent, mantissa))
                .AppendLine(Border);

            Console.Write(print.ToString());
        }
    }
}
