namespace PrimeNumberCheck
{
    using System;

    /// <summary>
    /// Problem 8.	Prime Number Check
    /// Write an expression that checks if given positive integer number n (n = 100) is prime (i.e. it is divisible without remainder only to itself and 1).
    /// Examples:
    /// |  n | Prime? |
    /// |:--:|:------:|
    /// | 1  | false  |
    /// | 2  | true   |
    /// | 3  | true   |
    /// | 4  | false  |
    /// | 9  | false  |
    /// | 97 | true   |
    /// | 51 | false  |
    /// | -3 | false  |
    /// | 0  | false  |
    /// </summary>
    public class PrimeNumberCheck
    {
        public static void Main()
        {
            Console.WriteLine("Is number prime?");

            // display examples
            int[] numbers = { 1, 2, 3, 4, 9, 97, 51, -3, 0 };
            bool isPrime;

            Console.WriteLine("{0,10} | {1,10}", "n", "Prime?");

            for (int i = 0; i < numbers.Length; i++)
            {
                isPrime = IsPrime(numbers[i]);
                Console.WriteLine("{0,10} | {1,10}", numbers[i], isPrime);
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
                    Console.WriteLine(IsPrime(input));
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.Write("Enter an integer number: ");
                line = Console.ReadLine();              
            }
        }

        public static bool IsPrime(int number)
        {
            if (number < 0 || number >= 100)
            {
                return false;
            }

            // It's enough to check for every i until the square root of the number. 
            // After that up until the number, the combinations of multiplying numbers is the same, only reversed.
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                // A number is prime if it can be divided without a reminder only by one and itself;
                if (number % i == 0 && number > 2)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
