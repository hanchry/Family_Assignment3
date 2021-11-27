using System.Threading.Tasks;
using Model;

namespace FamilyWebApi.Data
{
    public interface IPetReader
    {
        Task<Pet> AddPetToChildAsync(int childId, Pet pet);
        Task<Pet> AddPetToFamilyAsync(string streetName, int houseNumber, Pet pet);
        Task RemovePetAsync(int id);
    }
}