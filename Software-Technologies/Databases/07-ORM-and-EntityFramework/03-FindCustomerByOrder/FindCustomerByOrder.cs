namespace Northwind.DBContext
{
    using System;
    using System.Linq;

    /// <summary>
    /// 3. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
    /// </summary>
    public class FindCustomer
    {
        public static void Main()
        {
            NorthwindDBContext northwindEntities = new NorthwindDBContext();
            Console.WriteLine("Program started.");
            Console.WriteLine();

            Console.WriteLine("Orderes, made in 1997, shipped to Canada, made by the following customers:");
            FindCustomerByOrder(northwindEntities, 1997, "Canada");
        }

        public static void FindCustomerByOrder(NorthwindDBContext northwindEntities, int yearOrdered, string shipCountry)
        {
            var orders =
                (from o in northwindEntities.Orders
                 where o.OrderDate.Value.Year == yearOrdered && o.ShipCountry == shipCountry
                 select o.Customer.CompanyName);

            foreach (var order in orders)
            {
                Console.WriteLine("{0}", order);
            }
        }
    }
}
