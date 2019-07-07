using Dream.Logger;
using Dream.Model.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using Dream.DataAccess.IService;
using Dream.Model;
using System.Linq;

namespace Dream.DataAccess.Service
{
    public class UserService : IUserService
    {
        public async Task<IEnumerable<UserInfo>> QueryAsync(UserQuery user)
        {
            return null;
        }
        public async Task<UserInfo> QueryAsync(string unionId)
        {
            using (IDbConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                var user = await conn.QueryFirstOrDefaultAsync<UserInfo>(Procedure.GetUserByUnionId, unionId, null, null, CommandType.StoredProcedure);
                return user;
            }
        }
    }
}
