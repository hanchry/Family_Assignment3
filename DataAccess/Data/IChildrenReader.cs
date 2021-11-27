using System.Threading.Tasks;
using Model;

namespace FamilyWebApi.Data
{
    public interface IChildrenReader
    {
        Task<Child> AddChildAsync(string streetName, int houseNumber, Child child);
        Task RemoveChildAsync(int id);
    }
}