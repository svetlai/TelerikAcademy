namespace Northwind.DBContext
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DAO
    {
        public static void InsertCustomer(NorthwindDBContext northwindEntities, Customer customer)
        {
            northwindEntities.Customers.Add(customer);
            northwindEntities.SaveChanges();
        }

        public static void ModifyCustomer(NorthwindDBContext northwindEntities, string customerId, string newContactName)
        {
            Customer customer = GetCustomerById(northwindEntities, customerId);
            customer.ContactName = newContactName;
            northwindEntities.SaveChanges();
        }

        public static void DeleteCustomer(NorthwindDBContext northwindEntities, string customerId)
        {
            Customer customer = GetCustomerById(northwindEntities, customerId);
            northwindEntities.Customers.Remove(customer);
        }

        static Customer GetCustomerById(NorthwindDBContext northwindEntities, string customerId)
        {
            Customer customer = northwindEntities.Customers.FirstOrDefault(
                c => c.CustomerID == customerId);
            return customer;
        }

        public static void PrintAllCustomers(NorthwindDBContext northwindEntities)
        {
            var allCustomers =
                (from c in northwindEntities.Customers
                 select c);                

            Console.WriteLine("All Customers:");
            foreach (var customer in allCustomers)
            {
                Console.WriteLine("{0}", customer.CompanyName);
            }

            Console.WriteLine();
        }
    }
}
