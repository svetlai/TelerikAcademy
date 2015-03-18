namespace MatrixClass
{
    using System;
    using System.Text;

    using Helper;

    /// <summary>
    /// Problem 8. Matrix
    ///   Define a class `Matrix<T>` to hold a matrix of numbers (e.g. integers, floats, decimals). 
    /// Problem 9. Matrix indexer
    ///   Implement an indexer `this[row, col]` to access the inner matrix cells.
    /// Problem 10. Matrix operations
    ///   Implement the operators `+` and `-` (addition and subtraction of matrices of the same size) and `*` for matrix multiplication.
    ///   Throw an exception when the operation cannot be performed.
    ///   Implement the `true` operator (check for non-zero elements).
    /// </summary>
    public class TextMatrix
    {
        private static Random random = new Random();

        public static void Main()
        {
            HelperMethods.DisplayTaskDescription(Constants.PathToTaskDescription);

            TestGenericMatrix();
        }

        public static void TestGenericMatrix()
        {
            // Test with different types
            Matrix<int> integerMatrix = new Matrix<int>(3, 3);
            Matrix<float> floatMatrix = new Matrix<float>(3, 3);

            Matrix<double> matrix = new Matrix<double>(3, 3);
            matrix = FillMatrix(matrix);

            Matrix<double> secondMatrix = new Matrix<double>(3, 3);
            secondMatrix = FillMatrix(secondMatrix);

            // Test operations
            Matrix<double> added = matrix + secondMatrix;
            Matrix<double> subtracted = matrix - secondMatrix;
            Matrix<double> multiplied = matrix * secondMatrix;

            double index = matrix[1, 1];

            string trueMatrix = matrix ? "Matrix is true." : "Matrix is false.";

            // Print
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Playing with the Matrix class:")
                .AppendLine()
                .AppendLine("Matrix A): ")
                .Append(matrix.ToString())
                .AppendLine(Constants.Border + "\nMatrix B): ")
                .Append(secondMatrix.ToString())
                .AppendLine(Constants.Border + "\nMatrix A + Matrix B: ")
                .Append(added.ToString())
                .AppendLine(Constants.Border + "\nMatrix A - Matrix B: ")
                .Append(subtracted.ToString())
                .AppendLine(Constants.Border + "\nMatrix A * Matrix B: ")
                .Append(multiplied.ToString())
                .AppendLine(Constants.Border)
                .AppendFormat("Index matrix[1,1]: {0}", index)
                .AppendLine()
                .AppendLine(trueMatrix)
                .Append(Constants.Border);

            Console.WriteLine(sb.ToString());
        }

        public static Matrix<T> FillMatrix<T>(Matrix<T> matrix)
        {
            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols; col++)
                {
                    dynamic num = random.Next(0, 20);
                    matrix[row, col] = (T)num;
                }
            }

            return matrix;
        }
    }
}
