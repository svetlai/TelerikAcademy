namespace ReverseNumber
{
    using System;
    using System.Globalization;
    using System.Text;
    using System.Threading;

    /// <summary>
    /// Problem 7. Reverse number
    /// Write a method that reverses the digits of given decimal number.
    /// Example:
    /// | input | output |
    /// |:-----:|:------:|
    /// | 256   | 652    |
    /// </summary>
    public class ReverseNumber
    {
        private const string InvalidFormatMsg = "Input was not in the correct format.";
        private static readonly string Border = new string('-', 60);

        public static void Main()
        {
            StringBuilder print = new StringBuilder();

            print.AppendLine("Problem 7. Reverse number \nWrite a method that reverses the digits of given decimal number. \n");

            Thread.CurrentThread.CurrentCulture = CultureInfo.InstalledUICulture;

            double number = 256;
            double reversed = ReverseDecimalNumber(number);

            // print
            print.AppendLine("Example:")
                .AppendLine(Border)
                .AppendLine(string.Format("{0,10} | {1,10}", "input", "result"))
                .AppendLine(string.Format("{0,10} | {1,10}", number, reversed))
                .AppendLine(Border);

            Console.WriteLine(print.ToString());

            // test with your input
            Console.Write("Try it yourself! \nEnter a decimal number: ");
    
            if (!double.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine(InvalidFormatMsg);
                return;
            }

            reversed = ReverseDecimalNumber(number);

            // print
            print.Clear()
                .AppendLine(Border)
                .AppendLine(string.Format("{0,10} | {1,10}", number, reversed))
                .AppendLine(Border);

            Console.WriteLine(print.ToString());
        }

        public static double ReverseDecimalNumber(double number)
        {
            char[] numberAsChars = number.ToString().ToCharArray();
            Array.Reverse(numberAsChars);

            return double.Parse(new string(numberAsChars));
        }
    }
}
