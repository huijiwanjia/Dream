using Dapper.Contrib.Extensions;
using Dream.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Dream.Model
{
    [Table("Withdraw")]
    public class Withdraw
    {
        [Key]
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime ApplyTime { get; set; }
        public int UserId { get; set; }
        public WithdrawStatus Status { get; set; }
    }
}
