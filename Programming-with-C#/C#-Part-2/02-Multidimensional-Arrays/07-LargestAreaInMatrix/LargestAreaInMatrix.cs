namespace LargestAreaInMatrix
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Problem 7.* Largest area in matrix
    /// Write a program that finds the largest area of equal neighbour elements in a rectangular matrix and prints its size.
    /// </summary>
    public class LargestAreaInMatrix
    {
        private static readonly string Border = new string('-', 60);

        public static void Main()
        {
            Console.WriteLine("Problem 7.* Largest area in matrix \nWrite a program that finds the largest area of equal neighbour elements in a rectangular matrix and prints its size.");

            int[,] matrix = GetRandomIntMatrix(5, 5);           
            int largestAreaSize = FindLargestEqualAreaInMatrix(matrix);

            // print
            Console.WriteLine(Border);
            PrintMatrix(matrix);
            Console.WriteLine(Border);
            Console.WriteLine("The largest area in the matrix has a size of: {0}", largestAreaSize);
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
                    matrix[row, col] = random.Next(0, 3);
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

        public static int FindLargestEqualAreaInMatrix(int[,] matrix)
        {
            Queue<Cell> queue = new Queue<Cell>();
            HashSet<Cell> visited = new HashSet<Cell>();

            Cell bestCell = null;
            int count = 1;
            int maxCount = int.MinValue;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    // BFS
                    count = 1;
                    Cell startCell = new Cell(row, col, matrix);
                    queue.Enqueue(startCell);
                    visited.Add(startCell);

                    while (queue.Count > 0)
                    {
                        Cell currentCell = queue.Dequeue();

                        // action here
                        // check if neibghbour cell has the same value
                        // left
                        if (currentCell.Col > 0)
                        {
                            EnqueueNewCell(currentCell.Row, currentCell.Col - 1, currentCell.Value, matrix, ref count, ref visited, ref queue);
                        }

                        // right
                        if (currentCell.Col < matrix.GetLength(1) - 1)
                        {
                            EnqueueNewCell(currentCell.Row, currentCell.Col + 1, currentCell.Value, matrix, ref count, ref visited, ref queue);
                        }

                        // up
                        if (currentCell.Row > 0)
                        {
                            EnqueueNewCell(currentCell.Row - 1, currentCell.Col, currentCell.Value, matrix, ref count, ref visited, ref queue);
                        }

                        // down
                        if (currentCell.Row < matrix.GetLength(0) - 1)
                        {
                            EnqueueNewCell(currentCell.Row + 1, currentCell.Col, currentCell.Value, matrix, ref count, ref visited, ref queue);
                        }
                    }

                    // check if current count is bigger than the max count so far and assign its value to it if it is
                    if (count > maxCount)
                    {
                        maxCount = count;
                        bestCell = startCell;
                    }
                }
            }

            return maxCount;
        }

        /// <summary>
        /// A helper method for the BFS - creates a new cell and checks if its suitable - if yes - it's added to the queue and marked as visted
        /// </summary>
        /// <param name="row">The new cell's row</param>
        /// <param name="col">The new cell's col</param>
        /// <param name="oldCellValue">The value of the cell to comapre with</param>
        /// <param name="matrix">The matrix that's being traversed</param>
        /// <param name="count">Adds one to count if the cell is suitable</param>
        /// <param name="visited">A hashset for all visited cells</param>
        /// <param name="queue">A queue needed for the BFS</param>
        private static void EnqueueNewCell(int row, int col, int oldCellValue, int[,] matrix, ref int count, ref HashSet<Cell> visited, ref Queue<Cell> queue)
        {
            Cell newCell = new Cell(row, col, matrix);

            if (!visited.Contains(newCell) && oldCellValue == newCell.Value)
            {
                queue.Enqueue(newCell);
                visited.Add(newCell);
                count++;
            }
        }
    }
}
