using Dream.Logger;
using Dream.Model;
using Dream.Model.Api;
using Dream.Model.Admin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dream.DataAccess.IService
{
    public interface IClickLogService
    {
        Task InsertLogAsync(ClickLog log);
        Task<ClickLog> QueryAsync(DateTime clickTime, string itemId);
    }
}
