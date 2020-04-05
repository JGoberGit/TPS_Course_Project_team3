using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPSWeb_API.Core.Utilities
{
    public class SQLServerDBContext : DbContext
    {
        public SQLServerDBContext() : base("name=TPSDBO") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.HasDefaultSchema("TPSDBO");
        }
    }
}
