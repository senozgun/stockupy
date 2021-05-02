using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface IUserData
    {
        Task<UserModel> GetUserForLogin(UserModel model);
        Task<List<UserModel>> GetUserList();
    }
}