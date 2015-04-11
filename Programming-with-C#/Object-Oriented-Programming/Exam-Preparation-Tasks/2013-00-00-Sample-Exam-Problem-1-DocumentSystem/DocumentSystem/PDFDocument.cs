namespace DocumentSystem
{
    public class PDFDocument : BinaryDocument, IEncryptable
    {
        private int? pages;
        private bool isEncrypted;

        public PDFDocument()
            : base()
        {
        }

        public PDFDocument(string name, string content = null, ulong? size = null, int? pages = null, bool isEncrypted = false)
            : base(name, content, size)
        {
            this.Pages = pages;
            this.isEncrypted = isEncrypted;
        }

        public int? Pages
        {
            get
            {
                return this.pages;
            }

            protected set
            {
                this.pages = value;
            }
        }

        public bool IsEncrypted
        {
            get
            {
                return this.isEncrypted;
            }

            protected set
            {
                this.isEncrypted = value;
            }
        }

        public void Encrypt()
        {
            this.isEncrypted = true;
        }

        public void Decrypt()
        {
            this.isEncrypted = false;
        }
    }
}
