using System.Threading.Tasks;
using Model;

namespace Family_Assignment.Data
{
    public interface IInterestController
    {
        Task AddInterestAsync(int interestId,
            Interest interest);
        Task RemoveInterestAsync(int id);
    }
}