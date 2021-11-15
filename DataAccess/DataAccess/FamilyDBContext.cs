using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess.DataAccess
{
    public class FamilyDBContext:DbContext
    {
        public DbSet<Family> Course { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source = Family.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Family>()
                .HasKey(c => new { c.StreetName, c.HouseNumber });
            
        }
    }
}