using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace FamilyWebApi.Data
{
    public interface IFamilyReader
    {
        Task<IList<Family>> GetAllFamiliesAsync();
        Task<Family> AddFamilyAsync(Family family);

        Task<Child> AddChildAsync(string streetName, int houseNumber, Child child);
        Task<Pet> AddPetToFamilyAsync(string streetName, int houseNumber, Pet pet);
        Task<Adult> AddAdultAsync(string streetName, int houseNumber, Adult adult);
        
        Task RemoveAdultAsync(int id);
        Task<Pet> AddPetToChildAsync(int childId, Pet pet);
        Task<Interest> AddInterestAsync(int childId, Interest interest);
        Task RemoveChildAsync(int id);
        Task RemoveInterestAsync(int id);
        Task RemovePetAsync(int id);
        Task RemoveFamilyAsync(string streetName,int houseNumber);
        Task<Family> UpdateFamilyAsync(Family family);
        Task<Family> GetFamilyAsync(string streetName, int houseNumber);
    }
}