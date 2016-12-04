namespace ReadLargeCollection
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    using Wintellect.PowerCollections;

    public class PriceRangeTest
    {
        public static void Main()
        {
            OrderedBag<Product> products = new OrderedBag<Product>();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i = 0; i < 500000; i++)
            {
                Product product = new Product()
                {
                    Name = "Random product" + i,
                    Price = 100 + i
                };

                products.Add(product);
            }

            stopWatch.Stop();
            Console.WriteLine("Create and add 500 000 products into an OrderedBag<Product>: {0}", stopWatch.Elapsed);

            stopWatch.Reset();
            stopWatch.Start();

            decimal minPrice;
            decimal maxPrice;
            for (int i = 0; i < 10000; i++)
            {
                minPrice = 200 + i;
                maxPrice = 310 + i;

                var productsInPriceRange = products
                    .Range(new Product("", minPrice), true, new Product("", maxPrice), true)
                    .Take(20);
            }

            stopWatch.Stop();
            Console.WriteLine("10 000 price ranges via Range: {0}", stopWatch.Elapsed);

            stopWatch.Reset();
            stopWatch.Start();

            for (int i = 0; i < 10000; i++)
            {
                minPrice = 200 + i;
                maxPrice = 310 + i;

                var productsInRangeFindAll = products
                    .FindAll(product => product.Price > minPrice && product.Price < maxPrice)
                    .Take(20);
            }

            stopWatch.Stop();
            Console.WriteLine("10 000 price ranges via FindAll: {0}", stopWatch.Elapsed);








        }
    }
}
