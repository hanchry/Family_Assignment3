using System.Threading.Tasks;
using Model;

namespace FamilyWebApi.Data
{
    public interface IAdultReader
    {
        Task<Adult> AddAdultAsync(string streetName, int houseNumber, Adult adult);
        Task RemoveAdultAsync(int id);
    }
}