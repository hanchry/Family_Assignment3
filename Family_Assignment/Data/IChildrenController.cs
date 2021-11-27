using System.Threading.Tasks;
using Model;

namespace Family_Assignment.Data
{
    public interface IChildrenController
    {
        Task AddChildAsync(string streetName, int houseNumber, Child child);
        Task RemoveChildAsync(int id);
    }
}