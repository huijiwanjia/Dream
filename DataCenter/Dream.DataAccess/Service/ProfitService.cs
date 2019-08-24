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

        public async Task<IEnumerable<Profit>> GetUserProfits(int userId)
        {

            using (IDbConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                var profits = await conn.QueryAsync<Profit>(Procedure.GetUserProfits, new { userId, type = ProfitType.OrderBack, status = -1 }, null, null, CommandType.StoredProcedure);
                return profits;
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
    }
}
