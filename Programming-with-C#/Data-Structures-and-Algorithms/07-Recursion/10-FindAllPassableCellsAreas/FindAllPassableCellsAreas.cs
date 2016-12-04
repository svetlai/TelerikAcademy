namespace FindAllPassableCellsAreas
{
    using System;
    using System.Collections.Generic;
    using MatrixPassableCells;

    /// <summary>
    /// 10. * We are given a matrix of passable and non-passable cells. Write a recursive program for finding all
    // areas of passable cells in the matrix.
    /// </summary>
    public class FindAllPassableCellsAreas
    {
        public static void Main()
        {
            char charToCheck = ' ';
            char[,] matrix =
            {
                { ' ', ' ', ' ', '*', ' ', ' ', ' ' },
                { '*', '*', ' ', '*', ' ', '*', ' ' }, 
                { ' ', ' ', ' ', '*', ' ', ' ', ' ' }, 
                { ' ', '*', '*', '*', '*', '*', '*' }, 
                { ' ', ' ', ' ', '*', ' ', ' ', ' ' }
            };
            bool[,] isVisited = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            var areas = new HashSet<string>();

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    var area = new HashSet<Cell>();
                    Move(matrix, isVisited, charToCheck, new Cell(r, c), area);
                    if (area.Count > 0)
                    {
                        areas.Add(string.Format("Area: {0}", string.Join(" ", area)));
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, areas));
        }

        private static void Move(char[,] matrix, bool[,] isVisited, char charToCheck, Cell start, HashSet<Cell> area)
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

            isVisited[start.Row, start.Col] = true;
            area.Add(start);
            Move(matrix, isVisited, charToCheck, new Cell(start.Row + 1, start.Col), area);
            Move(matrix, isVisited, charToCheck, new Cell(start.Row - 1, start.Col), area);
            Move(matrix, isVisited, charToCheck, new Cell(start.Row, start.Col + 1), area);
            Move(matrix, isVisited, charToCheck, new Cell(start.Row, start.Col - 1), area);
        }
    }
}
