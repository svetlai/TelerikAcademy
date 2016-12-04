namespace Northwind.DBContext
{
    using System;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;

    /// <summary>
    /// 10. Create a stored procedures in the Northwind database for finding the total incomes for given supplier name 
    /// and period (start date, end date). Implement a C# method that calls the stored procedure and returns the 
    /// retuned record set.
    /// </summary>
    class StoredProcedure
    {
        static void Main()
        {
            NorthwindDBContext northwindEntities = new NorthwindDBContext();

            var totalIncome = GetTotalIncomes(northwindEntities, "Exotic Liquids", new DateTime(1990, 1, 1), new DateTime(2001, 1, 1));

            Console.WriteLine("Total income: {0}", totalIncome);      
        }

        static decimal? GetTotalIncomes(NorthwindDBContext northwindEntites, string supplierName, DateTime? startDate, DateTime? endDate)
        {
            var totalIncomeSet = northwindEntites.usp_FindTotalIncome(supplierName, startDate, endDate);

            foreach (var totalIncome in totalIncomeSet)
            {
                return totalIncome;
            }

            return null;
        }

        public virtual ObjectResult<Nullable<decimal>> usp_FindTotalIncome(string supplierName, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var supplierNameParameter = supplierName != null ?
                new ObjectParameter("supplierName", supplierName) :
                new ObjectParameter("supplierName", typeof(string));

            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("startDate", startDate) :
                new ObjectParameter("startDate", typeof(System.DateTime));

            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("endDate", endDate) :
                new ObjectParameter("endDate", typeof(System.DateTime));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("usp_FindTotalIncome", supplierNameParameter, startDateParameter, endDateParameter);
        }
    }
}
