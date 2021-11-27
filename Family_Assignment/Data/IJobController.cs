using System.Threading.Tasks;
using Model;

namespace Family_Assignment.Data
{
    public interface IJobController
    {
        Task AddJobAsync(int adultId,Job job);
        Task RemoveJobAsync(int id);
    }
}