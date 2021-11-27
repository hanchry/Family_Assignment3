using System;
using System.Threading.Tasks;
using DataAccess.Database;
using Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FamilyWebApi.Data
{
    public class SqlPetService : IPetReader
    {
        private FamilyDBContext familyDbContext;

        public SqlPetService(FamilyDBContext familyDbContext)
        {
            this.familyDbContext = familyDbContext;
        }

        public async Task<Pet> AddPetToChildAsync(int childId, Pet pet)
        {
            familyDbContext.Children.Include(t=>t.Pets).First(t => t.Id == childId).Pets.Add(pet);
            familyDbContext.Pets.Add(pet);
            await familyDbContext.SaveChangesAsync();
            return pet;
        }

        public async Task<Pet> AddPetToFamilyAsync(string streetName, int houseNumber, Pet pet)
        {
            familyDbContext.Families
                .FirstOrDefault(t => t.StreetName.Equals(streetName) && t.HouseNumber == houseNumber).Pets.Add(pet);
            familyDbContext.Pets.Add(pet);
            await familyDbContext.SaveChangesAsync();
            return pet;
        }

        public async Task RemovePetAsync(int id)
        {
            Pet petToDelete = familyDbContext.Pets.FirstOrDefault(t => t.Id == id);
            familyDbContext.Pets.Remove(petToDelete);
            await familyDbContext.SaveChangesAsync();
        }
    }
}