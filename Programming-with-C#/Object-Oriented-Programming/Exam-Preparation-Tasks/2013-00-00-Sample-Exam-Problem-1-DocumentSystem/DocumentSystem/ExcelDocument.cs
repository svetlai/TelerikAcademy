namespace DocumentSystem
{
    using System;

    public class ExcelDocument : OfficeDocument, IEncryptable
    {
        private int? rows;
        private int? cols;

        public ExcelDocument()
            : base()
        {
        }

        public ExcelDocument(string name, string content = null, ulong? size = null, string version = null, int? rows = null, int? cols = null)
            : base(name, content, size, version)
        {
            this.Rows = rows;
            this.Cols = cols;
        }

        public int? Rows
        {
            get
            {
                return this.rows;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Rows cannot be negative.");
                }

                this.rows = value;
            }
        }

        public int? Cols
        {
            get
            {
                return this.cols;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Columns cannot be negative.");
                }

                this.cols = value;
            }
        }
    }
}
