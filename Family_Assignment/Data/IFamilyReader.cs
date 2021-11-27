﻿using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Model;

namespace Family_Assignment.Data
{
    public interface IFamilyReader
    {
        Task<IList<Family>> GetAllFamiliesAsync();
         Task AddFamilyAsync(Family family);
         Task AddChildAsync(string streetName, int houseNumber, Child adult);

         Task AddChildPetAsync(int childId, Pet pet);
         Task AddFamilyPetAsync(string streetName, int houseNumber, Pet pet);

         Task RemovePetAsync(int id);
         Task RemoveChildAsync(int id);
         Task RemoveFamilyAsync(Family family);
         Task UpdateFamilyAsync(Family family);
         Task UpdateChildAsync(string streetName, int houseNumber, Child child);
         Task<Family> GetFamilyAsync(string streetName, int houseNumber);
    }
}