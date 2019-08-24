using System;
using System.Collections.Generic;
using System.Text;

namespace Dream.Model.Enums
{
    public enum AgencyType
    {
        NotAgency,
        City,
        Country
    }

    public enum Sex
    {
        Male = 1,
        Female = 2
    }

    public enum AccountStatus
    {
        Normal,
        Disabled
    }
    /// <summary>
    /// 订单录入类型
    /// </summary>
    public enum OrderType {
        Import,
        Manual
    }
    public enum OrderState
    {
        已付款,
        已收货,
        已结算,
        已失效,
        已返利
    }
    public enum ProfitType
    {
       OrderBack
    }
    public enum ProfitStatus
    {
        Active,
        InActive
    }

    public enum WithdrawStatus
    {
        NotCompleted,
        Completed
    }
}
