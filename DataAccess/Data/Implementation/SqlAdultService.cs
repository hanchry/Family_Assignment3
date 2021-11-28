using System.Threading.Tasks;
using DataAccess.Database;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Model;

namespace FamilyWebApi.Data
{
    public class SqlAdultService : IAdultReader
    {
        private FamilyDBContext familyDbContext;

        public SqlAdultService(FamilyDBContext familyDbContext)
        {
            this.familyDbContext = familyDbContext;
        }

        public async Task<Adult> AddAdultAsync(string streetName, int houseNumber, Adult adult)
        {
            familyDbContext.Families
                .FirstOrDefault(t => t.StreetName.Equals(streetName) && t.HouseNumber == houseNumber).Adults.Add(adult);
            familyDbContext.Adults.Add(adult);
            await familyDbContext.SaveChangesAsync();
            return adult;
        }

        public async Task RemoveAdultAsync(int id)
        {
            Adult adultToDelete = familyDbContext.Adults.FirstOrDefault(t => t.Id == id);
            familyDbContext.Adults.Remove(adultToDelete);
            await familyDbContext.SaveChangesAsync();
        }
        
        public async Task<Adult> UpdateAdultAsync(Adult adult)
        {
            var entity = familyDbContext.Adults.Include(t => t.JobTittle).FirstOrDefault(t => t.Id == adult.Id);
            if (entity == null)
            {
                return null;
            }
            familyDbContext.Entry(entity).CurrentValues.SetValues(adult);
            await familyDbContext.SaveChangesAsync();
            return adult;
        }
        
    }
}