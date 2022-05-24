using Dream.Model.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Dream.Model
{
    public class OrderInfo
    {
        public int Id { get; set; }
        /// <summary>
        /// 商品店铺名称
        /// </summary>
        public string ShopName { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public string ItemId { get; set; }
        /// <summary>
        /// 购买日期
        /// </summary>
        public DateTime BuyDate { get; set; }
        /// <summary>
        /// 后台核对日期，可变
        /// </summary>
        public DateTime CheckDate { get; set; }
        /// <summary>
        /// 订单创建日期
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 点击时间
        /// </summary>
        public DateTime ClickTime { get; set; }
        /// <summary>
        /// 返利结算日期
        /// </summary>
        public DateTime? BackDate { get; set; }
        /// <summary>
        /// 商品单价
        /// </summary>
        public double ItemPrice { get; set; }
        /// <summary>
        /// 商品返利金额
        /// </summary>
        public double BackPrice { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderState State { get; set; }
        /// <summary>
        /// 所属用户ID
        /// </summary>
        public int? UserId { get; set; }
        /// <summary>
        /// 商品类型
        /// </summary>
        public OrderType Type { get; set; }
        /// <summary>
        /// 实际付款金额
        /// </summary>
        public double PayPrice { get; set; }
        /// <summary>
        /// 商品标题
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 商品数量
        /// </summary>
        public int ItemCount { get; set; }
        /// <summary>
        /// 商品返利率
        /// </summary>
        public string BackRate { get; set; }
        /// <summary>
        /// 淘宝订单编号
        /// </summary>
        public string Code { get; set; }

        public static List<OrderInfo> FromDataTable(DataTable dtBackData) {
            var orderList = new List<OrderInfo>();
            dtBackData.DefaultView.Sort = "创建时间 asc"; //按日期升序排序
            DataTable dtSort = dtBackData.DefaultView.ToTable();
            //查询出想要的订单
            DataRow[] rows = dtSort.Select("订单状态 = '已付款' or 订单状态 = '已收货' or 订单状态 = '已结算' or 订单状态='已失效'");
            foreach (DataRow dr in rows)
            {
                OrderInfo order = new OrderInfo();
                order.Code = dr["淘宝订单编号"].ToString();
                order.BackPrice = Convert.ToDouble(dr["付款预估收入"]);
                order.BackRate = dr["佣金比率"].ToString();
                order.BuyDate = Convert.ToDateTime(dr["付款时间"]);
                order.ClickTime = Convert.ToDateTime(dr["点击时间"]);
                order.ItemCount = Convert.ToInt16(dr["商品数量"]);
                order.ItemName = dr["商品标题"].ToString();
                order.ItemPrice = Convert.ToDouble(dr["商品单价"]);
                order.ItemId = dr["商品ID"].ToString();
                order.PayPrice = Convert.ToDouble(dr["付款金额"]);
                order.ShopName = dr["店铺名称"].ToString();
                Enum.TryParse(dr["订单状态"].ToString(), out OrderState state);
                order.State = state;
                order.Type = OrderType.Import;
                order.CheckDate = DateTime.Now;

                orderList.Add(order);           
            }
            return orderList;
        }
    }

    /// <summary>
    /// 订单录入类型
    /// </summary>
    public enum OrderType
    {
        Import,
        Manual
    }

    public enum OrderState
    {
        已付款,
        已收货,
        已结算,
        已失效
    }
}
