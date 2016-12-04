namespace FilesAndFolders
{
    public class Folder
    {
        public Folder()
        {
        }
        public Folder(string name)
        {
            this.Name = name;
            this.Files = new File[0];
            this.ChildFolders = new Folder[0];
        }

        public string Name { get; set; }

        public File[] Files { get; set; }

        public Folder[] ChildFolders { get; set; }
    }
}
