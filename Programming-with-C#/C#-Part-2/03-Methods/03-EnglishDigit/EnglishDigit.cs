namespace EnglishDigit
{
    using System;

    /// <summary>
    /// Problem 3. English digit
    /// Write a method that returns the last digit of given integer as an English word.
    /// Examples:
    /// | input | output |
    /// |:-----:|:------:|
    /// | 512   | two    |
    /// | 1024  | four   |
    /// | 12309 | nine   |
    /// </summary>
    public class EnglishDigit
    {
        private const string InvalidFormatMsg = "Input was not in the correct format.";

        public static void Main()
        {
            Console.WriteLine("Problem 3. English digit \nWrite a method that returns the last digit of given integer as an English word.\n");

            Console.Write("Enter an integer number: ");

            int number;
            if (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine(InvalidFormatMsg);
                return;
            }

            string digitAsWord = GetLastDigitAsWord(number);

            Console.WriteLine("{0} -- {1}", number, digitAsWord);
        }

        public static string GetLastDigitAsWord(int number)
        {
            int digit = number % 10;
            string digitAsWord;

            switch (digit)
            {
                case 0: digitAsWord = "zero"; 
                    break;
                case 1: digitAsWord = "one";
                    break;
                case 2: digitAsWord = "two";
                    break;
                case 3: digitAsWord = "three";
                    break;
                case 4: digitAsWord = "four";
                    break;
                case 5: digitAsWord = "five";
                    break;
                case 6: digitAsWord = "six";
                    break;
                case 7: digitAsWord = "seven";
                    break;
                case 8: digitAsWord = "eight";
                    break;
                case 9: digitAsWord = "nine";
                    break;
                default: digitAsWord = "This is not a digit.";
                    break;
            }

            return digitAsWord;
        }
    }
}
