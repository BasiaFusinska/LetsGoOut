using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using LetsGoOut.Domain;

namespace LetsGoOut.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DatabaseContext")
        {
        }
        
        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
