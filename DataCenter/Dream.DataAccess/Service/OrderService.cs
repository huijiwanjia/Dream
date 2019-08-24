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
    public class OrderService : IOrderService
    {
        private IClickLogService _clickLogService;
        public OrderService(IClickLogService c)
        {
            _clickLogService = c;
        }

        public async Task<JqTableData<OrderInfo>> QueryPaginationData(JqTableParams param)
        {
            IEnumerable<OrderInfo> users;
            var paginationQuery = new PaginationQuery()
            {
                NeedTotalCount = true,
                TableName = "OrderInfo",
                Fields = "*",
                Orderby = " ORDER BY BuyDate DESC ",
                PageIndex = param.iDisplayStart / param.iDisplayLength + 1,
                PageSize = param.iDisplayLength,
                SqlWhere = GenerateSqlWhere(param)
            };
            var jqTableData = new JqTableData<OrderInfo>()
            {
                sEcho = param.sEcho,
            };
            using (IDbConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                DynamicParameters dynamicParameters = paginationQuery.GenerateParameters();
                users = await conn.QueryAsync<OrderInfo>(Procedure.GetSpQuery, dynamicParameters, commandType: CommandType.StoredProcedure);
                if (paginationQuery.NeedTotalCount) jqTableData.iTotalDisplayRecords = dynamicParameters.Get<int>("@recordCount");
            }
            jqTableData.iTotalRecords = users.Count();
            jqTableData.aaData = users;
            return jqTableData;
        }

        /// <summary>
        /// 改变返利状态
        /// </summary>
        /// <param name="projectId">Id</param>
        /// <param name="currentStatu">状态参数</param>
        /// <param name="errorBackMsg"></param>
        /// <returns></returns>
        public bool ChangeOrderStatus(int id, OrderState orderState)
        {
            using (IDbConnection conn = DBConnection.CreateConnection())
            {
                var state = (int)orderState;
                if (conn.Execute(Procedure.UpdateOrderStatus, new { id, state }, null, null, CommandType.StoredProcedure) > 0) return true;
                else return false;
            }
        }
        public async Task UserOrderCheckAndMappingAsync(OrderInfo order)
        {
            if (order != null)
            {
                using (IDbConnection conn = DBConnection.CreateConnection())
                {
                    conn.Open();
                    IDbTransaction transaction = conn.BeginTransaction();
                    try
                    {
                        var orderInfo = await conn.QueryFirstOrDefaultAsync<OrderInfo>(Procedure.GetOrderByCode, new { order.Code }, transaction, null, CommandType.StoredProcedure);

                        if (orderInfo != null)
                        {
                            orderInfo.State = order.State;
                            orderInfo.BackPrice = order.BackPrice;
                            orderInfo.ProfitId = await CheckAndAddOrderProfit(orderInfo, conn, transaction);
                            await conn.UpdateAsync<OrderInfo>(orderInfo, transaction);
                        }
                        else
                        {
                            var clickLog = await _clickLogService.QueryAsync(order.ClickTime, order.ItemId);
                            order.UserId = clickLog?.UserId;
                            order.Type = OrderType.Import;
                            order.CreateTime = DateTime.Now;
                            order.ProfitId = await CheckAndAddOrderProfit(order, conn, transaction);
                            await conn.InsertAsync<OrderInfo>(order, transaction);
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<OrderInfo> GetOrderByCode(string code)
        {
            using (IDbConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                var orderInfo = await conn.QueryFirstOrDefaultAsync<OrderInfo>(Procedure.GetOrderByCode, new { code }, null, null, CommandType.StoredProcedure);
                return orderInfo;
            }
        }

        public async Task<IEnumerable<OrderInfo>> GetUserOrders(int userId)
        {
            using (IDbConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                var orders = await conn.QueryAsync<OrderInfo>(Procedure.GetUserOrders, new { userId }, null, null, CommandType.StoredProcedure);
                return orders;
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
                strWhere += string.Format(" and (Id like '%{0}%' or ShopName like '%{0}%' or ItemId like '%{0}%' or ItemPrice like '%{0}%' or BackPrice like '%{0}%' ) ", param.sSearch);
            strWhere += string.Format(" and BuyDate > '{0}' and BuyDate < '{1}'", startTime, endTime);
            return strWhere;
        }

        private async Task<int> CheckAndAddOrderProfit(OrderInfo orderInfo, IDbConnection conn, IDbTransaction transaction = null)
        {
            var profit = new Profit();
            if (orderInfo.State == OrderState.已结算 && !orderInfo.ProfitId.HasValue && orderInfo.ProfitId != 0)
            {
                profit.CreateTime = DateTime.Now;
                profit.Status = ProfitStatus.Active;
                profit.Type = ProfitType.OrderBack;
                profit.UserId = orderInfo.UserId;
                profit.Amount = orderInfo.BackPrice;
                profit.ProfitId = await conn.InsertAsync<Profit>(profit, transaction);
            }
            return profit.ProfitId == 0 ? orderInfo.ProfitId ?? 0 : profit.ProfitId;
        }

        #endregion
    }
}
