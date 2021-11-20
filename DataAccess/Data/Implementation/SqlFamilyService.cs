using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model;

namespace FamilyWebApi.Data
{
    public class SqlFamilyService : IFamilyReader
    {
        private FamilyDBContext familyDbContext;

        public SqlFamilyService(FamilyDBContext familyDbContext)
        {
            this.familyDbContext = familyDbContext;
        }


        public async Task<IList<Family>> GetAllFamiliesAsync()
        {
            return await familyDbContext.Families.ToListAsync();
        }

        public async Task<Family> AddFamilyAsync(Family family)
        {
            EntityEntry<Family> newFamily = await familyDbContext.AddAsync(family);
            await familyDbContext.SaveChangesAsync();
            return newFamily.Entity;
        }

        public async Task RemoveFamilyAsync(string streetName, int houseNumber)
        {
            Family familyToDelete = await familyDbContext.Families.FirstOrDefaultAsync(t =>
                t.StreetName.Equals(streetName) && t.HouseNumber == houseNumber);
            if (familyToDelete != null)
            {
                familyDbContext.Families.Remove(familyToDelete);
                await familyDbContext.SaveChangesAsync();
            }
        }

        public async Task<Family> UpdateFamilyAsync(Family family)
        {
            Family familyToUpdate = await familyDbContext.Families.FirstOrDefaultAsync(t =>
                t.StreetName.Equals(family.StreetName) && t.HouseNumber == family.HouseNumber);
            familyDbContext.Update(familyToUpdate);
            
            return familyToUpdate;
        }

        public async Task<Family> GetFamilyAsync(string streetName, int houseNumber)
        {
            Family familyToReturn = await familyDbContext.Families.FirstAsync(t =>
                t.StreetName.Equals(streetName) && t.HouseNumber == houseNumber);
            return familyToReturn;
        }
    }
}