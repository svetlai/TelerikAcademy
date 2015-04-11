namespace DocumentSystem
{
    using System;

    public class MultimediaDocument : BinaryDocument
    {
        private int? length;

        public MultimediaDocument()
            : base()
        {
        }

        public MultimediaDocument(string name, string content = null, ulong? size = null, int? length = null)
            : base(name, content, size)
        {
            this.Length = length;
        }

        public int? Length
        {
            get
            {
                return this.length;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Length cannot be negative.");
                }

                this.length = value;
            }
        }
    }
}
