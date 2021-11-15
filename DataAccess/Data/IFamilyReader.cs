using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace FamilyWebApi.Data
{
    public interface IFamilyReader
    {
        Task<IList<Family>> GetAllFamiliesAsync();
        Task<Family> AddFamilyAsync(Family family);
        Task RemoveFamilyAsync(string streetName,int streetNumber);
        Task<Family> UpdateFamilyAsync(Family family);
        Task<Family> GetFamilyAsync(string streetName, int houseNumber);
    }
}