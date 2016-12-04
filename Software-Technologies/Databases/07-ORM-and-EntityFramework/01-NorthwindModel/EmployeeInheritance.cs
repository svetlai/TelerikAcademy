namespace Northwind.DBContext
{
    using System;
    using System.Data.Linq;
    using System.Collections.Generic;

    public partial class Employee
    {
        public virtual EntitySet<Territory> EntityTerritories
        {
            get
            {
                EntitySet<Territory> entityTerritories = new EntitySet<Territory>();
                var employeeTerritories = this.Territories;
                entityTerritories.AddRange(employeeTerritories);
                return entityTerritories;

            }
        }
    }
}
