using System;
using System.Collections.Generic;
using System.Text;

namespace Dream.Model.Admin
{
    /// <summary>
    /// 配置文件
    /// </summary>
    public class AdminAppSettings
    {
        /// <summary>
        /// redis服务器
        /// </summary>
        public string RedisServer { get; set; }
        /// <summary>
        /// 静态资源服务器
        /// </summary>
        public string StaticServer { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 数据服务器
        /// </summary>
        public string DataServer { get; set; }
        /// <summary>
        /// 文件服务器
        /// </summary>
        public string FileServer { get; set; }
        /// <summary>
        /// 登录cookie名
        /// </summary>
        public string AuthCookieName { get; set; }
        /// <summary>
        /// 登录过期时间： 天
        /// </summary>
        public int AuthExpireTime { get; set; }
    }
}
