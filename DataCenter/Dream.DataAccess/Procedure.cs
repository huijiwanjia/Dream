using System;
using System.Collections.Generic;
using System.Text;

namespace Dream.DataAccess
{
    public class Procedure
    {
        public static string GetUserByUnionId => "GetUserByUnionId";
        public static string GetRecommentByUnionId => "GetRecommentByUnionId";
        public static string GetClickLogByItemIdAndClickTime => "GetClickLogByItemIdAndClickTime";
        public static string GetOrderByOrderByCode => "GetOrderByOrderByCode";
        public static string GetUserOrders => "GetUserOrders";
        public static string UpdateOrderStatus => "UpdateOrderStatus";
        public static string GetSpQuery => "sp_query";
        public static string RecommentRecord => "RecommentRecord";
    }
}
