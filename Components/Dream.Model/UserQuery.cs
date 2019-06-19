using System;
using System.Collections.Generic;
using System.Text;

namespace Dream.Model
{
    public class UserQuery : BaseQuery
    {
        public int? ID { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public int? Enable { get; set; }
        /// <summary>
        /// 多个角色逗号分隔  eg: 1,2,3
        /// </summary>
        public string Role { get; set; }
        public string Name { get; set; }
        public string CreateTime { get; set; }
    }
}
