namespace FillTheMatrix
{
    using System;

    /// <summary>
    /// Problem 1. Fill the matrix
    /// Write a program that fills and prints a matrix of size `(n, n)` as shown below:
    /// </summary>
    public class FillTheMatrix
    {
        private const string FormatExceptionMessage = "Input not in the correct format or range.";
        private static readonly string Border = new string('-', 60);

        public static void Main()
        {
            Console.WriteLine("Problem 1. Fill the matrix \nWrite a program that fills and prints a matrix of size `(n, n)` as shown below:");
            Console.WriteLine("A)               B)              C)                 D)");
            Console.WriteLine("1  5  9   13  |  1  8  9   16  |  7  11  14  16  |  1  12  11  10 ");
            Console.WriteLine("2  6  10  14  |  2  7  10  15  |  4  8   12  15  |  2  13  16  9 ");
            Console.WriteLine("3  7  11  15  |  3  6  11  14  |  2  5   9   13  |  3  14  15  8 ");
            Console.WriteLine("4  8  12  16  |  4  5  12  13  |  1  3   6   10  |  4   5   6  7 ");
            Console.WriteLine(Border);

            Console.Write("Enter a positive integer number n: ");

            int n;
            if (!int.TryParse(Console.ReadLine(), out n) || n < 1)
            {
                Console.WriteLine(FormatExceptionMessage);
                return;
            }

            Console.WriteLine("A)");
            int[,] matrixA = FillTheMatrixA(n);
            PrintMatrix(matrixA);

            Console.WriteLine("B)");
            int[,] matrixB = FillTheMatrixB(n);
            PrintMatrix(matrixB);

            Console.WriteLine("C)");
            int[,] matrixC = FillTheMatrixC(n);
            PrintMatrix(matrixC);

            Console.WriteLine("D)");
            int[,] matrixD = FillTheMatrixD(n);
            PrintMatrix(matrixD);
        }

        // A)
        // 1  5  9   13
        // 2  6  10  14
        // 3  7  11  15
        // 4  8  12  16
        public static int[,] FillTheMatrixA(int n)
        {
            int[,] matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = row + (col * n) + 1;
                }
            }

            return matrix;
        }

        // B)
        // 1  8  9   16
        // 2  7  10  15
        // 3  6  11  14
        // 4  5  12  13
        public static int[,] FillTheMatrixB(int n)
        {
            int[,] matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = (col % 2 == 0) ? (row + col * n + 1) : (n - row + col * n);
                }
            }

            return matrix;
        }

        // C) 
        // 7  11 14  16 
        // 4  8  12  15
        // 2  5  9   13
        // 1  3  6   10
        public static int[,] FillTheMatrixC(int n)
        {
            int[,] matrix = new int[n, n];

            int number = 1;
            int stopAtRow = 0;

            // 7
            // 4  8
            // 2  5  9
            // 1  3  6  10
            for (int col = 0; col < n; col++)
            {
                for (int row = n - 1; row >= stopAtRow; row--)
                {
                    matrix[row, col] = number;
                    number += (n - row) + col;
                }

                number = matrix[n - 2, col] + 1;
                stopAtRow++;
            }

            number = n * n;
            stopAtRow = n - 2;
 
            //      11  14  16 
            //          12  15
            //              13
            //
            for (int col = n - 1; col > 0; col--)
            {
                for (int row = 0; row <= stopAtRow; row++)
                {
                    matrix[row, col] = number;
                    number -= (n - col) + row;
                }

                number = matrix[1, col] - 1;
                stopAtRow--;
            }          

            return matrix;
        }

        // D)
        //  1  12  11  10   
        //  2  13  16  9
        //  3  14  15  8
        //  4  5   6   7   
        public static int[,] FillTheMatrixD(int n)
        {
            // using the approach, introduced in Fundamentals of Computer Programming with C# - Chapter 26
            int[,] matrix = new int[n, n];

            // starting point
            int currentRow = 0;
            int currentCol = 0;

            int direction = 1;  // initial direction --> down;
            int stepsCount = n - 1; // initial steps count
            int stepsPerformed = 0; // initial steps performed
            int stepsCountLoop = 3; // stepsCount first changes after 3 loops of the same number of steps and then every 2 loops
            
            // Example:
            //  1   12  11  10   
            //  2   13  16  9
            //  3   14  15  8
            //  4   5   6   7   
            // 3 steps v; 3 steps >; 3 steps ^; 2 steps <; 2 steps v; 1 step >; 1 step ^
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
                        currentCol--;   // right
                        break;
                    case 1:
                        currentRow++;   // down
                        break;
                    case 2:
                        currentCol++;   // right
                        break;
                    case 3:
                        currentRow--;   // up
                        break;
                }
            }

            return matrix;
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
