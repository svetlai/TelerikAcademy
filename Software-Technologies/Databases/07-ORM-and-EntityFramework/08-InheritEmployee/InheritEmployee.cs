namespace Northwind.DBContext
{
    using System;
    using System.Linq;
    using System.Data.Linq;

    /// <summary>
    /// 8. By inheriting the Employee entity class create a class which allows employees to access their corresponding 
    /// territories as property of type EntitySet<T>.
    /// </summary>
    public class InheritEmployee
    {
        public static void Main()
        {
            NorthwindDBContext northwindEntities = new NorthwindDBContext();
            var territories = northwindEntities.Employees.FirstOrDefault().EntityTerritories;

            foreach (var territory in territories)
            {
                Console.WriteLine("{0}", territory.TerritoryDescription);
            }
        }
    }
}
