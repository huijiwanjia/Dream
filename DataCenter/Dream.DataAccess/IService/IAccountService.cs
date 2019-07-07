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
    public interface IAccountService
    {
        Task<UserInfo> Login(UserInfo user);
        Task<UserInfo> Regist(UserInfo user);

        Task RecordRecomment(string unionId, int pId);
    }
}
