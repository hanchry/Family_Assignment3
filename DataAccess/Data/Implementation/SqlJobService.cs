using System.Threading.Tasks;
using DataAccess.Database;
using Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FamilyWebApi.Data
{
    public class SqlJobService : IJobReader
    {
        private FamilyDBContext familyDbContext;

        public SqlJobService(FamilyDBContext familyDbContext)
        {
            this.familyDbContext = familyDbContext;
        }

        public async Task<Job> AddJobAsync(int adultId, Job job)
        {
            familyDbContext.Adults.Include(s=>s.JobTittle).First(t => t.Id == adultId).JobTittle = job;
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