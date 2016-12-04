namespace TraverseDirecotry
{
    using System.IO;
    using System.Text;
    using System.Xml;

    /// <summary>
    /// 9. Write a program to traverse given directory and write to a XML file its contents together with all 
    /// subdirectories and files. Use tags <file> and <dir> with appropriate attributes. For the generation of the 
    /// XML document use the class XmlWriter.
    /// </summary>
    public class DirectoryTraversing
    {
        public static void Main()
        {
            var initialDirectory = @"..\..\..\14.9. Traverse Direcotry";

            var writer = new XmlTextWriter("directory-content.xml", Encoding.Unicode);
            writer.Formatting = Formatting.Indented;

            using (writer)
            {
                writer.WriteStartDocument();

                AddDirectory(initialDirectory, writer);

                writer.WriteEndElement();
            }
        }

        private static void AddDirectory(string directory, XmlTextWriter writer)
        {
            var subDirectories = Directory.EnumerateDirectories(directory);

            writer.WriteStartElement("dir");
            var directoryName = directory.Split(new char[] { '\\' });
            writer.WriteAttributeString("name", directoryName[directoryName.Length - 1]);

            foreach (var subDirectory in subDirectories)
            {
                AddDirectory(subDirectory, writer);
            }

            foreach (var file in Directory.EnumerateFiles(directory))
            {
                var fileName = file.Split(new char[] { '\\' });
                writer.WriteElementString("file", fileName[fileName.Length - 1]);
            }
        }
    }
}
