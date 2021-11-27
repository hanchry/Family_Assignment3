using System.Threading.Tasks;
using Model;

namespace FamilyWebApi.Data
{
    public interface IJobReader
    {
        Task<Job> AddJobAsync(int childId, Job  job);
        Task RemoveJobAsync(int id);
    }
}