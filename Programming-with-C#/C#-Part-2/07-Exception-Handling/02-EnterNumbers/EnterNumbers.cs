namespace EnterNumbers
{
    using System;

    /// <summary>
    /// Problem 2. Enter numbers
    /// Write a method `ReadNumber(int start, int end)` that enters an integer number in a given range [`start�end`].
    /// * If an invalid number or non-number text is entered, the method should throw an exception.
    /// Using this method write a program that enters `10` numbers: `a1, a2, ... a10`, such that `1 < a1 < ... < a10 < 100`
    /// </summary>
    public class EnterNumbers
    {
        public static void Main()
        {
            Console.WriteLine("Problem 2. Enter numbers \nWrite a method `ReadNumber(int start, int end)` that enters an integer number in a given range [`start�end`]. \nIf an invalid number or non-number text is entered, the method should throw an exception. \nUsing this method write a program that enters `10` numbers: `a1, a2, ... a10`, such that `1 < a1 < ... < a10 < 100`\n");
            const int TotalNumbers = 10;

            int start = 1;
            int end = 100;
            int number = 0;

            for (int i = 0; i < TotalNumbers; i++)
            {
                Console.Write("Please enter an integer number between {0} and {1}: ", start, end);
                
                try
                {
                    number = ReadNumber(start, end);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }

                start = number;
            }
        }

        public static int ReadNumber(int start, int end)
        {
            int number = int.Parse(Console.ReadLine());

            if (number < start || number > end)
            {
                throw new ArgumentException("Input number was out of range.");
            }

            return number;
        }
    }
}
