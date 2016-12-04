namespace ExtractSongTitles
{
    using System;
    using System.Xml;

    /// <summary>
    /// 5. Write a program, which using XmlReader extracts all song titles from catalog.xml.
    /// </summary>
    public class ReadSongTitles
    {
        public static void Main()
        {
            Console.WriteLine("Song Titles in catalogue:");
            using (XmlReader reader = XmlReader.Create("../../../14.1. Catalogue/catalogue.xml"))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) &&
                        (reader.Name == "title"))
                    {
                        Console.WriteLine(reader.ReadElementString());
                    }
                }
            }
        }
    }
}
