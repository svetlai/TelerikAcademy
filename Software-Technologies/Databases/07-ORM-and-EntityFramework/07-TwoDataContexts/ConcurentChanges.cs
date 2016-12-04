namespace Northwind.DBContext
{
    using System;
    using System.Linq;

    /// <summary>
    /// 7. Try to open two different data contexts and perform concurrent changes on the same records. What will 
    /// happen at SaveChanges()? How to deal with it?
    /// 
    /// Nested DbContexts. A connection to the database is opened for each on of them. When you call your service method within the using block, a new connection is opened within the TransactionScope while there is another one already open. This causes your transaction to be promoted to a distributed transaction, and partialy committed data (the result of the DbContext.SaveChanges call in the service) not being available from your outer connection. Also note that distributed transactions are far slower and thus, this has the side effect of degrading performance.You may try adding the Enlist=false parameter to your connection string. This would disable automatic enlisting in a distributed transaction, causing an exception to be raised in your first scenario. 
    /// http://stackoverflow.com/questions/12913108/nested-dbcontext-due-to-method-calls-entity-framework/14584425#14584425
    /// </summary>
    public class ConcurentChanges
    {
        public static void Main()
        {
            NorthwindDBContext context = new NorthwindDBContext();

            NorthwindDBContext secondContext = new NorthwindDBContext();

            using (context)
            {
                using (secondContext)
                {
                    ModifyCustomer(context, "ALFKI", "Pesho");
                    ModifyCustomer(secondContext, "ALFKI", "Gosho");
                    
                    context.SaveChanges();
                    secondContext.SaveChanges();                   
                }
            }

            Console.WriteLine("Both queries successfully made!");
        }

        public static void ModifyCustomer(NorthwindDBContext northwindEntities, string customerId, string newContactName)
        {
            Customer customer = GetCustomerById(northwindEntities, customerId);
            customer.ContactName = newContactName;
            northwindEntities.SaveChanges();
        }

        static Customer GetCustomerById(NorthwindDBContext northwindEntities, string customerId)
        {
            Customer customer = northwindEntities.Customers.FirstOrDefault(
                c => c.CustomerID == customerId);
            return customer;
        }
    }
}
