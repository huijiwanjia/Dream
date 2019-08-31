using Dream.Model.Enums;
using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using System.Text;

namespace Dream.Model
{
    public class TeamInfo
    {
        public IEnumerable<UserInfo> TeamMember { get; set; }
        public int TotalCount { get; set; }
        public int? DirectlyCount { get; set; }
    }
}
