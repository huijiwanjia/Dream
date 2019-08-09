﻿using Dream.Model.Enums;
using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using System.Text;

namespace Dream.Model
{
    [Table("Order")]
    public class Order
    {
        [Key]
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
        /// 提交日期
        /// </summary>
        public DateTime SubmitDate { get; set; }
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
        public DateTime BackDate { get; set; }
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
        public int State { get; set; }
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
        public int PayPrice { get; set; }
        /// <summary>
        /// 商品标题
        /// </summary>
        public int ItemName { get; set; }
        /// <summary>
        /// 商品数量
        /// </summary>
        public int ItemCount { get; set; }
        /// <summary>
        /// 商品返利率
        /// </summary>
        public int BackRate { get; set; }
        /// <summary>
        /// 淘宝订单编号
        /// </summary>
        public string Code { get; set; }
    }
}
