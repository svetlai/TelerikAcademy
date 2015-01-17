namespace OddOrEvenIntegers
{
    using System;

    /// <summary>
    /// Problem 1.	Odd or Even Integers
    /// Write an expression that checks if given integer is odd or even.
    /// Examples:
    /// |  n |  Odd? |
    /// |:--:|:-----:|
    /// | 3  | true  |
    /// | 2  | false |
    /// | -2 | false |
    /// | -1 | true  |
    /// | 0  | false |
    /// </summary>
    public class OddOrEvenIntegers
    {
        public static void Main()
        {
            // display examples
            int[] numbers = { 3, 2, -2, -1, 0 };
            bool odd;

            Console.WriteLine("{0,5} | {1,5}", "n", "Odd?");

            for (int i = 0; i < numbers.Length; i++)
            {
                odd = CheckIfOdd(numbers[i]);
                Console.WriteLine("{0,5} | {1,5}", numbers[i], odd);
            }

            Console.WriteLine();

            // read inputs from the console and make calculations based on them
            Console.Write("Try it yourself! \nEnter an integer number: ");

            string line = Console.ReadLine();

            while (line != string.Empty)
            {
                try
                {
                    int input = int.Parse(line);
                    odd = CheckIfOdd(input);

                    Console.WriteLine("Odd? --> {0}", odd);
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
        /// Checks if given integer is odd
        /// </summary>
        /// <param name="number">An integer number</param>
        public static bool CheckIfOdd(int number)
        {
            if (number % 2 == 0)
            {
                return false;
            }

            return true;
        }
    }
}
