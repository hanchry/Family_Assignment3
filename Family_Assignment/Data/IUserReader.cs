using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace Family_Assignment.Data
{
    public interface IUserReader
    {
      Task<User> ValidateUser(string userName, string password);
      Task<User> RegisterUser(string userName, string password);
    }
}