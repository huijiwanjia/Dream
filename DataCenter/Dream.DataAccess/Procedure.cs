using System;
using System.Collections.Generic;
using System.Text;

namespace Dream.DataAccess
{
    public class Procedure
    {
        public static string GetUserByUnionId => "GetUserByUnionId";
        public static string GetUserByUserId => "GetUserByUserId";
        public static string GetTeamByUserId => "GetTeamByUserId";
        public static string GetTeamTotalCountByUserId => "GetTeamTotalCountByUserId";
        
        public static string GetRecommentByUnionId => "GetRecommentByUnionId";
        public static string GetClickLogByItemIdAndClickTime => "GetClickLogByItemIdAndClickTime";
        public static string GetOrderByCode => "GetOrderByCode";
        public static string GetUserOrders => "GetUserOrders";
        public static string UpdateOrderStatus => "UpdateOrderStatus";
        public static string GetSpQuery => "sp_query";
        public static string RecommentRecord => "RecommentRecord";
        public static string GetUserProfits => "GetUserProfits";
        public static string GetRemainAmount => "GetRemainAmount";
        public static string MutiUpdateProfitStatus => "MutiUpdateProfitStatus";
        public static string UpdateWithdrawStatus => "UpdateWithdrawStatus";
        public static string GetWithdrawByUserId => "GetWithdrawByUserId";
        public static string GetProfitUser => "GetProfitUser";
        public static string GetUserViewModelByUserId => "GetUserViewModelByUserId";
    }
}
