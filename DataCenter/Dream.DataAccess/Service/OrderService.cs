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
        public async Task UserOrderCheckAndMappingAsync(Order order) {
            if (order != null)
            {
                using (IDbConnection conn = DBConnection.CreateConnection())
                {
                    conn.Open();
                    var clickLog= await _clickLogService.QueryAsync(order.ClickTime, order.ItemId);
                    order.UserId = clickLog?.UserId;
                    order.Type = OrderType.Import;
                    await conn.InsertAsync<Order>(order);
                }
            }
        }
    }
}
