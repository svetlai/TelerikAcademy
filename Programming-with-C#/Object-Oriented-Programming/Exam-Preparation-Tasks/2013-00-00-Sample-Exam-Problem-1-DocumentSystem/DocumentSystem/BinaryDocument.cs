namespace DocumentSystem
{
    public class BinaryDocument : Document
    {
        private ulong? size;

        public BinaryDocument()
            : base()
        {
        }

        public BinaryDocument(string name, string content = null, ulong? size = null)
            : base(name, content)
        {
            this.Size = size;
        }

        public ulong? Size
        {
            get
            {
                return this.size;
            }

            protected set
            {
                this.size = value;
            }
        }
    }
}
