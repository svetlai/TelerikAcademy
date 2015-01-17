namespace DivideBySevenAndFive
{
    using System;

    /// <summary>
    /// Problem 3.	Divide by 7 and 5
    /// Write a Boolean expression that checks for given integer if it can be divided (without remainder) by `7` and `5` at the same time.
    /// Examples:
    /// |  n  | Divided by 7 and 5? |
    /// |:---:|:-------------------:|
    /// | 3   | false               |
    /// | 0   | false               |
    /// | 5   | false               |
    /// | 7   | false               |
    /// | 35  | true                |
    /// | 140 | true                |
    /// </summary>
    public class DivideBySevenAndFive
    {
        public static void Main()
        {
            // display examples
            int[] numbers = { 3, 0, 5, 7, 35, 140 };
            bool isDivided;

            Console.WriteLine("{0,5} | {1,5}", "n", "Divided by 7 and 5?");

            for (int i = 0; i < numbers.Length; i++)
            {
                isDivided = DivideByFiveAndSeven(numbers[i]);
                Console.WriteLine("{0,5} | {1,5}", numbers[i], isDivided);
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
                    Console.WriteLine(DivideByFiveAndSeven(input));
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
        /// Checks if a given integer number can be divided by 7 and 5 at the same time
        /// </summary>
        /// <param name="number">An integer number</param>
        /// <returns>Boolean</returns>
        public static bool DivideByFiveAndSeven(int number)
        {
            if (number % 7 == 0 && number % 5 == 0 && number != 0)
            {
                return true;
            }

            return false;
        }
    }
}
