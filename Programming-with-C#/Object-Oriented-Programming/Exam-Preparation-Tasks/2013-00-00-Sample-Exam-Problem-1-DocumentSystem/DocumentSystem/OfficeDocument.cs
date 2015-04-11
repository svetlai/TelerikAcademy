namespace DocumentSystem
{
    public abstract class OfficeDocument : BinaryDocument, IEncryptable
    {
        private string version;
        private bool isEncrypted;

        public OfficeDocument()
            : base()
        {
        }

        public OfficeDocument(string name, string content = null, ulong? size = null, string version = null, bool isEncrypted = false)
            : base(name, content, size)
        {
            this.Version = version;
            this.isEncrypted = isEncrypted;
        }

        public string Version
        {
            get
            {
                return this.version;
            }

            protected set
            {
                this.version = value;
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
