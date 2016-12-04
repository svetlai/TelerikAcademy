namespace MatrixPassableCells
{
    using System;

    public class Cell : IEquatable<Cell>
    {
        public Cell(int r, int c)
        {
            this.Row = r;
            this.Col = c;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public bool Equals(Cell other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("The cell for comparison could not be null!");
            }

            return this.Row == other.Row && this.Col == other.Col;
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", this.Row, this.Col);
        }
    }
}
