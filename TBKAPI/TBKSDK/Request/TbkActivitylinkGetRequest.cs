using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.tbk.activitylink.get
    /// </summary>
    public class TbkActivitylinkGetRequest : BaseTopRequest<Top.Api.Response.TbkActivitylinkGetResponse>
    {
        /// <summary>
        /// 推广位id，mm_xx_xx_xx pid三段式中的第三段。adzone_id需属于appKey拥有者
        /// </summary>
        public Nullable<long> AdzoneId { get; set; }

        /// <summary>
        /// 1：PC，2：无线，默认：１
        /// </summary>
        public Nullable<long> Platform { get; set; }

        /// <summary>
        /// 官方活动ID，从官方活动页获取
        /// </summary>
        public Nullable<long> PromotionSceneId { get; set; }

        /// <summary>
        /// 渠道关系ID，仅适用于渠道推广场景
        /// </summary>
        public string RelationId { get; set; }

        /// <summary>
        /// 媒体平台下达人的淘客pid
        /// </summary>
        public string SubPid { get; set; }

        /// <summary>
        /// 自定义输入串，英文和数字组成，长度不能大于12个字符，区分不同的推广渠道
        /// </summary>
        public string UnionId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.tbk.activitylink.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("adzone_id", this.AdzoneId);
            parameters.Add("platform", this.Platform);
            parameters.Add("promotion_scene_id", this.PromotionSceneId);
            parameters.Add("relation_id", this.RelationId);
            parameters.Add("sub_pid", this.SubPid);
            parameters.Add("union_id", this.UnionId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("adzone_id", this.AdzoneId);
            RequestValidator.ValidateRequired("promotion_scene_id", this.PromotionSceneId);
        }

        #endregion
    }
}
