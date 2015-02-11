namespace MatrixClass
{
    using System;

    /// <summary>
    /// Problem 6.* Matrix class
    /// Write a class `Matrix`, to hold a matrix of integers. Overload the operators for adding, subtracting and multiplying of matrices, indexer for accessing the matrix content and `ToString()`.
    /// </summary>
    public class MatrixClass
    {
        private static readonly string Border = new string('-', 60);
        private static Random random = new Random();

        public static void Main()
        {
            Console.WriteLine("Problem 6.* Matrix class \nWrite a class `Matrix`, to hold a matrix of integers. Overload the operators for adding, subtracting and multiplying of matrices, indexer for accessing the matrix content and `ToString()`.");

            // playing with the Matrix class
            Matrix matrix = new Matrix(3, 3);
            matrix = FillMatrix(matrix);

            Matrix secondMatrix = new Matrix(3, 3);
            secondMatrix = FillMatrix(secondMatrix);

            Matrix added = matrix + secondMatrix;
            Matrix subtracted = matrix - secondMatrix;
            Matrix multiplied = matrix * secondMatrix;

            int index = matrix[1, 1];

            // print
            Console.WriteLine(Border + "\nMatrix A): ");
            Console.Write(matrix.ToString());
            Console.WriteLine(Border + "\nMatrix B): ");
            Console.Write(secondMatrix.ToString());
            Console.WriteLine(Border + "\nMatrix A + Matrix B: ");
            Console.Write(added.ToString());
            Console.WriteLine(Border + "\nMatrix A - Matrix B: ");
            Console.Write(subtracted.ToString());
            Console.WriteLine(Border + "\nMatrix A * Matrix B: ");
            Console.Write(multiplied.ToString());
            Console.WriteLine(Border);
            Console.WriteLine("Index matrix[1,1]: {0}", index);
        }

        public static Matrix FillMatrix(Matrix matrix)
        {          
            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols; col++)
                {
                    matrix[row, col] = random.Next(0, 20);
                }
            }

            return matrix;
        }
    }
}
