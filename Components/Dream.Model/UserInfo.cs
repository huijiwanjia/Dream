using System;
using System.Collections.Generic;
using System.Text;

namespace Dream.Model
{
    public class UserInfo
    {
        public int ID { get; set; }
        public string Account { get; set; }
        public string Name { get; set; }
        public int Role { get; set; } 
        public int Enable { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
