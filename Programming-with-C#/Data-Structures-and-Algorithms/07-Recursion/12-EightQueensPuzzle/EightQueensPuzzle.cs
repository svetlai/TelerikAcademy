namespace EightQueensPuzzle
{
    using System;

    /// <summary>
    /// 12.* Write a recursive program to solve the "8 Queens Puzzle" with backtracking.
    /// Learn more at: http://en.wikipedia.org/wiki/Eight_queens_puzzle
    /// </summary>
    public class EightQueensPuzzle
    {
        public static void Main()
        {
            var solutionsCount = 0;
            var n = 8;
            var board = new int[n, n];
            PlaceQueen(board, 0, ref solutionsCount);
            Console.WriteLine(solutionsCount);
        }

        private static void PlaceQueen(int[,] board, int col, ref int solutionsCount)
        {
            if (col == board.GetLength(0))
            {
                solutionsCount++;

                return;
            }

            for (int row = 0; row < board.GetLength(1); row++)
            {
                if (board[row, col] == 0)
                {
                    MarkBoard(board, row, col, true);
                    PlaceQueen(board, col + 1, ref solutionsCount);
                    MarkBoard(board, row, col, false);
                }
            }
        }

        private static void MarkBoard(int[,] board, int r, int c, bool value)
        {
            for (int i = c; i < board.GetLength(0); i++)
            {
                board[r, i] += value ? 1 : -1;

                if (r + i - c < board.GetLength(1))
                {
                    board[r + i - c, i] += value ? 1 : -1;
                }

                if (r - i + c >= 0)
                {
                    board[r - i + c, i] += value ? 1 : -1;
                }
            }
        }
    }
}
