namespace ExtractAlbumPricesLinq
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// 12. Rewrite the previous using LINQ query.
    /// </summary>
    public class AlbumPricesLinq
    {
        public static void Main()
        {
            var document = XDocument.Load("../../../14.1. Catalogue/catalogue.xml");

            var prices = document.Descendants("album")
                .Where(album => int.Parse(album.Descendants("year").FirstOrDefault().Value) <= 2009)
                .Select(album => album.Descendants("price").FirstOrDefault().Value);

            foreach (var price in prices)
            {
                Console.WriteLine(price);
            }
        }
    }
}
