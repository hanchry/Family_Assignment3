using Microsoft.EntityFrameworkCore;
using Model;

namespace DataAccess.Database
{
    public class FamilyDBContext:DbContext
    {
        public DbSet<Family> Families { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Adult> Adults { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<User> Users { get; set; }
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data source = C:/Users/nicol/RiderProjects/Family_Assignment3/DataAccess/Family.db");
            optionsBuilder.UseSqlite("Data source = C:/Users/hanch/Desktop/school/Assigments/DNP1/Family_Assigment3/DataAccess/Family.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Family>()
                .HasKey(c => new { c.StreetName, c.HouseNumber });
            modelBuilder.Entity<User>()
                .HasKey(c => new { c.UserName });
        }
    }
}