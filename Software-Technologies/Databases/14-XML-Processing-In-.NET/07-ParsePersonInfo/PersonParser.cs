namespace ParsePersonInfo
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;

    /// <summary>
    /// 7. In a text file we are given the name, address and phone number of given person (each at a single line). 
    /// Write a program, which creates new XML document, which contains these data in structured XML format.
    /// </summary>
    public class PersonParser
    {
        public static void Main()
        {
            var textReader = new StreamReader("person.txt");
            var xmlWriter = new XmlTextWriter("person.xml", Encoding.Unicode);

            using (textReader)
            {
                string[] info = textReader
                    .ReadToEnd()
                    .Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                using (xmlWriter)
                {
                    xmlWriter.Formatting = Formatting.Indented;

                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("person");
                    xmlWriter.WriteElementString("name", info[0]);
                    xmlWriter.WriteElementString("address", info[1]);
                    xmlWriter.WriteElementString("phone", info[2]);
                    xmlWriter.WriteEndElement();
                }
            }
        }
    }
}
