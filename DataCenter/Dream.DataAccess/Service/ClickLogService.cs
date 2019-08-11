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
    public class ClickLogService : IClickLogService
    {
        public async Task InsertLogAsync(ClickLog log)
        {
            if (log != null)
            {
                using (IDbConnection conn = DBConnection.CreateConnection())
                {
                    conn.Open();
                    log.ClickTime = DateTime.Now;
                    await conn.InsertAsync<ClickLog>(log);
                }
            }
        }
        public async Task<ClickLog> QueryAsync(DateTime clickTime, string itemId)
        {
            using (IDbConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                int diff = 60 * 1; // 1分钟
                var clickLog = await conn.QueryFirstOrDefaultAsync<ClickLog>(Procedure.GetClickLogByItemIdAndClickTime, new { itemId, clickTime, diff }, null, null, CommandType.StoredProcedure);
                return clickLog;
            }
        }
    }
}
