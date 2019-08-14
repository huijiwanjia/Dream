﻿using Dream.Logger;
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
