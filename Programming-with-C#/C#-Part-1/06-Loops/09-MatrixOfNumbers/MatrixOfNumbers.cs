namespace MatrixOfNumbers
{
    using System;

    /// <summary>
    /// Problem 9. Matrix of Numbers
    /// Write a program that reads from the console a positive integer number n (1 < n < 20) and prints a matrix like in the examples below. 
    /// Use two nested loops.
    /// Examples:
    /// n = 2   matrix      n = 3   matrix      n = 4   matrix
    /// 1 2                 1 2 3               1 2 3 4
    /// 2 3                 2 3 4               2 3 4 5
    ///                     3 4 5               3 4 5 6
    ///                                         4 5 6 7
    /// </summary>
    public class MatrixOfNumbers
    {
        public static void Main()
        {
            Console.WriteLine("Problem 9. Matrix of Numbers \nWrite a program that reads from the console a positive integer number n (1 < n < 20) and prints a matrix like in the examples below. Use two nested loops.\n");

            Console.Write("Enter an integer n so that 1 < n < 20: ");

            int n;
            if (!int.TryParse(Console.ReadLine(), out n) || n <= 1 || n >= 20)
            {
                Console.WriteLine("Input not in the correct format or range.");
                return;
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(col + row + 1);
                }

                Console.WriteLine();
            }
        }
    }
}
