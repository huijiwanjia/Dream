using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Dream.Model.Enums;

namespace Dream.Model
{
    [Table("Profit")]
    public class Profit
    {
        [Key]
        public int ProfitId { get; set; }
        public double Amount { get; set; }
        public ProfitType Type { get; set; }
        public DateTime CreateTime { get; set; }
        public string Remark { get; set; }
        public ProfitStatus Status { get; set; }

        public int? UserId { get; set; }

    }
}
