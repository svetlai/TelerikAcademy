namespace LargestAreaEmptyCells
{
    using System;
    using MatrixPassableCells;

    /// <summary>
    /// 9. Write a recursive program to find the largest connected area of adjacent empty cells in a matrix.
    /// </summary>
    public class LargestAreaEmptyCells
    {
        private static int currLength = 0;

        public static void Main()
        {
            int maxLength = 1;
            char charToCheck = ' ';
            char[,] matrix =
            {
                { ' ', ' ', ' ', '*', ' ', ' ', ' ' },
                { '*', '*', ' ', '*', ' ', '*', ' ' }, 
                { ' ', ' ', ' ', '*', ' ', ' ', ' ' }, 
                { ' ', '*', '*', '*', '*', ' ', '*' }, 
                { ' ', ' ', ' ', '*', ' ', ' ', ' ' }
            };
            bool[,] isVisited = new bool[matrix.GetLength(0), matrix.GetLength(1)];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    currLength = 0;
                    Move(matrix, isVisited, charToCheck, new Cell(r, c));
                    if (currLength > maxLength)
                    {
                        maxLength = currLength;
                    }
                }
            }

            Console.WriteLine("The maximal area of '{0}' consists of {1} elements.", charToCheck, maxLength);
        }

        private static void Move(char[,] matrix, bool[,] isVisited, char charToCheck, Cell start)
        {
            if (start.Row == matrix.GetLength(0) || start.Row < 0 || start.Col == matrix.GetLength(1) || start.Col < 0)
            {
                return;
            }

            if (isVisited[start.Row, start.Col])
            {
                return;
            }

            if (matrix[start.Row, start.Col] != charToCheck)
            {
                return;
            }

            currLength++;
            isVisited[start.Row, start.Col] = true;
            Move(matrix, isVisited, charToCheck, new Cell(start.Row + 1, start.Col));
            Move(matrix, isVisited, charToCheck, new Cell(start.Row - 1, start.Col));
            Move(matrix, isVisited, charToCheck, new Cell(start.Row, start.Col + 1));
            Move(matrix, isVisited, charToCheck, new Cell(start.Row, start.Col - 1));
        }
    }
}
