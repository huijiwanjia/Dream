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

namespace Dream.DataAccess.Service
{
    public class ProfitService : IProfitService
    {
        private ILog _log;
        public ProfitService(ILog l)
        {
            _log = l;
        }

        public async Task AddProfits(Profit profit)
        {
            profit.CreateTime = DateTime.Now;

            using (IDbConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                var transaction = conn.BeginTransaction();
                try
                {
                    await conn.InsertAsync<Profit>(profit, transaction);
                    if (profit.Type == ProfitType.ShareBack)
                    {
                        //更新订单分享信息
                        await conn.ExecuteAsync(Procedure.UpdateOrderShareStatus, new { code = profit.FromOrder, status = true }, transaction, null, CommandType.StoredProcedure);
                    }
                    transaction.Commit();
                }
                catch(Exception ex) {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public async Task<IEnumerable<Profit>> GetUserProfits(int userId)
        {
            using (IDbConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                var profits = await conn.QueryAsync<Profit>(Procedure.GetUserProfits, new { userId, type = ProfitType.OrderBack, status = -1 }, null, null, CommandType.StoredProcedure);
                return profits;
            }
        }
        public async Task<IEnumerable<Withdraw>> QueryWithdraw(Withdraw withdraw)
        {
            using (IDbConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                var status = (int)withdraw.Status;
                var withdrawRet = await conn.QueryAsync<Withdraw>(Procedure.GetWithdrawByUserId, new { withdraw.UserId, status = -1 }, null, null, CommandType.StoredProcedure);
                return withdrawRet;
            }
        }
        public async Task<JqTableData<Withdraw>> QueryWithdrawData(JqTableParams param)
        {
            IEnumerable<Withdraw> users;
            var paginationQuery = new PaginationQuery()
            {
                NeedTotalCount = true,
                TableName = "withdraw",
                Fields = "*",
                Orderby = " ORDER BY Id ASC ",
                PageIndex = param.iDisplayStart / param.iDisplayLength + 1,
                PageSize = param.iDisplayLength,
                SqlWhere = GenerateSqlWhere(param)
            };
            var jqTableData = new JqTableData<Withdraw>()
            {
                sEcho = param.sEcho,
            };
            using (IDbConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                DynamicParameters dynamicParameters = paginationQuery.GenerateParameters();
                users = await conn.QueryAsync<Withdraw>("sp_query", dynamicParameters, commandType: CommandType.StoredProcedure);
                if (paginationQuery.NeedTotalCount) jqTableData.iTotalDisplayRecords = dynamicParameters.Get<int>("@recordCount");
            }
            jqTableData.iTotalRecords = users.Count();
            jqTableData.aaData = users;
            return jqTableData;
        }

        /// <summary>
        /// 改变状态
        /// </summary>
        /// <param name="projectId">Id</param>
        /// <param name="currentStatu">状态参数</param>
        /// <param name="errorBackMsg"></param>
        /// <returns></returns>
        public bool ChangeWithdrawStatus(int id, WithdrawStatus State)
        {
            using (IDbConnection conn = DBConnection.CreateConnection())
            {
                var status = (int)State;
                if (conn.Execute(Procedure.UpdateWithdrawStatus, new { id, status }, null, null, CommandType.StoredProcedure) > 0) return true;
                else return false;
            }
        }
        public async Task<double> GetRemainAmountAsync(int userId)
        {
            using (IDbConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                var remainAmount = await conn.QueryFirstAsync<double>(Procedure.GetRemainAmount, new { userId }, null, null, CommandType.StoredProcedure);
                return remainAmount;
            }
        }
        public async Task WithdrawApplyAsync(int userId)
        {
            using (IDbConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                var transaction = conn.BeginTransaction();
                try
                {
                    var profits = await conn.QueryAsync<Profit>(Procedure.GetUserProfits, new { userId, type = ProfitType.OrderBack, status = (int)ProfitStatus.Active }, transaction, null, CommandType.StoredProcedure);
                    double remainAmount = profits.Select(p => p.Amount).Sum();

                    var withdraw = new Withdraw()
                    {
                        Amount = remainAmount,
                        ApplyTime = DateTime.Now,
                        UserId = userId,
                        Status = WithdrawStatus.NotCompleted
                    };
                    await conn.InsertAsync(withdraw, transaction);
                    await conn.ExecuteAsync(Procedure.MutiUpdateProfitStatus, new { profitIds = string.Join(",", profits.Select(p => p.ProfitId)), status = ProfitStatus.InActive }, transaction, null, CommandType.StoredProcedure);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw (ex);
                }
            }
        }
        #region private
        private string GenerateSqlWhere(JqTableParams param)
        {
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
                strWhere += string.Format(" and (Id like '%{0}%' or Amount like '%{0}%' or ApplyTime like '%{0}%' or UserId like '%{0}%' or Status like '%{0}%' ) ", param.sSearch);
            strWhere += string.Format(" and ApplyTime > '{0}' and ApplyTime < '{1}'", startTime, endTime);
            return strWhere;
        }
        #endregion
    }
}
