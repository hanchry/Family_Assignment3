using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace FamilyWebApi.Data
{
    public interface IFamilyReader
    {
        Task<IList<Family>> GetAllFamiliesAsync();
        Task<Family> AddFamilyAsync(Family family);

        Task<Child> AddChildAsync(string streetName, int houseName, Child adult);
        Task RemoveFamilyAsync(string streetName,int houseNumber);
        Task<Family> UpdateFamilyAsync(Family family);
        Task<Family> GetFamilyAsync(string streetName, int houseNumber);
    }
}