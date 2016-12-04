namespace RetrieveArticles
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;

    public class ArticleRetrieval
    {
        public static void Main()
        {
            var articles = new OrderedMultiDictionary<decimal, Article>(true);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i = 0; i < 500000; i++)
            {
                Article article = new Article()
                {
                    Barcode = i + "ahkkj",
                    Vendor = "Vendor",
                    Title = "Random article" + i,
                    Price = 100 + i
                };

                articles.Add(article.Price, article);
            }

            stopWatch.Stop();
            Console.WriteLine("Create and add 500 000 products into an OrderedMultiDictionary<decimal, Article>: {0}", stopWatch.Elapsed);

            stopWatch.Reset();
            stopWatch.Start();

            decimal minPrice = 100;
            decimal maxPrice = 200;

            var result = articles.Range(minPrice, true, maxPrice, true);

            stopWatch.Stop();
            Console.WriteLine("Price ranges for 100 articles: {0}", stopWatch.Elapsed);
        }
    }
}
