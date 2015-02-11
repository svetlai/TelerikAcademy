namespace MaximalSum
{
    using System;

    /// <summary>
    /// Problem 2. Maximal sum
    /// Write a program that reads a rectangular matrix of size `N x M` and finds in it the square `3 x 3` that has maximal sum of its elements.
    /// </summary>
    public class MaximalSum
    {
        private const string FormatExceptionMessage = "Input not in the correct format or range.";
        private static readonly string Border = new string('-', 60);

        public static void Main()
        {
            Console.WriteLine("Problem 2. Maximal sum \nWrite a program that reads a rectangular matrix of size `N x M` and finds in it the square `3 x 3` that has maximal sum of its elements.\n");

            const int SubMatrixRows = 3;
            const int SubMatrixCols = 3;

            // input
            Console.Write("Enter a positive integer number {0} < n < 20: ", SubMatrixRows);

            int n;
            if (!int.TryParse(Console.ReadLine(), out n) || n < SubMatrixRows || n > 20)
            {
                Console.WriteLine(FormatExceptionMessage);
                return;
            }

            Console.Write("Enter a positive integer number {0} < m < 20: ", SubMatrixCols);

            int m;
            if (!int.TryParse(Console.ReadLine(), out m) || m < SubMatrixCols || m > 20)
            {
                Console.WriteLine(FormatExceptionMessage);
                return;
            }

            // get maximal sum subMatrix
            int[,] matrix = GetRandomIntMatrix(n, m);

            int startRowIndex;
            int startColIndex;

            long maxSum = GetSubMatrixMaximalSum(matrix, SubMatrixRows, SubMatrixCols, out startRowIndex, out startColIndex);
            int[,] subMatrix = GetSubMatrix(matrix, startRowIndex, startColIndex, SubMatrixRows, SubMatrixCols);

            // print
            Console.WriteLine(Border);
            Console.WriteLine("Original matrix: ");
            PrintMatrix(matrix);
            Console.WriteLine(Border);
            Console.WriteLine("Maximal {1} x {2} subMatrix sum: {0}", maxSum, SubMatrixRows, SubMatrixCols);
            Console.WriteLine(Border);
            Console.WriteLine("Sub matrix: ");
            PrintMatrix(subMatrix);
            Console.WriteLine(Border);
        }

        public static int[,] GetRandomIntMatrix(int totalRows, int totalCols)
        {
            int[,] matrix = new int[totalRows, totalCols];
            Random random = new Random();

            for (int row = 0; row < totalRows; row++)
            {
                for (int col = 0; col < totalCols; col++)
                {
                    matrix[row, col] = random.Next(0, 99);
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

        /// <summary>
        /// Get the maximal sum of a submatrix with sizes subMatrixRowsCount x subMatrixColsCount in a matrix
        /// </summary>
        /// <param name="matrix">An input matrix to search in</param>
        /// <param name="subMatrixRowsCount">Total rows count of the submatrix</param>
        /// <param name="subMatrixColsCount">Total cols count of the submatrix</param>
        /// <param name="startRowIndex">The row index of the top left corner of the found submatrix</param>
        /// <param name="startColIndex">The col index of the top left corner of the found submatrix</param>
        /// <returns>The maximal sum of the submatrix' elements (long)</returns>
        public static long GetSubMatrixMaximalSum(int[,] matrix, int subMatrixRowsCount, int subMatrixColsCount, out int startRowIndex, out int startColIndex)
        {
            long sum = 0;
            long maxSum = long.MinValue;
            startRowIndex = -1;
            startColIndex = -1;

            for (int row = 0; row <= matrix.GetLength(0) - subMatrixRowsCount; row++)
            {
                for (int col = 0; col <= matrix.GetLength(1) - subMatrixColsCount; col++)
                {
                    sum = SumSubMatrix(matrix, row, col, 3, 3);

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        startRowIndex = row;
                        startColIndex = col;
                    }
                }
            }

            return maxSum;
            // return GetSubMatrix(matrix, startRowIndex, startColIndex, subMatrixRowsCount, subMatrixColsCount);
        }

        /// <summary>
        /// Gets a submatrix in a matrix
        /// </summary>
        /// <param name="matrix">An input matrix to search in</param>
        /// <param name="startRowIndex">The row index (in the matrix) of the top left corner of the wanted submatrix</param>
        /// <param name="startColIndex">The col index (in the matrix) of the top left corner of the wanted submatrix</param>
        /// <param name="subMatrixRowsCount">Total rows count of the submatrix</param>
        /// <param name="subMatrixColsCount">Total cols count of the submatrix</param>
        /// <returns></returns>
        public static int[,] GetSubMatrix(int[,] matrix, int startRowIndex, int startColIndex, int subMatrixRowsCount, int subMatrixColsCount)
        {
            int[,] subMatrix = new int[subMatrixRowsCount, subMatrixColsCount];

            for (int row = startRowIndex, i = 0; row < startRowIndex + subMatrixRowsCount; row++, i++)
            {
                for (int col = startColIndex, j = 0; col < startColIndex + subMatrixColsCount; col++, j++)
                {
                    subMatrix[i, j] = matrix[row, col];
                }
            }

            return subMatrix;
        }

        /// <summary>
        /// Sum the elements of a submatrix with size subMatrixRowsCount x subMatrixColsCount in a matrix with
        /// </summary>
        /// <param name="matrix">An input matrix to search in</param>
        /// <param name="rowStart">Row index to start from</param>
        /// <param name="colStart">Col index to start from</param>
        /// <param name="subMatrixRowsCount">Total rows count of the submatrix</param>
        /// <param name="subMatrixColsCount">Total cols count of the submatrix</param>
        /// <returns></returns>
        private static long SumSubMatrix(int[,] matrix, int rowStart, int colStart, int subMatrixRowsCount, int subMatrixColsCount)
        {
            long sum = 0;

            for (int i = rowStart; i < rowStart + subMatrixRowsCount; i++)
            {
                for (int j = colStart; j < colStart + subMatrixColsCount; j++)
                {
                    sum += matrix[i, j];
                }
            }

            return sum;
        }
    }
}
