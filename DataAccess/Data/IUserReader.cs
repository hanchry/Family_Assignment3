using System.Threading.Tasks;
using Models;

namespace FamilyWebApi.Data
{
    public interface IUserReader
    {
       Task<User> ValidateUserAsync(string userName);
        Task<User> RegisterUserAsync(User user);
    }
}