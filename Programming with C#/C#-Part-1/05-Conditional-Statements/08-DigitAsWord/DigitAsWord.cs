namespace DigitAsWord
{
    using System;

    /// <summary>
    /// Problem 8. Digit as Word
    /// Write a program that asks for a digit (0-9), and depending on the input, shows the digit as a word (in English).
    /// Print `not a digit` in case of invalid input.
    /// Use a switch statement.
    /// Examples:
    /// | d    | result      |
    /// |------|-------------|
    /// | 2    | two         |
    /// | 1    | one         |
    /// | 0    | zero        |
    /// | 5    | five        |
    /// | -0.1 | not a digit |
    /// | hi   | not a digit |
    /// | 9    | nine        |
    /// | 10   | not a digit |
    /// </summary>
    public class DigitAsWord
    {
        public static void Main()
        {
            Console.WriteLine("Problem 8. Digit as Word \nWrite a program that asks for a digit (0-9), and depending on the input, shows the digit as a word (in English). \nPrint `not a digit` in case of invalid input. \nUse a switch statement.\n");

            Console.Write("Enter a digit: ");
            string digit = Console.ReadLine();
            string digitName;

            while (digit != string.Empty)
            {
                switch (digit)
                {
                    case "0":
                        digitName = "zero";
                        break;
                    case "1":
                        digitName = "one";
                        break;
                    case "2":
                        digitName = "two";
                        break;
                    case "3":
                        digitName = "three";
                        break;
                    case "4":
                        digitName = "four";
                        break;
                    case "5":
                        digitName = "five";
                        break;
                    case "6":
                        digitName = "six";
                        break;
                    case "7":
                        digitName = "seven";
                        break;
                    case "8":
                        digitName = "eight";
                        break;
                    case "9":
                        digitName = "nine";
                        break;
                    default: digitName = "not a digit";
                        break;
                }

                Console.WriteLine("{0,5} | {1,5}", digit, digitName);

                Console.Write("Enter a digit: ");
                digit = Console.ReadLine();
            }
        }
    }
}
