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
        public async Task RecordAsync(Recomment recomment)
        {
            using (IDbConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                recomment.CreateTime = DateTime.Now;
                await conn.ExecuteAsync(Procedure.RecommentRecord, new { recomment.Unionid,recomment.PId,recomment.CreateTime }, null, null, CommandType.StoredProcedure);
            }
        }
    }
}
