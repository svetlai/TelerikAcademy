namespace NumberAsArray
{
    using System;
    using System.Linq;
    using System.Numerics;
    using System.Text;

    /// <summary>
    /// Problem 8. Number as array
    /// Write a method that adds two positive integer numbers represented as arrays of digits (each array element `arr[i]` contains a digit; the last digit is kept in `arr[0]`).
    /// Each of the numbers that will be added could have up to `10 000` digits.
    /// </summary>
    public class NumberAsArray
    {
        private const string InvalidFormatMsg = "Input was not in the correct format.";

        public static void Main()
        {
            int firstNumber = 1584;
            int secondNumber = 236;

            string result = AddNumbersRepresentedAsArrays(firstNumber, secondNumber);

            DisplayExample(firstNumber, secondNumber, result);
        }

        public static string AddNumbersRepresentedAsArrays(int firstNumber, int secondNumber)
        {
            string firstAsString = firstNumber.ToString();
            string secondAsString = secondNumber.ToString();

            char[] first = ConvertNumberToArrayOfDigits(firstAsString);
            char[] second = ConvertNumberToArrayOfDigits(secondAsString);

            return AddTwoArraysOfDigits(first, second);
        }

        public static string AddTwoArraysOfDigits(char[] first, char[] second)
        {
            int[] longest = first.Length > second.Length ? first.Select(x => x - '0').ToArray() : second.Select(x => x - '0').ToArray();
            int[] shortest = first.Length > second.Length ? second.Select(x => x - '0').ToArray() : first.Select(x => x - '0').ToArray();

            Array.Resize(ref shortest, longest.Length);

            char[] result = new char[longest.Length];

            int sum = 0;
            int inMind = 0;

            for (int i = 0; i < longest.Length; i++)
            {
                sum = longest[i] + shortest[i] + inMind;
                inMind = sum / 10;
                sum = sum % 10;

                result[i] = (char)(sum + '0');
            }

            Array.Reverse(result);

            return new string(result).TrimStart('0');
        }

        public static char[] ConvertNumberToArrayOfDigits(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (!char.IsDigit(number[i]))
                {
                    throw new ArgumentException(InvalidFormatMsg);
                }
            }

            char[] digits = number.ToCharArray();
            Array.Reverse(digits);

            return digits;
        }

        public static char[] ConvertNumberToArrayOfDigits(BigInteger number)
        {
            string numberAsString = number.ToString();
            char[] digits = numberAsString.ToCharArray();
            Array.Reverse(digits);

            return digits;
        }

        private static void DisplayExample(int firstNumber, int secondNumber, string result)
        {
            StringBuilder print = new StringBuilder();
            string border = new string('-', 60);

            print.AppendLine("Problem 8. Number as array \nWrite a method that adds two positive integer numbers represented as arrays of digits (each array element `arr[i]` contains a digit; the last digit is kept in `arr[0]`). \nEach of the numbers that will be added could have up to `10 000` digits.");

            char[] first = ConvertNumberToArrayOfDigits(firstNumber);
            char[] second = ConvertNumberToArrayOfDigits(secondNumber);

            // print
            print.AppendLine("Example: ")
                .AppendLine(border)
                .AppendLine(string.Format("{0,-10} /{1,10} | {2,-10} /{3,10} | {4,10}", "first number", "as array", "second number", "as array", "result"))
                .AppendLine(string.Format("{0,-10}  {1,12} | {2,-10}   {3,12} | {4,10}", firstNumber, string.Join(" ", first), secondNumber, string.Join(" ", second), result))
                .AppendLine(border);

            Console.Write(print.ToString());

            // test with your input
            Console.Write("Try it yourself! \nEnter an integer number: ");

            if (!int.TryParse(Console.ReadLine(), out firstNumber))
            {
                Console.WriteLine(InvalidFormatMsg);
            }

            Console.Write("Enter a second integer number: ");
            if (!int.TryParse(Console.ReadLine(), out secondNumber))
            {
                Console.WriteLine(InvalidFormatMsg);
            }

            first = ConvertNumberToArrayOfDigits(firstNumber);
            second = ConvertNumberToArrayOfDigits(secondNumber);

            result = AddNumbersRepresentedAsArrays(firstNumber, secondNumber);

            // print
            print.Clear()
                .AppendLine(border)
                .AppendLine(string.Format("{0,-10}  {1,12} | {2,-10}   {3,12} | {4,10}", firstNumber, string.Join(" ", first), secondNumber, string.Join(" ", second), result))
                .AppendLine(border);

            Console.Write(print.ToString());
        }
    }
}
