using System;
using System.Collections.Generic;
using System.Text;

namespace Dream.Model
{
    public class ApiResult<T> where T : class
    {
        /// <summary>
        /// 接口调用状态0：成功, 1: 失败
        /// </summary>
        public ApiResultStatus Code { get; set; }
        /// <summary>
        /// 总条数
        /// </summary>
        public int? TotalCount { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// 描述（如,异常信息等）
        /// </summary>
        public ApiResultDescription Description { get; set; }
    }


    public enum ApiResultStatus
    {
        Success,
        Failed
    }
    public class ApiResultDescription
    {
        public string ErrorInfo { get; set; }
        public string OtherInfo { get; set; }
    }
}
