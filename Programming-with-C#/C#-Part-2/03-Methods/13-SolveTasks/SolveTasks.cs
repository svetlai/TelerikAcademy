namespace SolveTasks
{
    using System;
    using System.Linq;

    /// <summary>
    /// Problem 13. Solve tasks
    /// Write a program that can solve these tasks:
    /// - Reverses the digits of a number
    /// - Calculates the average of a sequence of integers
    /// - Solves a linear equation `a * x + b = 0`
    /// Create appropriate methods.
    /// Provide a simple text-based menu for the user to choose which task to solve.
    /// Validate the input data:
    /// - The decimal number should be non-negative
    /// - The sequence should not be empty
    /// - `a` should not be equal to `0`
    /// </summary>
    public class SolveTasks
    {
        public static void Main()
        {
            ProcessCommands();
        }

        public static int ReverseNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number must be a positive integer.");
            }

            string numberAsString = number.ToString();
            char[] digits = numberAsString.ToCharArray();
            Array.Reverse(digits);

            return int.Parse(new string(digits));
        }

        public static int CalculateAverage(int[] set)
        {
            if (set.Length < 1)
            {
                throw new ArgumentException("The set cannot be empty.");
            }

            long sum = set.Sum();
            int average = (int)(sum / set.Length);

            return average;
        }

        // `a * x + b = 0`
        public static double SolveLinearEquation(double a, double b)
        {
            if (a == 0)
            {
                throw new ArgumentException("a cannot be 0.");
            }

            return (-b) / a;
        }

        private static void ProcessCommands()
        {
            Console.WriteLine("Please choose a task: \n1. Reverse Number \n2. Calculate Average \n3. Solve Linear Equation \n4. End");

            string command = Console.ReadLine();
            while (command != "4")
            {
                switch (command)
                {
                    case "1":
                        Console.WriteLine("Reverse number");
                        Console.Write("Enter a positive integer number: ");

                        int number;
                        if (!int.TryParse(Console.ReadLine(), out number))
                        {
                            throw new ArgumentException("Input was not in the correct format.");
                        }

                        int reversed = ReverseNumber(number);
                        Console.WriteLine("Reversed: {0}", reversed);
                        break;
                    case "2":
                        Console.WriteLine("Find the average in a set");
                        Console.Write("Enter a sequence of integer numbers separated by space: ");

                        int[] input = ConvertStringOfIntsToArray(Console.ReadLine());
                        int average = CalculateAverage(input);
                        Console.WriteLine("Average: {0}", average);
                        break;
                    case "3":
                        Console.WriteLine("Solve a linear equation a * x + b = 0");
                        Console.Write("Enter an integer number a != 0: ");

                        double a;
                        if (!double.TryParse(Console.ReadLine(), out a))
                        {
                            throw new ArgumentException("Input was not in the correct format.");
                        }

                        Console.Write("Enter an integer number b: ");

                        double b;
                        if (!double.TryParse(Console.ReadLine(), out b))
                        {
                            throw new ArgumentException("Input was not in the correct format.");
                        }

                        double equationResult = SolveLinearEquation(a, b);
                        Console.WriteLine("Equation result: {0}", equationResult);
                        break;
                }

                Console.Write("Choose another task: ");
                command = Console.ReadLine();
            }
        }

        private static int[] ConvertStringOfIntsToArray(string text)
        {
            return Array.ConvertAll(text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
        }
    }
}
