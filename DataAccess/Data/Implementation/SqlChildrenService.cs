using System;
using System.Threading.Tasks;
using DataAccess.Database;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Model;

namespace FamilyWebApi.Data
{
    public class SqlChildrenService : IChildrenReader
    {
        private FamilyDBContext familyDbContext;

        public SqlChildrenService(FamilyDBContext familyDbContext)
        {
            this.familyDbContext = familyDbContext;
        }

        public async Task<Child> AddChildAsync(string streetName, int houseNumber, Child child)
        {
            familyDbContext.Families
                .FirstOrDefault(t => t.StreetName.Equals(streetName) && t.HouseNumber == houseNumber).Children
                .Add(child);
            familyDbContext.Children.Add(child);
            await familyDbContext.SaveChangesAsync();
            return child;
        }

        public async Task RemoveChildAsync(int id)
        {
            Child childToDelete = familyDbContext.Children.Include(t => t.Interests).Include(t => t.Pets).FirstOrDefault(t => t.Id == id);
            familyDbContext.Children.Remove(childToDelete);
            await familyDbContext.SaveChangesAsync();
        }

        public async Task<Child> UpdateChildAsync(Child child)
        {
            var entity = familyDbContext.Children.Include(t => t.Interests).Include(t => t.Pets).FirstOrDefault(t => t.Id == child.Id);
            if (entity == null)
            {
                return null;
            }
            familyDbContext.Entry(entity).CurrentValues.SetValues(child);
            await familyDbContext.SaveChangesAsync();
            return child;
        }
    }
}