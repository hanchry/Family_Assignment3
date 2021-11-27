using System;
using System.Collections.Generic;
using System.Linq;
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
            return await familyDbContext.Families.Include(s => s.Pets).Include(t => t.Adults)
                .ThenInclude(t => t.JobTittle)
                .Include(t => t.Children).ThenInclude(t => t.Pets).Include(t => t.Children)
                .ThenInclude(t => t.Interests).ToListAsync();
        }

        public async Task<Family> AddFamilyAsync(Family family)
        {
            EntityEntry<Family> newFamily = await familyDbContext.AddAsync(family);
            await familyDbContext.SaveChangesAsync();
            return newFamily.Entity;
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

        // public async Task<Adult> AddAdultAsync(string streetName, int houseNumber, Adult adult)
        // {
        //     familyDbContext.Families
        //         .FirstOrDefault(t => t.StreetName.Equals(streetName) && t.HouseNumber == houseNumber).Adults.Add(adult);
        //     familyDbContext.Adults.Add(adult);
        //     await familyDbContext.SaveChangesAsync();
        //     return adult;
        // }

        public async Task<Job> AddJobAsync(int childId, Job job)
        {
            familyDbContext.Adults.FirstOrDefault(t => t.Id == childId).JobTittle = job;
            familyDbContext.Jobs.Add(job);
            await familyDbContext.SaveChangesAsync();
            return job;
        }

        public async Task RemoveAdultAsync(int id)
        {
            Adult adultToDelete = familyDbContext.Adults.FirstOrDefault(t => t.Id == id);
            familyDbContext.Adults.Remove(adultToDelete);
            await familyDbContext.SaveChangesAsync();
        }

        public async Task RemoveJobAsync(int id)
        {
            Job jobToDelete = familyDbContext.Jobs.FirstOrDefault(t => t.Id == id);
            familyDbContext.Jobs.Remove(jobToDelete);
            await familyDbContext.SaveChangesAsync();
        }

        public async Task<Pet> AddPetToFamilyAsync(string streetName, int houseNumber, Pet pet)
        {
            familyDbContext.Families
                .FirstOrDefault(t => t.StreetName.Equals(streetName) && t.HouseNumber == houseNumber).Pets.Add(pet);
            familyDbContext.Pets.Add(pet);
            await familyDbContext.SaveChangesAsync();
            return pet;
        }

        public async Task<Pet> AddPetToChildAsync(int childId, Pet pet)
        {
            familyDbContext.Children.FirstOrDefault(t => t.Id == childId).Pets.Add(pet);
            familyDbContext.Pets.Add(pet);
            await familyDbContext.SaveChangesAsync();
            return pet;
        }

        public async Task<Interest> AddInterestAsync(int childId, Interest interest)
        {
            familyDbContext.Children.FirstOrDefault(t => t.Id == childId).Interests.Add(interest);
            familyDbContext.Interest.Add(interest);
            await familyDbContext.SaveChangesAsync();
            return interest;
        }

        public async Task RemovePetAsync(int id)
        {
            Pet petToDelete = familyDbContext.Pets.FirstOrDefault(t => t.Id == id);
            familyDbContext.Pets.Remove(petToDelete);
            await familyDbContext.SaveChangesAsync();
        }

        public async Task RemoveInterestAsync(int id)
        {
            Interest interestToDelete = familyDbContext.Interest.FirstOrDefault(t => t.Id == id);
            familyDbContext.Interest.Remove(interestToDelete);
            await familyDbContext.SaveChangesAsync();
        }

        public async Task RemoveChildAsync(int id)
        {
            Child childToDelete = familyDbContext.Children.FirstOrDefault(t => t.Id == id);
            familyDbContext.Children.Remove(childToDelete);
            await familyDbContext.SaveChangesAsync();
        }

        public async Task RemoveFamilyAsync(string streetName, int houseNumber)
        {
            Family familyToDelete = familyDbContext.Families.FirstOrDefault(t =>
                t.StreetName.Equals(streetName) && t.HouseNumber == houseNumber);
            if (familyToDelete != null)
            {
                familyDbContext.Families.Remove(familyToDelete);
                await familyDbContext.SaveChangesAsync();
            }
        }

        public async Task<Family> UpdateFamilyAsync(Family family)
        {
            // Family familyToUpdate = await familyDbContext.Families.FirstOrDefaultAsync(t =>
            //     t.StreetName.Equals(family.StreetName) && t.HouseNumber == family.HouseNumber);
            // familyDbContext.Update(family);

            Family familyToDelete = familyDbContext.Families.FirstOrDefault(t =>
                t.HouseNumber == family.HouseNumber && t.StreetName.Equals(family.StreetName));
            familyDbContext.Families.Remove(familyToDelete);
            await familyDbContext.Families.AddAsync(family);
            await familyDbContext.SaveChangesAsync();
            return family;
        }

        public async Task<Family> GetFamilyAsync(string streetName, int houseNumber)
        {
            Family familyToReturn = await familyDbContext.Families.Include(s => s.Pets).Include(t => t.Adults)
                .ThenInclude(t => t.JobTittle)
                .Include(t => t.Children).ThenInclude(t => t.Pets).Include(t => t.Children)
                .ThenInclude(t => t.Interests)
                .FirstAsync(t =>
                    t.StreetName.Equals(streetName) && t.HouseNumber == houseNumber);
            return familyToReturn;
        }
    }
}