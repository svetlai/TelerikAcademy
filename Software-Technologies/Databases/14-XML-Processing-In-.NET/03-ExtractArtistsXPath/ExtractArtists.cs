namespace ExtractArtistsXPath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    /// <summary>
    /// 3. Implement the previous using XPath.
    /// </summary>
    class Program
    {
        static void Main()
        {
            var dict = new Dictionary<string, int>();

            XmlDocument document = new XmlDocument();
            document.Load("../../../14.1. Catalogue/catalogue.xml");
            string xPathQuery = "//album";

            XmlNodeList albums = document.SelectNodes(xPathQuery);
            foreach (XmlNode node in albums)
            {
                string artist = node.SelectSingleNode("artist").InnerText;
                if (!dict.ContainsKey(artist))
                {
                    dict.Add(artist, 0);
                }

                dict[artist]++;
            }

            foreach (var pair in dict)
            {
                Console.WriteLine("{0}: {1} albums.", pair.Key, pair.Value);
            }
        }
    }
}
