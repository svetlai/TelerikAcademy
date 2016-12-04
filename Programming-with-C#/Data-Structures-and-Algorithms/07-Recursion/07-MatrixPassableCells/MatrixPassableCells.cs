namespace MatrixPassableCells
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// // 7.We are given a matrix of passable and non-passable cells. Write a recursive program for finding all paths between two
    // cells in the matrix.
    /// </summary>
    public class MatrixPassableCells
    {
        public static void Main()
        {
            char[,] matrix =
            {
                { ' ', ' ', ' ', '*', ' ', ' ', ' ' },
                { '*', '*', ' ', '*', ' ', '*', ' ' }, 
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, 
                { ' ', '*', '*', '*', '*', '*', ' ' }, 
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
            };
            var startCell = new Cell(0, 0);
            var endCell = new Cell(4, 6);
            GetPath(matrix, startCell, endCell, new Stack<Cell>());
        }

        private static void GetPath(char[,] matrix, Cell start, Cell end, Stack<Cell> path)
        {
            if (start.Row >= matrix.GetLength(0) || start.Row < 0 || start.Col >= matrix.GetLength(1) || start.Col < 0) 
            {
                return;                                     // the cell is outside the matrix
            }

            if (matrix[start.Row, start.Col] == '*')         
            {
                return;                                     // the cell is not passable
            }

            if (start.Equals(end))
            {
                path.Push(end);
                Console.WriteLine("Path: {0}", string.Join(" ", path.Reverse()));    // found exit
                path.Pop();
                return;
            }

            matrix[start.Row, start.Col] = '*';
            path.Push(start);
            GetPath(matrix, new Cell(start.Row + 1, start.Col), end, path);
            GetPath(matrix, new Cell(start.Row, start.Col + 1), end, path);
            GetPath(matrix, new Cell(start.Row - 1, start.Col), end, path);
            GetPath(matrix, new Cell(start.Row, start.Col - 1), end, path);
            matrix[start.Row, start.Col] = ' ';
            path.Pop();
        }
    }
}
