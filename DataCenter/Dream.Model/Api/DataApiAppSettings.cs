using System;
using System.Collections.Generic;
using System.Text;

namespace Dream.Model.Api
{
    /// <summary>
    /// 配置文件
    /// </summary>
    public class DataApiAppSettings
    {
        public string DreamConnectionString { get; set; }
        public string AlipayServer { get; set; }
        public string AlipayAppId { get; set; }
        public string AlipayPrivateKey { get; set; }
        public string AlipayPublicKey { get; set; }
        public string AlipayNotifyUrl { get; set; }
        public double OrderBackRate { get; set; }
        public double OrderProfitUserBackRate { get; set; }
        public int RecommentNumberToTeamMember { get; set; }

    }
}
