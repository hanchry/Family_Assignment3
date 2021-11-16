using Microsoft.EntityFrameworkCore;
using Model;

namespace DataAccess.Database
{
    public class FamilyDBContext:DbContext
    {
        public DbSet<Family> Families { get; set; }
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source = C:/Users/hanch/Desktop/school/Assigments/DNP1/Family_Assigment3/DataAccess/Family.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Family>()
                .HasKey(c => new { c.StreetName, c.HouseNumber });
            
        }
    }
}