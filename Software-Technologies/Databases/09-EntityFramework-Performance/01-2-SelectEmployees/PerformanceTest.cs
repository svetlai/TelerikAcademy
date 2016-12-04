namespace SelectEmployees
{
    using System;
    using System.Linq;
    using TelerikAcademy.Model;

    public class PerformanceTest
    {
        public static void Main()
        {
            var context = new TelerikAcademyEntities();

            //1. Using Entity Framework write a SQL query to select all employees from the Telerik Academy database 
            // and later print their name, department and town. Try the both variants: with and without .Include(…). 
            // Compare the number of executed SQL statements and the performance.

            //342 queries
            var employees = context.Employees;

            foreach (var employee in employees)
            {
                Console.WriteLine("{0} {1}: {2}, {3}", employee.FirstName, employee.LastName, employee.Department.Name, employee.Address.Town.Name);
            }

            //36 queries
            var employeesInclude = context.Employees
                .Include("Department")
                .Include("Address");

            foreach (var employee in employeesInclude)
            {
                Console.WriteLine("{0} {1}: {2}, {3}", employee.FirstName, employee.LastName, employee.JobTitle, employee.Department.Name, employee.Address.Town.Name);

            }
            
            // 2. Using Entity Framework write a query that selects all employees from the Telerik Academy database, then 
            // invokes ToList(), then selects their addresses, then invokes ToList(), then selects their towns, then 
            // invokes ToList() and finally checks whether the town is "Sofia". Rewrite the same in more optimized way 
            // and compare the performance.

            //1292 queries
            var employeesToList = context.Employees.ToList()
                .Select(e => e.Address).ToList()
                .Select(e => e.Town).ToList()
                .Where(t => t.Name == "Sofia");

            //Optimized - 4 queries
            var employeesOptimized = context.Employees
               .Select(x => x.Address)
               .Select(t => t.Town)
               .Where(t => t.Name == "Sofia").ToList();
        }
    }
}
