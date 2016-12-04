namespace PathExists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MatrixPassableCells;

    /// <summary>
    /// 8.Modify the above program to check whether a path exists between two cells without finding all possible paths.
    // Test it over an empty 100 x 100 matrix.
    /// </summary>
    public class PathExists
    {
        public static void Main()
        {
            char[,] matrix = new char[100, 100];
            var startCell = new Cell(0, 0);
            var endCell = new Cell(45, 45);
            bool foundExit = false;
            GetPath(matrix, startCell, endCell, ref foundExit);
            Console.WriteLine(foundExit ? "Yes, there is an exit." : "No, there is no exit.");
        }

        private static void GetPath(char[,] matrix, Cell start, Cell end, ref bool foundExit)
        {
            if (foundExit)
            {
                return;                                     // already found the solution and other cases are not interesting
            }

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
                foundExit = true;                           // found exit
                return;
            }

            matrix[start.Row, start.Col] = '*';
            GetPath(matrix, new Cell(start.Row + 1, start.Col), end, ref foundExit);
            GetPath(matrix, new Cell(start.Row, start.Col + 1), end, ref foundExit);
            GetPath(matrix, new Cell(start.Row - 1, start.Col), end, ref foundExit);
            GetPath(matrix, new Cell(start.Row, start.Col - 1), end, ref foundExit);
            matrix[start.Row, start.Col] = ' ';
        }
    }
}
