namespace HTMLRenderer
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HTMLTable : HTMLElement, ITable
    {
        private const string NegativeRowsExcMsg = "You need to provide at least 1 row.";
        private const string NegativeColsExcMsg = "You need to provide at least 1 col.";
        private const string InvalidRowExcMsg = "Row is out of boundaries.";
        private const string InvalidColExcMsg = "Column is out of boundaries.";
        private const string NoChildrenExcMsg = "The table has no children elements.";
        private const string NoTextContentExcMsg = "The table has no text content.";

        private const string TableName = "table";
        private const string TrOpeningTag = "<tr>";
        private const string TrClosingTag = "</tr>";
        private const string TdOpeningTag = "<td>";
        private const string TdClosingTag = "</td>";

        private int rows;
        private int cols;
        private IElement[,] table;

        public HTMLTable(int rows, int cols)
            : base(TableName)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.table = new IElement[this.Rows, this.Cols];
        }

        public int Rows
        {
            get
            {
                return this.rows;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(NegativeRowsExcMsg);
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
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(NegativeColsExcMsg);
                }

                this.cols = value;
            }
        }

        public IElement this[int row, int col]
        {
            get
            {
                this.ValidateIndexes(row, col);
                return this.table[row, col];
            }

            set
            {
                this.ValidateIndexes(row, col);
                this.table[row, col] = value;
            }
        }

        // Not the smartest thing to do since inheritors are supposed to extend the base class, not narrow it, but it's required in the task description
        public override string TextContent
        {
            get
            {
                throw new InvalidOperationException(NoTextContentExcMsg);
            }

            set
            {
                throw new InvalidOperationException(NoTextContentExcMsg);
            }
        }

        public override IEnumerable<IElement> ChildElements
        {
            get
            {
                throw new InvalidOperationException(NoChildrenExcMsg);
            }
        }

        public override void AddElement(IElement element)
        {
            throw new InvalidOperationException(NoChildrenExcMsg);
        }

        public override void Render(StringBuilder output)
        {
            // <table><tr><td>(cell_0_0)</td><td>(cell_0_1)</td>…</tr><tr><td>(cell_1_0)</td><td>(cell_1_1)</td>…</tr>…</table>
            output.AppendFormat("<{0}>", TableName);
            for (int row = 0; row < this.Rows; row++)
            {
                output.Append(TrOpeningTag);
                for (int col = 0; col < this.Cols; col++)
                {
                    output.Append(TdOpeningTag);

                    if (this.table[row, col] != null)
                    {
                        // this.table[row, col].Render(output);
                        output.Append(this.table[row, col].ToString());
                    }

                    output.Append(TdClosingTag);
                }

                output.Append(TrClosingTag);
            }

            output.AppendFormat("</{0}>", TableName);
        }

        private void ValidateIndexes(int row, int col)
        {
            if (row < 0 || row >= this.Rows)
            {
                throw new IndexOutOfRangeException(InvalidRowExcMsg);
            }

            if (col < 0 || col >= this.Cols)
            {
                throw new IndexOutOfRangeException(InvalidColExcMsg);
            }
        }
    }
}
