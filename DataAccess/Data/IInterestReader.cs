using System.Threading.Tasks;
using Model;

namespace FamilyWebApi.Data
{
    public interface IInterestReader
    {
        Task<Interest> AddInterestAsync(int childId, Interest interest);
        Task RemoveInterestAsync(int id);
    }
}