namespace SequenceNMatrix
{
    using System;
    using System.Linq;

    /// <summary>
    /// Problem 3. Sequence n matrix
    /// We are given a matrix of strings of size `N x M`. Sequences in the matrix we define as sets of several neighbour elements located on the same line, column or diagonal.
    /// Write a program that finds the longest sequence of equal strings in the matrix.
    /// </summary>
    public class SequenceNMatrix
    {
        private const string FormatExceptionMessage = "Input not in the correct format or range.";
        private static readonly string Border = new string('-', 60);

        public static void Main()
        {
            Console.WriteLine("Problem 3. Sequence n matrix \nWe are given a matrix of strings of size `N x M`. Sequences in the matrix we define as sets of several neighbour elements located on the same line, column or diagonal. \nWrite a program that finds the longest sequence of equal strings in the matrix.\n");
            
            // input
            Console.Write("Enter a positive integer number 1 < n < 20 for rows: ");

            int n;
            if (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 20)
            {
                Console.WriteLine(FormatExceptionMessage);
                return;
            }

            Console.Write("Enter a positive integer number 1 < m < 20 for cols: ");

            int m;
            if (!int.TryParse(Console.ReadLine(), out m) || m < 1 || m > 20)
            {
                Console.WriteLine(FormatExceptionMessage);
                return;
            }

            // find sequence in a random matrix
            string[] randomStrings = { "ha", "fifi", "ho", "xx", "ss", "q" };
            string[,] matrix = GetRandomStringMatrix(n, m, randomStrings);           
            string longestSequence = GetLongestSequence(matrix);

            // print
            Console.WriteLine(Border);
            PrintMatrix(matrix);
            Console.WriteLine(Border);
            Console.WriteLine("Longest sequence: {0}", longestSequence);
            Console.WriteLine(Border);
        }

        public static string[,] GetRandomStringMatrix(int totalRows, int totalCols, string[] randomStrings)
        {
            string[,] matrix = new string[totalRows, totalCols];
            Random random = new Random();

            for (int row = 0; row < totalRows; row++)
            {
                for (int col = 0; col < totalCols; col++)
                {
                    matrix[row, col] = randomStrings[random.Next(0, randomStrings.Length - 1)];
                }
            }

            return matrix;
        }

        public static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,5}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        public static string GetLongestSequence(string[,] matrix)
        {
            int maxCount = 0;
            string bestString = string.Empty;

            GetLongestSequenceInRow(matrix, ref maxCount, ref bestString);
            GetLongestSequenceInCol(matrix, ref maxCount, ref bestString);
            GetLongestSequenceInDiagonal(matrix, ref maxCount, ref bestString);

            return string.Join(", ", Enumerable.Repeat(bestString, maxCount).ToArray());
        }

        private static int GetLongestSequenceInRow(string[,] matrix, ref int maxCount, ref string bestString)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string currentString = matrix[row, 0];
                int count = 1;

                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    CountEqualElements(matrix[row, col], ref currentString, ref count, ref maxCount, ref bestString);
                }
            }

            return maxCount;
        }

        private static int GetLongestSequenceInCol(string[,] matrix, ref int maxCount, ref string bestString)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                string currentString = matrix[0, col];
                int count = 1;

                for (int row = 1; row < matrix.GetLength(0); row++)
                {
                    CountEqualElements(matrix[row, col], ref currentString, ref count, ref maxCount, ref bestString);
                }
            }

            return maxCount;
        }

        private static int GetLongestSequenceInDiagonal(string[,] matrix, ref int maxCount, ref string bestString)
        {
            string currentString = matrix[0, 0];
            int count = 1;

            // checks upper half for right-down and lower half for right-up diagonals > col by col going right
            for (int currentCol = 0; currentCol < matrix.GetLength(1); currentCol++)
            {
                // right-down diagonals
                currentString = matrix[0, currentCol];
                count = 1;

                // *ha  *fifi  *ho  *hi
                // fo   *ha    *hi  *xx
                // xxx   ho    *ha  *xx
                for (int row = 1, col = currentCol + 1; row < matrix.GetLength(0) && col < matrix.GetLength(1); row++, col++)
                {
                    CountEqualElements(matrix[row, col], ref currentString, ref count, ref maxCount, ref bestString);
                }

                // right-up diagonals
                // reset
                currentString = matrix[matrix.GetLength(0) - 1, currentCol];
                count = 1;

                // ha   fifi  *ho  *hi
                // fo    *ha  *hi  *xx
                // *xxx  *ho  *ha  *xx
                for (int row = matrix.GetLength(0) - 2, col = currentCol + 1; row >= 0 && col < matrix.GetLength(1); row--, col++)
                {
                    CountEqualElements(matrix[row, col], ref currentString, ref count, ref maxCount, ref bestString);
                }
            }

            // checks lower half for right-down and upper half for right-up diagonals > row by row going down
            for (int currentRow = 1; currentRow < matrix.GetLength(0) - 1; currentRow++)
            {
                // right-down diagonals
                currentString = matrix[currentRow, 0];
                count = 1;

                // ha    fifi  ho  hi
                // *fo    ha  hi  xx
                // *xxx  *ho  ha  xx
                for (int row = currentRow + 1, col = 1; row < matrix.GetLength(0) && col < matrix.GetLength(1) - 1; row++, col++)
                {
                    CountEqualElements(matrix[row, col], ref currentString, ref count, ref maxCount, ref bestString);
                }

                // right-up diagonals
                // reset
                currentString = matrix[matrix.GetLength(0) - 1 - currentRow, 0];
                count = 1;

                // *ha  *fifi ho  hi
                // *fo    ha  hi  xx
                // xxx    ho  ha  xx
                for (int row = matrix.GetLength(0) - 2 - currentRow, col = 1; row >= 0 && col < matrix.GetLength(1) - 1; row--, col++)
                {
                    CountEqualElements(matrix[row, col], ref currentString, ref count, ref maxCount, ref bestString);
                }
            }

            return maxCount;
        }

        private static void CountEqualElements(string first, ref string second, ref int count, ref int maxCount, ref string bestString)
        {
            if (first == second)
            {
                count++;

                if (count > maxCount)
                {
                    maxCount = count;
                    bestString = second;
                }
            }
            else
            {
                count = 1;
                second = first;
            }
        }
    }
}
