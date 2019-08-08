using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.tbk.content.effect.get
    /// </summary>
    public class TbkContentEffectGetRequest : BaseTopRequest<Top.Api.Response.TbkContentEffectGetResponse>
    {
        /// <summary>
        /// 入参
        /// </summary>
        public string Option { get; set; }

        public ContentEffectPageOptionDomain Option_ { set { this.Option = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.tbk.content.effect.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("option", this.Option);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
        }

	/// <summary>
/// ContentEffectPageOptionDomain Data Structure.
/// </summary>
[Serializable]

public class ContentEffectPageOptionDomain : TopObject
{
	        /// <summary>
	        /// 内容id，如不指定则不做为筛选条件
	        /// </summary>
	        [XmlElement("content_id")]
	        public string ContentId { get; set; }
	
	        /// <summary>
	        /// 页码从1开始
	        /// </summary>
	        [XmlElement("page_no")]
	        public Nullable<long> PageNo { get; set; }
	
	        /// <summary>
	        /// 页数，最大1000
	        /// </summary>
	        [XmlElement("page_size")]
	        public Nullable<long> PageSize { get; set; }
	
	        /// <summary>
	        /// 如若不传则不做为筛选条件
	        /// </summary>
	        [XmlElement("pid")]
	        public string Pid { get; set; }
	
	        /// <summary>
	        /// 选择效果日期，如果不传即按日期倒序排
	        /// </summary>
	        [XmlElement("time")]
	        public string Time { get; set; }
}

        #endregion
    }
}
