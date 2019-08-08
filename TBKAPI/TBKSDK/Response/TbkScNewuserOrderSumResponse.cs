using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// TbkScNewuserOrderSumResponse.
    /// </summary>
    public class TbkScNewuserOrderSumResponse : TopResponse
    {
        /// <summary>
        /// data
        /// </summary>
        [XmlElement("results")]
        public DataDomain Results { get; set; }

	/// <summary>
/// DataDomain Data Structure.
/// </summary>
[Serializable]

public class DataDomain : TopObject
{
	        /// <summary>
	        /// 活动ID，2月活动ID：119013_2
	        /// </summary>
	        [XmlElement("activity_id")]
	        public string ActivityId { get; set; }
	
	        /// <summary>
	        /// 首购用户数
	        /// </summary>
	        [XmlElement("alipay_user_cnt")]
	        public long AlipayUserCnt { get; set; }
	
	        /// <summary>
	        /// 结算CPA 奖励金额：仅支持member 维度的统计
	        /// </summary>
	        [XmlElement("alipay_user_cpa_pre_amt")]
	        public string AlipayUserCpaPreAmt { get; set; }
	
	        /// <summary>
	        /// 当日激活且首购结算的CPA 金额：仅适用于八天乐，仅支持member维度的统计
	        /// </summary>
	        [XmlElement("bind_buy_user_cpa_pre_amt")]
	        public string BindBuyUserCpaPreAmt { get; set; }
	
	        /// <summary>
	        /// 当日激活且首购的有效用户数：仅适用于八天乐，支持member，adzone维度的统计
	        /// </summary>
	        [XmlElement("bind_buy_valid_user_cnt")]
	        public long BindBuyValidUserCnt { get; set; }
	
	        /// <summary>
	        /// bindCardValidUserCnt
	        /// </summary>
	        [XmlElement("bind_card_valid_user_cnt")]
	        public long BindCardValidUserCnt { get; set; }
	
	        /// <summary>
	        /// 日期
	        /// </summary>
	        [XmlElement("biz_date")]
	        public string BizDate { get; set; }
	
	        /// <summary>
	        /// 新激活用户数
	        /// </summary>
	        [XmlElement("login_user_cnt")]
	        public long LoginUserCnt { get; set; }
	
	        /// <summary>
	        /// 确认收货用户数
	        /// </summary>
	        [XmlElement("rcv_user_cnt")]
	        public long RcvUserCnt { get; set; }
	
	        /// <summary>
	        /// 结算有效用户数
	        /// </summary>
	        [XmlElement("rcv_valid_user_cnt")]
	        public long RcvValidUserCnt { get; set; }
	
	        /// <summary>
	        /// reBuyValidUserCnt
	        /// </summary>
	        [XmlElement("re_buy_valid_user_cnt")]
	        public long ReBuyValidUserCnt { get; set; }
	
	        /// <summary>
	        /// 新注册用户数
	        /// </summary>
	        [XmlElement("reg_user_cnt")]
	        public long RegUserCnt { get; set; }
	
	        /// <summary>
	        /// 渠道关系id
	        /// </summary>
	        [XmlElement("relation_id")]
	        public string RelationId { get; set; }
	
	        /// <summary>
	        /// validNum
	        /// </summary>
	        [XmlElement("valid_num")]
	        public long ValidNum { get; set; }
}

    }
}
