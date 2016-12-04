namespace TraverseDirectoryXDocument
{
    using System.IO;
    using System.Xml.Linq;

    /// <summary>
    /// 10. Rewrite the last exercises using XDocument, XElement and XAttribute.
    /// </summary>
    public class DirectoryTraversingLinq
    {
        public static void Main()
        {
            var initialDirectory = @"..\..\..\14.10. Traverse Directory XDocument";

            var document = AddDirectory(initialDirectory);

            document.Save("directory.xml");
        }

        private static XElement AddDirectory(string directory, XElement document = null)
        {
            var subDirectories = Directory.EnumerateDirectories(directory);

            var directoryName = directory.Split(new char[] { '\\' });
            XElement newDir = new XElement("dir", new XAttribute("name", directoryName[directoryName.Length - 1]));

            foreach (var subDirectory in subDirectories)
            {
                newDir.Add(AddDirectory(subDirectory, newDir));
            }

            foreach (var file in Directory.EnumerateFiles(directory))
            {
                var fileName = file.Split(new char[] { '\\' });
                XElement newFile = new XElement("file", fileName[fileName.Length - 1]);
                newDir.Add(newFile);
            }

            return newDir;
        }
    }
}
