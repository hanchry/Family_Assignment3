using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Model;

namespace Family_Assignment.Data
{
    public interface IFamilyReader
    {
        Task<IList<Family>> GetAllFamiliesAsync();
         Task AddFamilyAsync(Family family);
         Task RemoveFamilyAsync(Family family);
         Task UpdateFamilyAsync(Family family);
         Task<Family> GetFamilyAsync(string streetName, int houseNumber);
    }
}