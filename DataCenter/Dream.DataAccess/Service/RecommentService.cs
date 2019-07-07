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
using Dapper.Contrib.Extensions;

namespace Dream.DataAccess.Service
{
    public class RecommentService : IRecommentService
    {
        public async Task<Recomment> QueryAsync(string unionId)
        {
            using (IDbConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                var recoment = await conn.QueryFirstOrDefaultAsync<Recomment>(Procedure.GetRecommentByUnionId, new { unionId }, null, null, CommandType.StoredProcedure);
                return recoment;
            }
        }
    }
}
