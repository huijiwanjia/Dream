using Dream.Logger;
using Dream.Model;
using Dream.Model.Api;
using Dream.Model.Admin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dream.Model.Enums;

namespace Dream.DataAccess.IService
{
    public interface IProfitService
    {
        Task<IEnumerable<Profit>> GetUserProfits(int userId);
        Task<double> GetRemainAmountAsync(int userId);
        Task WithdrawApplyAsync(int userId);
    }
}
