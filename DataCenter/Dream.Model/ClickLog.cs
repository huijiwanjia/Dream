using Dream.Model.Enums;
using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using System.Text;

namespace Dream.Model
{
    [Table("ClickLog")]
    public class ClickLog
    {
        [Key]
        public int Id { get; set; }
        public DateTime ClickTime { get; set; }
        public int UserId { get; set; }
        public string ItemId { get; set; }
    }
}
