namespace Helper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class ExtensionMethods
    {
        public static string AddBinaryNumbers(this string first, string second, int numberOfBits = 32)
        {
            int firstNumber = Convert.ToInt32(first, 2);
            int secondNumber = Convert.ToInt32(second, 2);

            return Convert.ToString(firstNumber + secondNumber, 2).PadLeft(numberOfBits, '0');
        }

        public static string SubtractBinaryNumbers(this string first, string second, int numberOfBits = 32)
        {
            int firstNumber = Convert.ToInt32(first, 2);
            int secondNumber = Convert.ToInt32(second, 2);

            return Convert.ToString(firstNumber - secondNumber, 2).PadLeft(numberOfBits, '0');
        }

        public static string InvertBinaryNumber(this string binaryNumber, int numberOfBits = 32)
        {
            char[] binary = binaryNumber.PadLeft(numberOfBits, '0').ToCharArray();

            for (int i = 0; i < binary.Length; i++)
            {
                binary[i] = binary[i] == '0' ? '1' : '0';
            }

            return new string(binary);
        }

        public static double Pow(this int baseNumber, int power)
        {
            double result = 1;

            if (power == 0)
            {
                return result;
            }
            else if (power > 0)
            {
                for (int i = 0; i < power; i++)
                {
                    result *= baseNumber;
                }
            }
            else
            {
                for (int i = power; i < 0; i++)
                {
                    result /= baseNumber;
                }
            }

            return result;
        }

        public static string ReverseString(this string toReverse)
        {
            char[] reversed = toReverse.ToCharArray();
            Array.Reverse(reversed);

            return new string(reversed);
        }
    }
}
