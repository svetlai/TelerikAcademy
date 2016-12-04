namespace Northwind.DBContext
{
    using System;
    using System.Collections.Generic;
    using System.Transactions;

    /// <summary>
    /// 9. Create a method that places a new order in the Northwind database. The order should contain several 
    /// order items. Use transaction to ensure the data consistency.
    /// </summary>
    public class OrderTransaction
    {
        public static void Main()
        {
            NorthwindDBContext northwindEntities = new NorthwindDBContext();

            Order newOrder = new Order
            {
                ShippedDate = DateTime.Now,
                OrderDate = DateTime.Now,
                RequiredDate = DateTime.Now,
                ShipVia = 2,
                Freight = 0.01M,
                EmployeeID = 3,
                CustomerID = "ALFKI"
            };

            ICollection<Order> orders = new HashSet<Order>();
            for (int i = 0; i < 2; i++)
            {
                orders.Add(newOrder);
            }

            MakeNewOrder(northwindEntities, orders);

            Console.WriteLine("Orders added successfully!");
        }

        public static void MakeNewOrder(NorthwindDBContext northwindEntities, ICollection<Order> orders)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                foreach (var order in orders)
                {
                    var customer = northwindEntities.Customers.Find(order.CustomerID);
                    if (customer == null)
                    {
                        throw new ArgumentNullException("No customer with such ID");
                    }

                    order.ShipName = customer.CompanyName;
                    order.ShipAddress = customer.Address;
                    order.ShipCity = customer.City;
                    order.ShipCountry = customer.Country;
                    order.ShipPostalCode = customer.PostalCode;
                    order.ShipRegion = customer.Region;

                    northwindEntities.Orders.Add(order);
                    northwindEntities.SaveChanges();
                }

                transaction.Complete();
                northwindEntities.SaveChanges();
            }
        }
    }


}
