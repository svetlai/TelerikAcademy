using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _8._6.Web_Counter_DB
{
    public class WebCounterDbContext : DbContext
    {
        public WebCounterDbContext()
            : base("name=WebCounterDbContext")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<WebCounterDbContext, Configuration>());
        }

        public virtual IDbSet<Visitor> Visitors { get; set; }
    }
}