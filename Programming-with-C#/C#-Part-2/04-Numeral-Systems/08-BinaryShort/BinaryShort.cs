namespace BinaryShort
{
    using System;
    using System.Text;

    using Helper;

    /// <summary>
    /// Problem 8. Binary short
    /// Write a program that shows the binary representation of given 16-bit signed integer number (the C# type `short`)
    /// </summary>
    public class BinaryShort
    {
        private const int NumberOfBits = 16;

        public static void Main()
        {
            Console.WriteLine("Problem 8. Binary short \nWrite a program that shows the binary representation of given 16-bit signed integer number (the C# type `short`)\n");

            // read input from the console
            Console.Write("Please enter a decimal short number: ");

            short shortNumber;
            if (!short.TryParse(Console.ReadLine(), out shortNumber))
            {
                Console.WriteLine("Input not in the correct format.");
                return;
            }

            string result = ConvertShortToBinary(shortNumber);

            Console.WriteLine("Binary: {0}", result);

            // test with the built-in conversion
            // Console.WriteLine("Binary: {0}", Convert.ToString(shortNumber, 2));
        }

        public static string ConvertShortToBinary(short shortNumber)
        {
            bool isNegative = shortNumber < 0;
            shortNumber = Math.Abs(shortNumber);

            StringBuilder sb = new StringBuilder();

            // decimal to binary: 
            // 5 = 5 / 2 = 2 reminder 1; 
            // 2 / 2 = 1 reminder 0; 
            // 1 / 2 = 0 reminder 1 = 101 (reversed);
            while (shortNumber != 0)
            {
                sb.Append(shortNumber % 2);
                shortNumber = (short)(shortNumber / 2);
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
