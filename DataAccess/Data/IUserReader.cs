using System.Threading.Tasks;
using Model;

namespace FamilyWebApi.Data
{
    public interface IUserReader
    {
       Task<User> ValidateUserAsync(string userName);
        Task<User> RegisterUserAsync(User user);
    }
}