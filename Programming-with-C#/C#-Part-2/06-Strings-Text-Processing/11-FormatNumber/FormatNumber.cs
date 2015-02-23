namespace FormatNumber
{
    using System;
    using System.Text;

    /// <summary>
    /// Problem 11. Format number
    /// Write a program that reads a number and prints it as a decimal number, hexadecimal number, percentage and in scientific notation.
    /// Format the output aligned right in 15 symbols.
    /// </summary>
    public class FormatNumber
    {
        public static void Main()
        {
            Console.WriteLine("Problem 11. Format number \nWrite a program that reads a number and prints it as a decimal number, hexadecimal number, percentage and in scientific notation. \nFormat the output aligned right in 15 symbols.\n");
            
            int number = ReadNumberFromConsole();
            string format = PickFromat();

            PrintNumberInFormat(number, format);
        }

        public static int ReadNumberFromConsole()
        {
            Console.Write("Please enter an integer number: ");

            int number;
            if (!int.TryParse(Console.ReadLine(), out number))
            {
                throw new FormatException("Input was not in the correct format.");
            }

            return number;
        }

        public static string PickFromat()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Please select format: ")
                .AppendLine("Press D for Decimal")
                .AppendLine("Press X for Hexadecimal")
                .AppendLine("Press P for Percentage")
                .AppendLine("Press E for Scientific notation");

            Console.Write(sb.ToString());
            Console.Write("Your choice: ");

            return Console.ReadLine();
        }

        public static void PrintNumberInFormat(int number, string format)
        {
            format = format.ToUpper();

            switch (format)
            {
                case "D":
                    Console.WriteLine("{0,15:D}", number);
                    break;
                case "X":
                    Console.WriteLine("{0,15:X}", number);
                    break;
                case "P":
                    Console.WriteLine("{0,15:P}", number);
                    break;
                case "E":
                    Console.WriteLine("{0,15:E}", number);
                    break;
                default:
                    throw new ArgumentException("Input was not in the correct format.");
            }
        }
    }
}
