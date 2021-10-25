﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace FamilyWebApi.Data
{
    public class FileReader : IFamilyReader
    {
        private FileContext FileContext;
        private IList<Family> families;
        

        public FileReader()
        {
            FileContext = new FileContext();
            families = FileContext.Families;
        }

        public async Task<IList<Family>> GetAllFamiliesAsync()
        {
            return families;
        }

        public async Task<Family> AddFamilyAsync(Family family)
        {
            families.Add(family);
            FileContext.SaveChanges();
            return family;
        }

        public async Task RemoveFamilyAsync(string streetName, int houseNumber)
        {
            Family family =
                families.FirstOrDefault(
                    t => t.StreetName.Equals(streetName) && t.HouseNumber == houseNumber);
            families.Remove(family);
            FileContext.SaveChanges();
        }

        public async Task<Family> UpdateFamilyAsync(Family family)
        {
        
            Family familyToUpdate = families.FirstOrDefault(t =>
                t.StreetName.Equals(family.StreetName) && t.HouseNumber == family.HouseNumber);
            int indexOf = families.IndexOf(familyToUpdate);
            families.RemoveAt(indexOf);
            familyToUpdate = family;
            families.Insert(indexOf, familyToUpdate);
            FileContext.SaveChanges();
            return familyToUpdate;
        }

        public async Task<Family> GetFamilyAsync(string streetName, int houseNumber)
        {
            return families.FirstOrDefault(family =>
                family.StreetName.Equals(streetName) && family.HouseNumber.Equals(houseNumber));
        }

        
    }
}