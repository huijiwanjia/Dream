using Dapper.Contrib.Extensions;
using Dream.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dream.Model
{
    [Table("Recomment")]
    public class Recomment
    {
        [Key]
        public int RecommentId { get; set; }
        public string Unionid { get; set; }
        public int PId { get; set; }
    }
}
