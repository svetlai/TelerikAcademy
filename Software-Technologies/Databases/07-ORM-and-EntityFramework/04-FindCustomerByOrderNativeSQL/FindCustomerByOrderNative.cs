namespace Northwind.DBContext
{
    using System;

    /// <summary>
    /// 4. Implement previous by using native SQL query and executing it through the DbContext.
    /// </summary>
    public class FindCustomerByOrderNativeSQL
    {
        public static void Main()
        {
            NorthwindDBContext northwindEntities = new NorthwindDBContext();
            Console.WriteLine("Program started.");
            Console.WriteLine();

            Console.WriteLine("Orderes, made in 1997, shipped to Canada, made by the following customers:");
            FindCustomerByOrderNative(northwindEntities);
        }

        public static void FindCustomerByOrderNative(NorthwindDBContext northwindEntities)
        {
            string nativeSqlQuery = "SELECT CompanyName FROM Customers c " +
                                    "INNER JOIN Orders o ON c.CustomerID = o.CustomerID " +
                                    "WHERE YEAR(o.OrderDate) = 1997 AND o.ShipCountry = 'Canada'";
            var queryResult = northwindEntities.Database.SqlQuery<string>(nativeSqlQuery);

            foreach (var result in queryResult)
            {
                Console.WriteLine("{0}", result);
            }
        }
    }
}
