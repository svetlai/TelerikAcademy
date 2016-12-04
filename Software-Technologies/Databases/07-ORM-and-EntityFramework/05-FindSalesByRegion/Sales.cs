namespace Northwind.DBContext
{
    using System;
    using System.Linq;

    /// <summary>
    /// 5. Write a method that finds all the sales by specified region and period (start / end dates).
    /// </summary>
    public class Sales
    {
        public static void Main()
        {
            NorthwindDBContext northwindEntities = new NorthwindDBContext();
            Console.WriteLine("Program started.");
            Console.WriteLine();

            Console.WriteLine("Product, quantity, unit price of sales between 1996 and 1997 in NM:");
            FindSalesByRegion(northwindEntities, "NM", 1996, 1997);
        }

        public static void FindSalesByRegion(NorthwindDBContext northwindEntities, string region, int startYear, int endYear)
        {
            //var sales = northwindEntities.Orders.Where(o => o.OrderDate.Value.Year >= startYear
            //    && o.OrderDate.Value.Year <= endYear && o.ShipRegion == region)
            //    .Select(o => o);

            var sales =
                (from order in northwindEntities.Orders
                 join details in northwindEntities.Order_Details
                 on order.OrderID equals details.OrderID
                 where order.OrderDate.Value.Year >= startYear && order.OrderDate.Value.Year <= endYear
                        && order.ShipRegion == region
                 select details);

            foreach (var sale in sales)
            {
                Console.WriteLine("{0} | {1} | {2}", sale.Product.ProductName, sale.Quantity, sale.UnitPrice);
            }
        }
    }
}
