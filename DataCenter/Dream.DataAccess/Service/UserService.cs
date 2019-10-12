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
using Dream.Model.Enums;
using Dream.Util;

namespace Dream.DataAccess.Service
{
    public class UserService : IUserService
    {
        public async Task<JqTableData<UserInfo>> QueryPaginationData(JqTableParams param)
        {
            IEnumerable<UserInfo> users;
            var paginationQuery = new PaginationQuery()
            {
                NeedTotalCount = true,
                TableName = "UserInfo",
                Fields = "*",
                Orderby = " ORDER BY UserId ASC ",
                PageIndex = param.iDisplayStart / param.iDisplayLength + 1,
                PageSize = param.iDisplayLength,
                SqlWhere=GenerateSqlWhere(param)
            };
            var jqTableData = new JqTableData<UserInfo>()
            {
                sEcho = param.sEcho,
            };
            using (IDbConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                DynamicParameters dynamicParameters = paginationQuery.GenerateParameters();
                users = await conn.QueryAsync<UserInfo>("sp_query", dynamicParameters, commandType: CommandType.StoredProcedure);
                if (paginationQuery.NeedTotalCount) jqTableData.iTotalDisplayRecords = dynamicParameters.Get<int>("@recordCount");
            }
            jqTableData.iTotalRecords = users.Count();
            jqTableData.aaData = users;
            return jqTableData;
        }
        public async Task<UserInfo> QueryAsync(string unionId)
        {
            using (IDbConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                var user = await conn.QueryFirstOrDefaultAsync<UserInfo>(Procedure.GetUserByUnionId, new { unionId }, null, null, CommandType.StoredProcedure);
                return user;
            }
        }

        public async Task<UserInfo> QueryByUserIdAsync(int userId)
        {
            using (IDbConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                var user = await conn.QueryFirstOrDefaultAsync<UserInfo>(Procedure.GetUserByUserId, new { userId }, null, null, CommandType.StoredProcedure);
                return user;
            }
        }

        public async Task<TeamInfo> GetTeamByIdAsync(int userId, bool needTotal = true)
        {
            using (IDbConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                var teamMember = await conn.QueryAsync<UserInfo>(Procedure.GetTeamByUserId, new { userId }, null, null, CommandType.StoredProcedure);
                var team = new TeamInfo();
                team.TeamMember = teamMember;
                team.TotalCount = needTotal ? await conn.QueryFirstAsync<int>(Procedure.GetTeamTotalCountByUserId, new { userId }, null, null, CommandType.StoredProcedure) : 0;
                team.DirectlyCount = teamMember?.Count();

                return team;
            }
        }

        public async Task<UserInfoViewModel> GetViewModelByUserIdAsync(int userId) {
            using (IDbConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                var userViewModel = await conn.QueryFirstOrDefaultAsync<UserInfoViewModel>(Procedure.GetUserViewModelByUserId, new { userId }, null, null, CommandType.StoredProcedure);

                return userViewModel;
            }
        }

        public async Task<UserInfo> UpdateUserAsync(UserInfo userInfo)
        {
            using (IDbConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                var user = await conn.QueryFirstOrDefaultAsync<UserInfo>(Procedure.GetUserByUserId, new { userInfo.UserId }, null, null, CommandType.StoredProcedure);
                if (userInfo.Sex != null) user.Sex = userInfo.Sex;
                if (userInfo.Type != UserType.Commom) user.Type = userInfo.Type;
                if (userInfo.PId != null)
                {
                    var pUser = await conn.QueryFirstOrDefaultAsync<UserInfo>(Procedure.GetUserByUserId, new { userId= userInfo.PId }, null, null, CommandType.StoredProcedure);
                    //此处有一个BUG待修：没有过滤邀请码是自己下级的情况
                    if (pUser != null&& user.UserId != userInfo.PId) user.PId = userInfo.PId;
                    else return null;
                    var team = await GetTeamByIdAsync((int)userInfo.PId, false);
                    //检查推荐人是否达到合伙人资格
                    if (ConfigUtil.GetConfig<DataApiAppSettings>("AppSettings").RecommentNumberToTeamMember == team.TeamMember?.Count() + 1)
                        pUser.Type = UserType.TeamMember;
                    //检查推荐人是否达到超级用户资格
                    else if (ConfigUtil.GetConfig<DataApiAppSettings>("AppSettings").RecommentNumberToSepcial == team.TeamMember?.Count() + 1)
                        pUser.Type = UserType.Sepecial;
                    await conn.UpdateAsync(pUser);
                }
                if (!string.IsNullOrWhiteSpace(userInfo.AliPayName)) user.AliPayName = userInfo.AliPayName;
                if (userInfo.AccountStatus != null) user.AccountStatus = userInfo.AccountStatus;
                if (!string.IsNullOrWhiteSpace(userInfo.AliPay)) user.AliPay = userInfo.AliPay;
                if (!string.IsNullOrWhiteSpace(userInfo.Name)) user.Name = userInfo.Name;
                if (!string.IsNullOrWhiteSpace(userInfo.Phone)) user.Phone = userInfo.Phone;

                await conn.UpdateAsync(user);
                return user;
            }
        }
        #region private
        private string GenerateSqlWhere(JqTableParams param) {
            DateTime? startTime = null;//操作日志创建时间
            DateTime? endTime = null;
            var strWhere = " 1=1 ";
            if (!string.IsNullOrEmpty(param.sDateTimeRange))
            {
                startTime = Convert.ToDateTime(param.sDateTimeRange.Replace(" - ", ",").Split(',')[0]);
                endTime = Convert.ToDateTime(param.sDateTimeRange.Replace(" - ", ",").Split(',')[1]);
            }
            startTime = startTime ?? Convert.ToDateTime("2016-01-01 00:00:00");//时间区间默认值
            endTime = endTime ?? Convert.ToDateTime("2099-01-01 00:00:00");//时间区间默认值
            if (!string.IsNullOrEmpty(param.sSearch))
                strWhere += string.Format(" and (UserId like '%{0}%' or Name like '%{0}%' or Sex like '%{0}%' or AliPay like '%{0}%' or AliPayName like '%{0}%' ) ", param.sSearch);
            strWhere += string.Format(" and CreateTime > '{0}' and CreateTime < '{1}'", startTime, endTime);
            return strWhere;
        }
        #endregion
    }
}
