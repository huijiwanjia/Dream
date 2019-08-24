using Dream.Logger;
using Dream.Model;
using Dream.Model.Api;
using Dream.Model.Admin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dream.Model.Enums;

namespace Dream.DataAccess.IService
{
    public interface IOrderService
    {
        Task UserOrderCheckAndMappingAsync(OrderInfo order);
        Task<OrderInfo> GetOrderByCode(string code);
        Task<IEnumerable<OrderInfo>> GetUserOrders(int userId);
        Task<JqTableData<OrderInfo>> QueryPaginationData(JqTableParams param);
        bool ChangeOrderStatus(int id, OrderState state);
    }
}
