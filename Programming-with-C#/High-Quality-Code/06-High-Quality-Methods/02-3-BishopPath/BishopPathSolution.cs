namespace BishopPath
{
    using System.Collections.Generic;

    public class BishopPathSolution
    {
        public static long GetMovesSum(long[,] matrix, List<string[]> moves)
        {
            int row = matrix.GetLength(0) - 1;
            int col = 0;

            int previousRow = row;
            int previousCol = col;

            long sum = matrix[row, col];

            foreach (var move in moves)
            {
                string direction = move[0];
                int numberOfMoves = int.Parse(move[1]);

                while (numberOfMoves != 1)
                {
                    switch (direction)
                    {
                        case "UR":
                        case "RU":
                            row--;
                            col++;
                            break;
                        case "RD":
                        case "DR":
                            row++;
                            col++;
                            break;
                        case "DL":
                        case "LD":
                            row++;
                            col--;
                            break;
                        case "LU":
                        case "UL":
                            row--;
                            col--;
                            break;
                    }

                    if (row == matrix.GetLength(0) || col == matrix.GetLength(1) || row == -1 || col == -1)
                    {
                        row = previousRow;
                        col = previousCol;
                        break;
                    }

                    sum += matrix[row, col];
                    matrix[row, col] = 0;

                    previousRow = row;
                    previousCol = col;

                    numberOfMoves--;
                }
            }

            return sum;
        }
    }
}
