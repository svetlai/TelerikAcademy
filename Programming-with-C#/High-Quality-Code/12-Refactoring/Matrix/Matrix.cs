namespace Refactoring
{
    using System;
    using System.Text;

    public class Matrix
    {
        private const int MinSize = 1;
        private const int MaxSize = 100;
        private const int TotalDirectionsCount = 8;
        private int size;

        private int[,] matrix;

        private int row = 0;
        private int col = 0;

        private int[] rowDirections = { 1, 1, 1, 0, -1, -1, -1, 0 };
        private int[] colDirections = { 1, 0, -1, -1, -1, 0, 1, 1 };

        public Matrix(int size)
        {
            this.Size = size;
            this.matrix = new int[this.size, this.size];
            this.InitializeMatrix();
        }

        public int Size
        {
            get
            {
                return this.size;
            }

            set
            {
                if (value < MinSize || value > MaxSize)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Size value must be between {0} and {1}!", MinSize, MaxSize));
                }

                this.size = value;
            }
        }

        public override string ToString()
        {
            StringBuilder matrixAsStirng = new StringBuilder();

            for (int row = 0; row < this.Size; row++)
            {
                for (int col = 0; col < this.Size; col++)
                {
                    matrixAsStirng.AppendFormat("{0,3}", this.matrix[row, col]);
                }

                matrixAsStirng.Append("\r\n");
            }

            return matrixAsStirng.ToString().TrimEnd();
        }

        private void InitializeMatrix()
        {
            this.FindAvailableCell();
            this.MoveToNextAvailableCell();
            this.ToString();
        }

        private void GetDirection(ref int dirRow, ref int dirCol)
        {
            int currDirection = 0;

            for (int i = 0; i < TotalDirectionsCount; i++)
            {
                if (this.rowDirections[i] == dirRow && this.colDirections[i] == dirCol)
                {
                    currDirection = i;
                    break;
                }
            }

            if (currDirection == TotalDirectionsCount - 1)
            {
                dirRow = this.rowDirections[0];
                dirCol = this.colDirections[0];
                return;
            }

            dirRow = this.rowDirections[currDirection + 1];
            dirCol = this.colDirections[currDirection + 1];
        }

        private bool IsNextCellAvailable(int row, int col)
        {
            int[] rowDirections = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] colDirections = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < TotalDirectionsCount; i++)
            {
                int nextRow = row + rowDirections[i];
                int nextCol = col + colDirections[i];

                if (!this.IsCellInRange(nextRow))
                {
                    rowDirections[i] = 0;
                }

                if (!this.IsCellInRange(nextCol))
                {
                    colDirections[i] = 0;
                }
            }

            return this.IsNextCellEmpty(row, col, rowDirections, colDirections);
        }

        private bool IsNextCellEmpty(int row, int col, int[] rowDirections, int[] colDirections)
        {
            for (int i = 0; i < TotalDirectionsCount; i++)
            {
                int nextRow = row + rowDirections[i];
                int nextCol = col + colDirections[i];

                if (this.matrix[nextRow, nextCol] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private void FindAvailableCell()
        {
            this.row = 0;
            this.col = 0;

            for (int currentRow = 0; currentRow < this.size; currentRow++)
            {
                for (int currentCol = 0; currentCol < this.size; currentCol++)
                {
                    if (this.matrix[currentRow, currentCol] == 0)
                    {
                        this.row = currentRow;
                        this.col = currentCol;

                        return;
                    }
                }
            }
        }

        private void MoveToNextAvailableCell()
        {
            int rowDirection = 1;
            int colDirection = 1;
            int count = 1;

            while (true)
            {
                this.matrix[this.row, this.col] = count;

                if (!this.IsNextCellAvailable(this.row, this.col))
                {
                    this.FindAvailableCell();

                    if (this.IsNextCellAvailable(this.row, this.col))
                    {
                        count++;
                        this.matrix[this.row, this.col] = count;
                        rowDirection = 1;
                        colDirection = 1;
                    }
                    else
                    {
                        break;
                    }
                }

                int nextRow = this.row + rowDirection;
                int nextCol = this.col + colDirection;

                while (!this.IsCellInRange(nextRow) || !this.IsCellInRange(nextCol) || this.matrix[nextRow, nextCol] != 0)
                {
                    this.GetDirection(ref rowDirection, ref colDirection);

                    nextRow = this.row + rowDirection;
                    nextCol = this.col + colDirection;
                }

                this.row = nextRow;
                this.col = nextCol;
                count++;
            }
        }

        private bool IsCellInRange(int value)
        {
            if (value >= this.size || value < 0)
            {
                return false;
            }

            return true;
        }
    }
}