namespace Northwind.DBContext
{
    using System;
    using System.Data.Linq;
    using System.Collections.Generic;

    //This partial class only works if it is in the same project as the other part of the class. I've added it there.
    public partial class Employee
    {
        public virtual EntitySet<Territory> EntityTerritories
        {
            get
            {
                EntitySet<Territory> entityTerritories = new EntitySet<Territory>();
                //var employeeTerritories = this.Territories;
                //entityTerritories.AddRange(employeeTerritories);
                return entityTerritories;

            }
        }
    }
}