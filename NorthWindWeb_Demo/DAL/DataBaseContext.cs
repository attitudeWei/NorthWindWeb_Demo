using Microsoft.EntityFrameworkCore;
using NorthWindWeb_Demo.DAL.Entity;

namespace NorthWindWeb_Demo.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        { }

        public DbSet<EntityEmployees> Employees { get; set; }
        public DbSet<EntityEmployeeTerritories> EmployeeTerritories { get; set; }
        public DbSet<EntityTerritories> Territories { get; set; }
        public DbSet<EntityRegion> Region { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntityEmployeeTerritories>().HasKey(table => new { table.TerritoryID, table.EmployeeID });
        }
    }
}
