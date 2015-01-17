namespace ThirdDigitIsSeven
{
    using System;
    using System.Globalization;
    using System.Threading;

    /// <summary>
    /// Problem 5.	Third Digit is 7?
    /// Write an expression that checks for given integer if its third digit from right-to-left is `7`.
    /// Examples:
    /// |    n    | Third digit 7? |
    /// |:-------:|:--------------:|
    /// | 5       | false          |
    /// | 701     | true           |
    /// | 9703    | true           |
    /// | 877     | false          |
    /// | 777877  | false          |
    /// | 9999799 | true           |
    /// </summary>
    public class ThirdDigitIsSeven
    {
        public static void Main()
        {
            // display examples
            int[] numbers = { 5, 701, 9703, 877, 777877, 9999799 };
            bool isDivided;

            Console.WriteLine("{0,10} | {1,10}", "n", "Third digit 7?");

            for (int i = 0; i < numbers.Length; i++)
            {
                isDivided = IsThirdDigitSeven(numbers[i]);
                Console.WriteLine("{0,10} | {1,10}", numbers[i], isDivided);
            }

            Console.WriteLine();

            // read inputs from the console and make calculations based on them
            Console.Write("Try it Yourself! \nEnter an integer number: ");

            string line = Console.ReadLine();

            while (line != string.Empty)
            {
                try
                {
                    int input = int.Parse(line);
                    Console.WriteLine(IsThirdDigitSeven(input));
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.Write("Enter an integer number: ");
                line = Console.ReadLine();
            }
        }

        /// <summary>
        /// Checks if third digit is seven
        /// </summary>
        /// <param name="number">Integer</param>
        /// <returns>Boolean - true if third digit is seven</returns>
        public static bool IsThirdDigitSeven(int number)
        {
            if ((number / 100) % 10 == 7)
            {
                return true;
            }

            return false;
        }
    }
}
