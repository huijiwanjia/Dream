﻿using Dream.Model.Enums;
using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using System.Text;

namespace Dream.Model
{
    [Table("UserInfo")]
    public class UserInfo
    {
        [Key]
        public int UserId { get; set; }
        public string OpenId { get; set; }
        public string UnionId { get; set; }
        public string Name { get; set; }
        public string AliPay { get; set; }
        public string AliPayName { get; set; }
        public string Phone { get; set; }

        public DateTime CreateTime { get; set; }

        public Sex? Sex { get; set; }
        public string AvatarUrl { get; set; }

        public int? PId { get; set; }

        public AccountStatus? AccountStatus { get; set; }
        public UserType Type { get; set; }
    }
}
