namespace MaximalAreaSum
{
    using System;
    using System.IO;

    /// <summary>
    /// Problem 5. Maximal area sum
    /// Write a program that reads a text file containing a square matrix of numbers.
    /// Find an area of size `2 x 2` in the matrix, with a maximal sum of its elements
    /// * The first line in the input file contains the size of matrix `N`.
    /// * Each of the next `N` lines contain `N` numbers separated by space.
    /// * The output should be a single number in a separate text file.
    /// Example:
    /// | input | output |
    /// |-------|--------|
    /// | 4 <br> 2 3 3 4 <br> 0 2 3 4 <br> 3 7 1 2 <br> 4 3 3 2 | 17 |
    /// </summary>
    public class MaximalAreaSum
    {
        public static void Main()
        {
            Console.WriteLine("Problem 5. Maximal area sum \nWrite a program that reads a text file containing a square matrix of numbers. \nFind an area of size `2 x 2` in the matrix, with a maximal sum of its elements\n");
            
            string path = "../../matrix.txt";
            int subMatrixSize = 2;

            int[,] matrix = GetMatrixFromFile(path);
            long maximalSum = GetSubMatrixMaximalSum(matrix, subMatrixSize, subMatrixSize);

            string pathSum = "../../matrixSum.txt";
            SaveSumToFile(pathSum, maximalSum);
        }

        public static void SaveSumToFile(string path, long sum)
        {
            var writer = new StreamWriter(path);
            using (writer)
            {
                writer.WriteLine(sum);
            }

            Console.WriteLine("File was written successfully at {0}.", new FileInfo(path).FullName);
        }

        public static int[,] GetMatrixFromFile(string path)
        {
            var reader = new StreamReader(path);
            int[,] matrix;

            using (reader)
            {
                int n = int.Parse(reader.ReadLine());
                matrix = new int[n, n];

                for (int i = 0; i < n; i++)
                {
                    string line = reader.ReadLine();
                    int[] row = ConvertStringOfIntsToArray(line);

                    for (int j = 0; j < n; j++)
                    {
                        matrix[i, j] = row[j];                       
                    }
                }
            }

            return matrix;
        }

        public static long GetSubMatrixMaximalSum(int[,] matrix, int subMatrixRowsCount, int subMatrixColsCount)
        {
            long sum = 0;
            long maxSum = long.MinValue;

            for (int row = 0; row <= matrix.GetLength(0) - subMatrixRowsCount; row++)
            {
                for (int col = 0; col <= matrix.GetLength(1) - subMatrixColsCount; col++)
                {
                    sum = SumSubMatrix(matrix, row, col, subMatrixRowsCount, subMatrixColsCount);

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                    }
                }
            }

            return maxSum;
        }

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

        private static int[] ConvertStringOfIntsToArray(string text)
        {
            return Array.ConvertAll(text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
        }
    }
}
