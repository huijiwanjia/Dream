using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// TbkContentEffectGetResponse.
    /// </summary>
    public class TbkContentEffectGetResponse : TopResponse
    {
        /// <summary>
        /// result
        /// </summary>
        [XmlElement("result")]
        public ResultDomain Result { get; set; }

	/// <summary>
/// ContenteffectlistDomain Data Structure.
/// </summary>
[Serializable]

public class ContenteffectlistDomain : TopObject
{
	        /// <summary>
	        /// 当日直接引导订单数
	        /// </summary>
	        [XmlElement("alipay_num")]
	        public long AlipayNum { get; set; }
	
	        /// <summary>
	        /// 内容id
	        /// </summary>
	        [XmlElement("content_id")]
	        public string ContentId { get; set; }
	
	        /// <summary>
	        /// cpcFee
	        /// </summary>
	        [XmlElement("cpc_fee")]
	        public string CpcFee { get; set; }
	
	        /// <summary>
	        /// cpsPreFee
	        /// </summary>
	        [XmlElement("cps_pre_fee")]
	        public string CpsPreFee { get; set; }
	
	        /// <summary>
	        /// cpsSettleFee
	        /// </summary>
	        [XmlElement("cps_settle_fee")]
	        public string CpsSettleFee { get; set; }
	
	        /// <summary>
	        /// 当日该内容下宝贝点击次数
	        /// </summary>
	        [XmlElement("ipv")]
	        public long Ipv { get; set; }
	
	        /// <summary>
	        /// 当日该内容下宝贝点击人数
	        /// </summary>
	        [XmlElement("iuv")]
	        public long Iuv { get; set; }
	
	        /// <summary>
	        /// 媒体pid
	        /// </summary>
	        [XmlElement("pid")]
	        public string Pid { get; set; }
	
	        /// <summary>
	        /// 时间
	        /// </summary>
	        [XmlElement("time")]
	        public string Time { get; set; }
}

	/// <summary>
/// ContentEffectPageDtoDomain Data Structure.
/// </summary>
[Serializable]

public class ContentEffectPageDtoDomain : TopObject
{
	        /// <summary>
	        /// contentEffectList
	        /// </summary>
	        [XmlArray("content_effect_list")]
	        [XmlArrayItem("contenteffectlist")]
	        public List<ContenteffectlistDomain> ContentEffectList { get; set; }
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
	        public ContentEffectPageDtoDomain Model { get; set; }
	
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
	        /// success
	        /// </summary>
	        [XmlElement("success")]
	        public bool Success { get; set; }
}

    }
}
