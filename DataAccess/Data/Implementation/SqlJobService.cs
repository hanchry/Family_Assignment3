using System.Threading.Tasks;
using DataAccess.Database;
using Model;
using System.Linq;

namespace FamilyWebApi.Data
{
    public class SqlJobService : IJobReader
    {
        private FamilyDBContext familyDbContext;

        public SqlJobService(FamilyDBContext familyDbContext)
        {
            this.familyDbContext = familyDbContext;
        }

        public async Task<Job> AddJobAsync(int childId, Job job)
        {
            familyDbContext.Adults.FirstOrDefault(t => t.Id == childId).JobTittle = job;
            familyDbContext.Jobs.Add(job);
            await familyDbContext.SaveChangesAsync();
            return job;
        }

        public async Task RemoveJobAsync(int id)
        {
            Job jobToDelete = familyDbContext.Jobs.FirstOrDefault(t => t.Id == id);
            familyDbContext.Jobs.Remove(jobToDelete);
            await familyDbContext.SaveChangesAsync();
        }
    }
}