using System.Threading.Tasks;
using Model;

namespace Family_Assignment.Data
{
    public interface IPetController
    {
        Task AddChildPetAsync(int childId, Pet pet);
        Task AddFamilyPetAsync(string streetName, int houseNumber, Pet pet);
        Task RemovePetAsync(int id);
    }
}