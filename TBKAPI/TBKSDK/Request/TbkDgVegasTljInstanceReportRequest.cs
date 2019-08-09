using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.tbk.dg.vegas.tlj.instance.report
    /// </summary>
    public class TbkDgVegasTljInstanceReportRequest : BaseTopRequest<Top.Api.Response.TbkDgVegasTljInstanceReportResponse>
    {
        /// <summary>
        /// 实例ID
        /// </summary>
        public string RightsId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.tbk.dg.vegas.tlj.instance.report";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("rights_id", this.RightsId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("rights_id", this.RightsId);
        }

        #endregion
    }
}
