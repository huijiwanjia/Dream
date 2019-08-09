using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// TbkDgVegasTljCreateResponse.
    /// </summary>
    public class TbkDgVegasTljCreateResponse : TopResponse
    {
        /// <summary>
        /// result
        /// </summary>
        [XmlElement("result")]
        public ResultDomain Result { get; set; }

	/// <summary>
/// RightsInstanceCreateResultDomain Data Structure.
/// </summary>
[Serializable]

public class RightsInstanceCreateResultDomain : TopObject
{
	        /// <summary>
	        /// 淘礼金Id
	        /// </summary>
	        [XmlElement("rights_id")]
	        public string RightsId { get; set; }
	
	        /// <summary>
	        /// 淘礼金领取Url
	        /// </summary>
	        [XmlElement("send_url")]
	        public string SendUrl { get; set; }
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
	        public RightsInstanceCreateResultDomain Model { get; set; }
	
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
