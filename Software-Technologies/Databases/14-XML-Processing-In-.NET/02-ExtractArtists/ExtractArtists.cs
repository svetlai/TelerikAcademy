namespace ExtractArtists
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    /// <summary>
    /// 2. Write program that extracts all different artists which are found in the catalog.xml. 
    /// For each author you should print the number of albums in the catalogue. Use the DOM parser and a hash-table.
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            var dict = new Dictionary<string, int>();

            XmlDocument document = new XmlDocument();
            document.Load("../../../14.1. Catalogue/catalogue.xml");

            XmlNode rootNode = document.DocumentElement;

            foreach (XmlNode album in rootNode.ChildNodes)
            {
                foreach (XmlNode node in album.ChildNodes)
                {
                    if (node.Name.Equals("artist"))
                    {
                        if (!dict.ContainsKey(node.InnerText))
                        {
                            dict.Add(node.InnerText, 0);                    
                        }

                        dict[node.InnerText]++;  
                    }
                }
            }

            foreach (var pair in dict)
            {
                Console.WriteLine("{0}: {1} albums.", pair.Key, pair.Value);
            }
        }
    }
}
