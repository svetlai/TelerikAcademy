namespace LargestAreaInMatrix
{
    using System;

    public class Cell
    {
        private int row;
        private int col;
        private int value;

        public Cell(int row, int col)
        {
            this.Row = row;
            this.Col = col;
            this.Value = 0;
        }

        public Cell(int row, int col, int[,] matrix)
        {
            this.Row = row;
            this.Col = col;
            this.Value = matrix[row, col];
        }

        public int Value 
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        public int Row
        {
            get
            {
                return this.row;
            }

            private set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                this.row = value;
            }
        }

        public int Col
        {
            get
            {
                return this.col;
            }

            private set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                this.col = value;
            }
        }

        // Equals and GetHashCode are nececarry for the Contains method
        public override bool Equals(object obj)
        {
            var otherCell = obj as Cell;

            if (otherCell == null)
            {
                return false;
            }

            return this.Row.Equals(otherCell.Row)
                && this.Col.Equals(otherCell.Col);
        }

        public override int GetHashCode()
        {
            return this.Row.GetHashCode() ^
                this.Col.GetHashCode();
        }
    }
}
