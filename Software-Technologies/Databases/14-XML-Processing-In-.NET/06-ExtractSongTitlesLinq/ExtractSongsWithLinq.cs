namespace ExtractSongTitlesLinq
{
    using System;
    using System.Xml.Linq;

    /// <summary>
    /// 6. Rewrite the same using XDocument and LINQ query.
    /// </summary>
    public class ExtractSongsWithLinq
    {
        public static void Main()
        {
            XDocument document = XDocument.Load("../../../14.1. Catalogue/catalogue.xml");
            var songs = document.Root.Descendants("song");

            foreach (var song in songs)
            {
                Console.WriteLine(song.Element("title").Value);
            }
        }
    }
}
