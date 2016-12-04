namespace Northwind.DBContext
{
    using System;

    /// <summary>
    /// 2. Create a DAO class with static methods which provide functionality for 
    /// inserting, modifying and deleting customers. Write a testing class.
    /// </summary>
    public class TestDAO
    {
        public static void Main()
        {
            NorthwindDBContext northwindEntities = new NorthwindDBContext();
            Console.WriteLine("Program started.");
            Console.WriteLine();

            DAO.PrintAllCustomers(northwindEntities);
            Console.WriteLine();

            Customer newCustomer = new Customer
            {
                CustomerID = "TNKMB",
                CompanyName = "Telerik",
                ContactName = "Nikolay Kostov",
                ContactTitle = "Manager",
                Address = "Mladost 1",
                City = "Sofia",
                Region = "Mladost",
                PostalCode = "1000",
                Country = "Bulgaria",
                Phone = "000",
                Fax = "000"
            };

            DAO.InsertCustomer(northwindEntities, newCustomer);
            Console.WriteLine("New customer added.");
            Console.WriteLine();

            DAO.ModifyCustomer(northwindEntities, "TNKMB", "Ivaylo Kenov");
            Console.WriteLine("Customer moified.");
            Console.WriteLine();

            DAO.DeleteCustomer(northwindEntities, "TNKMB");
            Console.WriteLine("Customer deleted.");
            Console.WriteLine();
        }
    }
}
