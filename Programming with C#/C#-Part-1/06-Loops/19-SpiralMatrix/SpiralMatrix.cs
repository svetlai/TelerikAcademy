namespace SpiralMatrix
{
    using System;

    /// <summary>
    /// Problem 19.** Spiral Matrix
    /// Write a program that reads from the console a positive integer number n (1 = n = 20) and prints a matrix holding the numbers from 1 to n*n in the form of square spiral like in the examples below.
    /// Examples:
    /// n = 2   matrix      n = 3   matrix      n = 4   matrix
    ///    1 2                 1 2 3               1  2  3  4
    ///    4 3                 8 9 4               12 13 14 5
    ///                        7 6 5               11 16 15 6
    ///                                            10 9  8  7
    /// </summary>
    public class SpiralMatrix
    {
        public static void Main()
        {
            Console.WriteLine("Problem 19.** Spiral Matrix \nWrite a program that reads from the console a positive integer number n (1 < n < 20) and prints a matrix holding the numbers from 1 to n*n in the form of square spiral like in the examples below.\n");

            // read input from the console
            Console.Write("Please enter an integer number n: ");

            int n;
            if (!int.TryParse(Console.ReadLine(), out n) || n <= 1 || n >= 20)
            {
                Console.WriteLine("Input not in the correct format or range.");
                return;
            }

            // using the approach, introduced in Fundamentals of Computer Programming with C# - Chapter 26
            int[,] matrix = new int[n, n];

            // starting point
            int currentRow = 0;
            int currentCol = 0;

            int direction = 0;  // initial direction --> right;
            int stepsCount = n - 1; // initial steps count
            int stepsPerformed = 0; // initial steps performed
            int stepsCountLoop = 3; // stepsCount first changes after 3 loops of the same number of steps and then every 2 loops
            // Example:
            //  1  2  3  4   
            // 12 13 14  5
            // 11 16 15  6
            // 10  9  8  7   
            // 3 steps >; 3 steps v; 3 steps <; 2 steps ^; 2 steps >; 1 step v; 1 step <
            // 3 times x 3 steps; 2 times x 2 steps; 2 times x 1 step

            for (int i = 0; i < n * n; i++)
            {
                // current cell = current value
                matrix[currentRow, currentCol] = i + 1;

                // while performed steps are less than the max stepsCount increase performed steps
                if (stepsPerformed < stepsCount)
                {
                    stepsPerformed++;
                }
                else
                {
                    // we need to perform the same amount of steps stepsCountLoop number of times before we change the steps count so we decrease after each performance until we reach 0
                    stepsCountLoop--;

                    // once we've performed it stepsCountChange of times - we change the steps count
                    if (stepsCountLoop == 0)
                    {
                        // step count decreases with 1 every 2 steps
                        stepsCountLoop = 2;
                        stepsCount--;
                    }

                    // reset stepsPerformed and change direction
                    stepsPerformed = 1;
                    direction = (direction + 1) % 4;
                }

                // move to next cell according to direction
                switch (direction)
                {
                    case 0:
                        currentCol++;   // right
                        break;
                    case 1:
                        currentRow++;   // down
                        break;
                    case 2:
                        currentCol--;   // left
                        break;
                    case 3:
                        currentRow--;   // up
                        break;
                }
            }

            PrintMatrix(matrix, n);
        }

        public static void PrintMatrix(int[,] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0,3}", matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
