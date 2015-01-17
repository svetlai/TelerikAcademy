namespace FourDigitNumber
{
    using System;
    using System.Globalization;
    using System.Threading;

    /// <summary>
    /// Problem 6.	Four-Digit Number
    /// Write a program that takes as input a four-digit number in format abcd (e.g. 2011) and performs the following:
    /// Calculates the sum of the digits (in our example `2 + 0 + 1 + 1 = 4`).
    /// Prints on the console the number in reversed order: `dcba` (in our example `1102`).
    /// Puts the last digit in the first position: `dabc` (in our example `1201`).
    /// Exchanges the second and the third digits: `acbd` (in our example `2101`).
    /// The number has always exactly 4 digits and cannot start with 0.
    /// Examples:
    /// |    n    | sum of digits | reversed | last digit in front | second and third digits exchanged |
    /// |:-------:|:-------------:|:--------:|:-------------------:|:---------------------------------:|
    /// | 2011    | 4             | 1102     | 1201                | 2101                              |
    /// | 3333    | 12            | 3333     | 3333                | 3333                              |
    /// | 9876    | 30            | 6789     | 6987                | 9786                              |
    /// </summary>
    public class FourDigitNumber
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Console.WindowWidth = 100;

            // display examples
            int[] numbers = { 2011, 3333, 9876 };
            int sum;
            int reversed;
            int lastToFront;
            int swapped;

            Console.WriteLine("{0,5} | {1,10} | {2,7} | {3,10} | {4,10}", "n", "sum of digits", "reversed", "last digit in front", "2nd and 3rd digits exchanged");

            for (int i = 0; i < numbers.Length; i++)
            {
                sum = SumDigits(numbers[i]);
                reversed = ReverseDigits(numbers[i]);
                lastToFront = MoveLastDigitToFront(numbers[i]);
                swapped = ExchangeSecondAndThirdDigits(numbers[i]);

                Console.WriteLine("{0,5} | {1,10} | {2,7} | {3,10} | {4,10}", numbers[i], sum, reversed, lastToFront, swapped);
            }

            Console.WriteLine();

            // read inputs from the console and make calculations based on them
            Console.Write("Try it Yourself! \nEnter a four digit number: ");

            string line = Console.ReadLine();

            while (line != string.Empty)
            {
                if (line.Length == 4)
                {
                    try
                    {
                        int input = int.Parse(line);

                        Console.WriteLine("Sum: {0}", SumDigits(input));
                        Console.WriteLine("Reversed: {0}", ReverseDigits(input));
                        Console.WriteLine("Last digit in front: {0}", MoveLastDigitToFront(input));
                        Console.WriteLine("2nd and 3rd digits exchanged: {0}", ExchangeSecondAndThirdDigits(input));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a four-digit number.");
                }

                Console.Write("Enter a four digit number: ");
                line = Console.ReadLine();
            }
        }

        public static int SumDigits(int number)
        {
            int sum = 0;

            while (number != 0)
            {
                sum += number % 10;
                number = number / 10;
            }

            return sum;
        }

        public static int ReverseDigits(int number)
        {
            int reversed = 0;
            int currentDigit;

            while (number > 0)
            {
                currentDigit = number % 10;
                reversed = reversed * 10 + currentDigit;
                number = number / 10;
            }

            return reversed;
        }

        public static int MoveLastDigitToFront(int number)
        {
            int lastDigit = number % 10;
            double numberOfDigits = Math.Floor(Math.Log10(number) + 1); // 4

            number = (int)Math.Pow(10, numberOfDigits - 1) // 10 on power (the number of digits - 1) --> gives 1000 if digits are 4 
                * lastDigit // multiplied by the last digit --> the last digit becomes first
                + (number / 10); // divide by ten to dispose of the last digit and add it to the number above

            return number;
        }

        public static int ExchangeSecondAndThirdDigits(int number)
        {
            string numberAsString = number.ToString();

            string newNumber = numberAsString[0].ToString() + numberAsString[2] + numberAsString[1] + numberAsString[3];

            //if the number has more than four digits:
            //for (int i = 3; i < numberAsString.Length; i++)
            //{
            //    newNumber += numberAsString[i];
            //}

            number = int.Parse(newNumber);

            return number;
        }
    }
}
