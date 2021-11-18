using System;
using System.Threading.Tasks;
using DataAccess.Database;
using Microsoft.EntityFrameworkCore;
using Model;

namespace FamilyWebApi.Data
{
    public class SqlUserService :IUserReader
    { 
        private FamilyDBContext familyDbContext;

        public SqlUserService(FamilyDBContext familyDbContext)
        {
            this.familyDbContext = familyDbContext;
        }
        public async Task<User> ValidateUserAsync(string userName)
        {
            User checkUser = await familyDbContext.Users.FirstOrDefaultAsync(user => user.UserName.Equals(userName));
            if (checkUser == null)
            {
                throw new Exception("User not found or incorrect username");
            }
            else
            {
                return checkUser;
            }
        }

        public async Task<User> RegisterUserAsync(User userToRegister)
        {
            User checkUser = await familyDbContext.Users.FirstOrDefaultAsync(t => userToRegister.UserName.Equals(t.UserName));
            if (checkUser != null)
            {
                throw new Exception("User already exist !");
            }
            await familyDbContext.Users.AddAsync(userToRegister);
            await familyDbContext.SaveChangesAsync();
            return userToRegister;
        }
    }
}