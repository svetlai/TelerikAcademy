namespace CreateAlbum.xml
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    /// <summary>
    /// 8. Write a program, which (using XmlReader and XmlWriter) reads the file catalog.xml and creates the file 
    /// album.xml, in which stores in appropriate way the names of all albums and their authors.
    /// </summary>
    public class CreateAlbum
    {
        public static void Main()
        {
            XmlReader reader = XmlReader.Create("../../../14.1. Catalogue/catalogue.xml");
            XmlTextWriter writer = new XmlTextWriter("album.xml", Encoding.Unicode);

            using (reader)
            {
                using (writer)
                {
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("album");

                    while (reader.Read())
                    {
                        if (reader.Name.Equals("album") && reader.IsStartElement())
                        {
                            writer.WriteStartElement("album");

                            reader.ReadToDescendant("name");

                            string albumName = reader.ReadElementContentAsString();

                            reader.ReadToNextSibling("artist");

                            string authorName = reader.ReadElementContentAsString();

                            writer.WriteElementString("name", albumName);
                            writer.WriteElementString("artist", authorName);

                            writer.WriteEndElement();
                        }
                    }

                }
            }
        }
    }
}
