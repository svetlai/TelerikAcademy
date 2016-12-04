namespace FilesAndFolders
{
    public class File
    {
        public File()
        {
        }

        public File(string name)
        {
            this.Name = name;
        }

        public File(string name, long size)
            : this(name)
        {
            this.Size = size;
        }

        public string Name { get; set; }

        public long Size { get; set; }

    }
}
