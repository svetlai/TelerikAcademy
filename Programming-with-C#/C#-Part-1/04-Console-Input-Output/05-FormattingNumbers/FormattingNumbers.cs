namespace FormattingNumbers
{
    using System;
    using System.Globalization;
    using System.Threading;

    /// <summary>
    /// Problem 5. Formatting Numbers
    /// Write a program that reads 3 numbers:
    /// integer a (0 <= a <= 500)
    /// floating-point b
    /// floating-point c
    /// The program then prints them in 4 virtual columns on the console. Each column should have a width of 10 characters.
    /// The number a should be printed in hexadecimal, left aligned
    /// Then the number a should be printed in binary form, padded with zeroes
    /// The number b should be printed with 2 digits after the decimal point, right aligned
    /// The number c should be printed with 3 digits after the decimal point, left aligned.
    /// Examples:
    /// a	b	c	result
    /// 254	11.6	0.5	FE |0011111110| 11.60|0.500 |
    /// 499	-0.5559	10000	1F3 |0111110011| -0.56|10000 |
    /// 0	3	-0.1234	0 |0000000000| 3|-0.123 |
    /// </summary>
    public class FormattingNumbers
    {
        public static void Main()
        {
            Console.WriteLine("Problem 5. Formatting Numbers \nWrite a program that reads 3 numbers: \ninteger a (0 <= a <= 500) \nfloating-point b \nfloating-point c \nThe program then prints them in 4 virtual columns on the console. Each column should have a width of 10 characters. The number a should be printed in hexadecimal, left aligned Then the number a should be printed in binary form, padded with zeroes The number b should be printed with 2 digits after the decimal point, right aligned The number c should be printed with 3 digits after the decimal point, left aligned.");

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            try
            {
                Console.Write("Enter integer a (0 <= a <= 500): ");
                int first = int.Parse(Console.ReadLine());

                Console.Write("Enter floating-point b: ");
                double second = double.Parse(Console.ReadLine());

                Console.Write("Enter floating-point c: ");
                double third = double.Parse(Console.ReadLine());

                double sum = first + second + third;

                Console.WriteLine("{0,5} | {1,5} | {2,5} | {3,20}", "a", "b", "c", "result");
                Console.WriteLine("{0,5} | {1,5} | {2,5}|{0,10:X}|{3,10}|{1,10:0.00}|{2,-10:0.000}", first, second, third, Convert.ToString(first, 2).PadLeft(10, '0'));
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
