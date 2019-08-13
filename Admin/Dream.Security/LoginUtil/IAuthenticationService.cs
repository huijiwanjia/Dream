using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dream.Model;
using Dream.Model.Admin;

namespace Dream.Security.LoginUtil
{
    public interface IAuthenticationService
    {
        Task<UserInfo> Login(string account, string password);
        bool IsLogin();
        void LoginOut();
        UserInfo GetUserInfo();
        UserInfo User { get; }
        List<UserInfo> GetUsers();
    }
}
