using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// TbkActivitylinkGetResponse.
    /// </summary>
    public class TbkActivitylinkGetResponse : TopResponse
    {
        /// <summary>
        /// bizErrorCode
        /// </summary>
        [XmlElement("biz_error_code")]
        public long BizErrorCode { get; set; }

        /// <summary>
        /// bizErrorDesc
        /// </summary>
        [XmlElement("biz_error_desc")]
        public string BizErrorDesc { get; set; }

        /// <summary>
        /// 淘宝联盟官方活动推广URL
        /// </summary>
        [XmlElement("data")]
        public string Data { get; set; }

        /// <summary>
        /// resultCode
        /// </summary>
        [XmlElement("result_code")]
        public long ResultCode { get; set; }

        /// <summary>
        /// resultMsg
        /// </summary>
        [XmlElement("result_msg")]
        public string ResultMsg { get; set; }

    }
}
