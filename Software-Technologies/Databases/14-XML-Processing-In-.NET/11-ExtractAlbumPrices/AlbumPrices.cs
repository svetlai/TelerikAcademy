namespace ExtractAlbumPrices
{
    using System;
    using System.Xml.XPath;

    /// <summary>
    /// 11. Write a program, which extract from the file catalog.xml the prices for all albums, published 5 years 
    /// ago or earlier. Use XPath query.
    /// </summary>
    public class AlbumPrices
    {
        public static void Main()
        {
            XPathDocument document = new XPathDocument("../../../14.1. Catalogue/catalogue.xml");
            XPathNavigator navigator = document.CreateNavigator();
            string strExpression = "/catalogue/album[year<2009]/price";

            var prices = navigator.Select(strExpression);

            while (prices.MoveNext())
            {
                Console.WriteLine(prices.Current.Value);
            }
        }
    }
}
