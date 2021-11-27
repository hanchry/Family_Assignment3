using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Database;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Model;

namespace FamilyWebApi.Data
{
    public class SqlInterestService :IInterestReader
    {
        private FamilyDBContext familyDbContext;

        public SqlInterestService(FamilyDBContext familyDbContext)
        {
            this.familyDbContext = familyDbContext;
        }

        public async Task<Interest> AddInterestAsync(int childId, Interest interest)
        {
            
            familyDbContext.Children.FirstOrDefault(t => t.Id == childId).Interests = new List<Interest>();
            familyDbContext.Children.FirstOrDefault(t => t.Id == childId).Interests.Add(interest);
            familyDbContext.Interest.Add(interest);
            await familyDbContext.SaveChangesAsync();
            return interest;
        }

        public async Task RemoveInterestAsync(int id)
        {
            Interest interestToDelete = familyDbContext.Interest.FirstOrDefault(t => t.Id == id);
            familyDbContext.Interest.Remove(interestToDelete);
            await familyDbContext.SaveChangesAsync();
        }
    }

    
}