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
using Dream.Model.Admin;

namespace Dream.DataAccess.Service
{
    public class UserService : IUserService
    {
        public async Task<ApiResult<IEnumerable<UserInfo>>> Query(UserQuery userQuery)
        {
            string table = "USER", fields = "*", orderby = "ORDER BY CreateTime DESC";
            var sqlWhere = new StringBuilder("1=1");
            ApiResult<IEnumerable<UserInfo>> ret = new ApiResult<IEnumerable<UserInfo>>();

            //查询条件
            if (!string.IsNullOrWhiteSpace(userQuery.Account)) sqlWhere.Append($"AND Account='{userQuery.Account}'");
            if (!string.IsNullOrWhiteSpace(userQuery.Password)) sqlWhere.Append($"AND Password='{userQuery.Password}'");
            if (!string.IsNullOrWhiteSpace(userQuery.Name)) sqlWhere.Append($"AND Name like '%{userQuery.Name}%'");
            if (!string.IsNullOrWhiteSpace(userQuery.CreateTime))
            {
                var pl = userQuery.CreateTime.Split('-', StringSplitOptions.RemoveEmptyEntries);
                var startTime = pl[0].Trim();
                var endTime = pl[1].Trim();
                if(!string.IsNullOrWhiteSpace(startTime))sqlWhere.Append($"AND CreateTime >= '{startTime}'");
                if (!string.IsNullOrWhiteSpace(endTime)) sqlWhere.Append($"AND CreateTime <= '{endTime}'");
            }
            if (userQuery.Enable != null) sqlWhere.Append($"AND Enable={userQuery.Enable}");
            if (userQuery.Role != null) sqlWhere.Append($"AND Role in ({userQuery.Role})");
            if (userQuery.ID != null) sqlWhere.Append($"AND ID={userQuery.ID}");

            //
            if (!string.IsNullOrWhiteSpace(userQuery.OrderBy)) orderby = userQuery.OrderBy;
            if (!string.IsNullOrWhiteSpace(userQuery.Fields)) fields = userQuery.Fields;
            using (IDbConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                var p = new DynamicParameters();
                p.Add("@tblName", table);
                p.Add("@strGetFields", fields);
                p.Add("@strOrder", orderby);
                p.Add("@strWhere", sqlWhere.ToString());
                if (userQuery.PageIndex != null) p.Add("@pageIndex", userQuery.PageIndex);
                if (userQuery.PageSize != null) p.Add("@pageSize", userQuery.PageSize);
                if (userQuery.NeedTotalCount) p.Add("@doCount", 1);
                else p.Add("@doCount", 0);
                p.Add("@recordCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
                ret.Data = await conn.QueryAsync<UserInfo>("sp_query", p, commandType: CommandType.StoredProcedure);
                if (userQuery.NeedTotalCount) ret.TotalCount = p.Get<int>("@recordCount");
            }
            ret.Code = ApiResultStatus.Success;
            return ret;
        }

    }
}
