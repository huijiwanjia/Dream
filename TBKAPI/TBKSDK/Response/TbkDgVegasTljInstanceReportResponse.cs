using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// TbkDgVegasTljInstanceReportResponse.
    /// </summary>
    public class TbkDgVegasTljInstanceReportResponse : TopResponse
    {
        /// <summary>
        /// 接口返回model
        /// </summary>
        [XmlElement("result")]
        public ResultDomain Result { get; set; }

	/// <summary>
/// TljInstanceReportDtoDomain Data Structure.
/// </summary>
[Serializable]

public class TljInstanceReportDtoDomain : TopObject
{
	        /// <summary>
	        /// 引导成交金额
	        /// </summary>
	        [XmlElement("alipay_amount")]
	        public string AlipayAmount { get; set; }
	
	        /// <summary>
	        /// 引导预估佣金金额
	        /// </summary>
	        [XmlElement("pre_commission_amount")]
	        public string PreCommissionAmount { get; set; }
	
	        /// <summary>
	        /// 失效回退金额
	        /// </summary>
	        [XmlElement("refund_amount")]
	        public string RefundAmount { get; set; }
	
	        /// <summary>
	        /// 失效回退红包个数
	        /// </summary>
	        [XmlElement("refund_num")]
	        public long RefundNum { get; set; }
	
	        /// <summary>
	        /// 解冻金额
	        /// </summary>
	        [XmlElement("unfreeze_amount")]
	        public string UnfreezeAmount { get; set; }
	
	        /// <summary>
	        /// 解冻红包个数
	        /// </summary>
	        [XmlElement("unfreeze_num")]
	        public long UnfreezeNum { get; set; }
	
	        /// <summary>
	        /// 红包核销金额
	        /// </summary>
	        [XmlElement("use_amount")]
	        public string UseAmount { get; set; }
	
	        /// <summary>
	        /// 红包核销个数
	        /// </summary>
	        [XmlElement("use_num")]
	        public long UseNum { get; set; }
	
	        /// <summary>
	        /// 红包领取金额
	        /// </summary>
	        [XmlElement("win_amount")]
	        public string WinAmount { get; set; }
	
	        /// <summary>
	        /// 红包领取个数
	        /// </summary>
	        [XmlElement("win_num")]
	        public long WinNum { get; set; }
}

	/// <summary>
/// ResultDomain Data Structure.
/// </summary>
[Serializable]

public class ResultDomain : TopObject
{
	        /// <summary>
	        /// model
	        /// </summary>
	        [XmlElement("model")]
	        public TljInstanceReportDtoDomain Model { get; set; }
	
	        /// <summary>
	        /// msgCode
	        /// </summary>
	        [XmlElement("msg_code")]
	        public string MsgCode { get; set; }
	
	        /// <summary>
	        /// msgInfo
	        /// </summary>
	        [XmlElement("msg_info")]
	        public string MsgInfo { get; set; }
	
	        /// <summary>
	        /// 是否成功
	        /// </summary>
	        [XmlElement("success")]
	        public bool Success { get; set; }
}

    }
}
