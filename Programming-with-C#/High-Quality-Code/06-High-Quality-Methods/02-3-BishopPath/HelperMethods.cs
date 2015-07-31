namespace BishopPath
{
    using System;
    using System.Collections.Generic;

    public static class HelperMethods
    {
        public static void PrintResult(long result)
        {
            Console.WriteLine(result);
        }

        public static List<string[]> GetMoves()
        {
            int n = int.Parse(Console.ReadLine());
            var moves = new List<string[]>();

            for (int i = 0; i < n; i++)
            {
                moves.Add(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            }

            return moves;
        }

        public static long[,] GetMatrix()
        {
            int[] matrixDims = ConvertStringOfIntsToArray(Console.ReadLine());
            return FillMatrix(matrixDims[0], matrixDims[1]);
        }

        private static long[,] FillMatrix(int rows, int cols)
        {
            long[,] matrix = new long[rows, cols];
            for (int row = rows - 1; row >= 0; row--)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = ((rows - 1) - row + col) * 3;
                }
            }

            return matrix;
        }

        private static int[] ConvertStringOfIntsToArray(string text)
        {
            return Array.ConvertAll(text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
        }
    }
}
