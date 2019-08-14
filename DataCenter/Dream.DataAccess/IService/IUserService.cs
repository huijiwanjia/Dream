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
    public interface IUserService
    {
        Task<JqTableData<UserInfo>> QueryPaginationData(JqTableParams param);
        Task<UserInfo> QueryAsync(string unionId);
    }
}
