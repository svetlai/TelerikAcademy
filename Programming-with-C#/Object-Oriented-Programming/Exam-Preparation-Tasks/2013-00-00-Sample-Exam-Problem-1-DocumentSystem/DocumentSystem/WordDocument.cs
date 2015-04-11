namespace DocumentSystem
{
    public class WordDocument : OfficeDocument, IEncryptable, IEditable
    {
        private int? chars;

        public WordDocument()
            : base()
        {
        }

        public WordDocument(string name, string content = null, ulong? size = null, string version = null, int? chars = null)
            : base(name, content, size, version)
        {
            this.Chars = chars;
        }

        public int? Chars
        {
            get
            {
                return this.chars;
            }

            protected set
            {
                this.chars = value;
            }
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }
}
