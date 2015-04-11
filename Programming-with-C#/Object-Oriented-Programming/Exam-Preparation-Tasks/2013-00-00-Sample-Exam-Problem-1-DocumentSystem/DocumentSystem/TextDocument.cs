namespace DocumentSystem
{
    public class TextDocument : Document, IEditable
    {
        private string charset;

        public TextDocument()
            : base()
        {
        }

        public TextDocument(string name, string content = null, string charset = null)
        : base(name, content)
        {
            this.Charset = charset;
        }

        public string Charset
        {
            get
            {
                return this.charset;
            }

            protected set
            {
                this.charset = value;
            }
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }
}
