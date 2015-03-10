namespace MatrixClass
{
    using System;
    using System.Collections;

    public class Matrix<T>
    {
        private const string SameLengthExceptionMsg = "Matrices must have the same rows and cols length in order to perform mathematical operations on them.";
        private const string NoRowsExceptionMsg = "The Matrix must have at least one row.";
        private const string NoColsExceptionMsg = "The Matrix must have at least one column.";
        private const string OutOfRangeExceptionMsg = "Index is out of range.";

        private int rows;
        private int cols;
        private int[,] matrix;

        public Matrix(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.matrix = new int[rows, cols];
        }

        public int Rows
        {
            get
            {
                return this.rows;
            }

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(NoRowsExceptionMsg);
                }

                this.rows = value;
            }
        }

        public int Cols
        {
            get
            {
                return this.cols;
            }

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(NoColsExceptionMsg);
                }

                this.cols = value;
            }
        }

        public int this[int rowIndex, int colIndex]
        {
            get
            {
                return this.matrix[rowIndex, colIndex];
            }

            set
            {
                if (rowIndex < 0 || rowIndex >= this.Rows || colIndex < 0 || colIndex >= this.Rows)
                {
                    throw new IndexOutOfRangeException(OutOfRangeExceptionMsg);
                }

                this.matrix[rowIndex, colIndex] = value;
            }
        }

        public static bool operator true(Matrix<T> matrix)
        {
            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols; col++)
                {
                    if (matrix[row, col].Equals(default(T)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols; col++)
                {
                    if (matrix[row, col].Equals(default(T)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {
            if (first.Rows != second.Rows || first.Cols != second.Cols)
            {
                throw new ArgumentException(SameLengthExceptionMsg);
            }

            Matrix<T> result = new Matrix<T>(first.Rows, first.Cols);

            for (int row = 0; row < result.Rows; row++)
            {
                for (int col = 0; col < result.Cols; col++)
                {
                    result[row, col] = first[row, col] + second[row, col];
                }
            }

            return result;
        }

        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            if (first.Rows != second.Rows || first.Cols != second.Cols)
            {
                throw new ArgumentException(SameLengthExceptionMsg);
            }

            if (first.Rows != second.Rows || first.Cols != second.Cols)
            {
                throw new ArgumentException(SameLengthExceptionMsg);
            }

            Matrix<T> result = new Matrix<T>(first.Rows, first.Cols);

            for (int row = 0; row < result.Rows; row++)
            {
                for (int col = 0; col < result.Cols; col++)
                {
                    result[row, col] = first[row, col] - second[row, col];
                }
            }

            return result;
        }

        public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
        {
            if (first.Rows != second.Rows || first.Cols != second.Cols)
            {
                throw new ArgumentException(SameLengthExceptionMsg);
            }

            if (first.Rows != second.Rows || first.Cols != second.Cols)
            {
                throw new ArgumentException(SameLengthExceptionMsg);
            }

            Matrix<T> result = new Matrix<T>(first.Rows, first.Cols);

            for (int row = 0; row < result.Rows; row++)
            {
                for (int col = 0; col < result.Cols; col++)
                {
                    result[row, col] = first[row, col] * second[row, col];
                }
            }

            return result;
        }

        public override string ToString()
        {
            string rows = string.Empty;

            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    rows += string.Format("{0,5}", this.matrix[row, col]);
                }

                rows += Environment.NewLine;
            }

            return rows;
        }
    }
}