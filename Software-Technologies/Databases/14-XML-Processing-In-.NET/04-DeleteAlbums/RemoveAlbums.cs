namespace DeleteAlbums
{
    using System;
    using System.Xml;

    /// <summary>
    /// 4. Using the DOM parser write a program to delete from catalog.xml all albums having price > 20.
    /// </summary>
    public class RemoveAlbums
    {
        public static void Main()
        {
            XmlDocument document = new XmlDocument();
            document.Load("../../../14.1. Catalogue/catalogue.xml");

            XmlNode rootNode = document.DocumentElement;

            foreach (XmlNode album in rootNode.ChildNodes)
            {
                foreach (XmlNode node in album.ChildNodes)
                {
                    if (node.Name.Equals("price"))
                    {                        
                        if (int.Parse(node.InnerText) > 20)
                        {
                            rootNode.RemoveChild(album);
                            Console.WriteLine("Album deleted.");
                        }
                    }
                }
            }

            document.Save("../../../14.1. Catalogue/catalogue.xml");
        }
    }
}
