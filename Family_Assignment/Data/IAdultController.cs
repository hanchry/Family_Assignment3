using System.Threading.Tasks;
using Model;

namespace Family_Assignment.Data
{
    public interface IAdultController
    {
        Task AddAdultAsync(string streetName, int houseNumber, Adult adult);
        Task RemoveAdultAsync(int id);
        Task UpdateAdultAsync(Adult adult);
    }
}