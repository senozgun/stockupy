using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _sqlDb;

        public UserData(ISqlDataAccess sqlDb)
        {
            _sqlDb = sqlDb;
        }

        public Task<UserModel> GetUserForLogin(UserModel model)
        {
            string sql = "Select * From dbo.u_User Where Username=@Username And Password=@Password";

            var data = _sqlDb.FindOneData<UserModel, dynamic>(sql, model);

            return data;
        }

        public Task<List<UserModel>> GetUserList()
        {
            string sql = "Select * From dbo.u_User";

            var data = _sqlDb.LoadData<UserModel, dynamic>(sql, new { });

            return data;
        }
    }
}
