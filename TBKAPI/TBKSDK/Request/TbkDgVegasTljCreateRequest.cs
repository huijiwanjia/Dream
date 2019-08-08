using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.tbk.dg.vegas.tlj.create
    /// </summary>
    public class TbkDgVegasTljCreateRequest : BaseTopRequest<Top.Api.Response.TbkDgVegasTljCreateResponse>
    {
        /// <summary>
        /// 妈妈广告位Id
        /// </summary>
        public Nullable<long> AdzoneId { get; set; }

        /// <summary>
        /// CPS佣金计划类型
        /// </summary>
        public string CampaignType { get; set; }

        /// <summary>
        /// 宝贝id
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        /// <summary>
        /// 淘礼金名称，最大10个字符
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 单个淘礼金面额，支持两位小数，单位元
        /// </summary>
        public string PerFace { get; set; }

        /// <summary>
        /// 安全开关
        /// </summary>
        public Nullable<bool> SecuritySwitch { get; set; }

        /// <summary>
        /// 发放截止时间
        /// </summary>
        public Nullable<DateTime> SendEndTime { get; set; }

        /// <summary>
        /// 发放开始时间
        /// </summary>
        public Nullable<DateTime> SendStartTime { get; set; }

        /// <summary>
        /// 淘礼金总个数
        /// </summary>
        public Nullable<long> TotalNum { get; set; }

        /// <summary>
        /// 使用结束日期。如果是结束时间模式为相对时间，时间格式为1-7直接的整数, 例如，1（相对领取时间1天）； 如果是绝对时间，格式为yyyy-MM-dd，例如，2019-01-29，表示到2019-01-29 23:59:59结束
        /// </summary>
        public string UseEndTime { get; set; }

        /// <summary>
        /// 结束日期的模式,1:相对时间，2:绝对时间
        /// </summary>
        public Nullable<long> UseEndTimeMode { get; set; }

        /// <summary>
        /// 使用开始日期。相对时间，无需填写，以用户领取时间作为使用开始时间。绝对时间，格式 yyyy-MM-dd，例如，2019-01-29，表示从2019-01-29 00:00:00 开始
        /// </summary>
        public string UseStartTime { get; set; }

        /// <summary>
        /// 单用户累计中奖次数上限
        /// </summary>
        public Nullable<long> UserTotalWinNumLimit { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.tbk.dg.vegas.tlj.create";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("adzone_id", this.AdzoneId);
            parameters.Add("campaign_type", this.CampaignType);
            parameters.Add("item_id", this.ItemId);
            parameters.Add("name", this.Name);
            parameters.Add("per_face", this.PerFace);
            parameters.Add("security_switch", this.SecuritySwitch);
            parameters.Add("send_end_time", this.SendEndTime);
            parameters.Add("send_start_time", this.SendStartTime);
            parameters.Add("total_num", this.TotalNum);
            parameters.Add("use_end_time", this.UseEndTime);
            parameters.Add("use_end_time_mode", this.UseEndTimeMode);
            parameters.Add("use_start_time", this.UseStartTime);
            parameters.Add("user_total_win_num_limit", this.UserTotalWinNumLimit);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("adzone_id", this.AdzoneId);
            RequestValidator.ValidateRequired("item_id", this.ItemId);
            RequestValidator.ValidateRequired("name", this.Name);
            RequestValidator.ValidateRequired("per_face", this.PerFace);
            RequestValidator.ValidateRequired("security_switch", this.SecuritySwitch);
            RequestValidator.ValidateRequired("send_start_time", this.SendStartTime);
            RequestValidator.ValidateRequired("total_num", this.TotalNum);
            RequestValidator.ValidateRequired("user_total_win_num_limit", this.UserTotalWinNumLimit);
        }

        #endregion
    }
}
