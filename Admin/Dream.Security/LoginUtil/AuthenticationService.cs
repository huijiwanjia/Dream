using Newtonsoft.Json;
using Dream.Model.Admin;
using Dream.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Dream.Model;

namespace Dream.Security.LoginUtil
{
    public class AuthenticationService : IAuthenticationService
    {
        private static string _authCookieName = ConfigUtil.GetConfig<AdminAppSettings>("AppSettings").AuthCookieName;
        private static int _expireTime = ConfigUtil.GetConfig<AdminAppSettings>("AppSettings").AuthExpireTime;
        private readonly UserInfo _user;
        public UserInfo User => _user;
        public AuthenticationService() {
            _user = GetUserInfo();
        }

        public async Task<UserInfo> Login(string account, string password)
        {
            var apiUrl = $"{ConfigUtil.GetConfig<AdminAppSettings>("AppSettings").DataServer}/pcs/user?account={account}&password={password}&enable=1";
            var ret = await RequestUtil.DoRequestWithBytesPostDataAsync(apiUrl, "GET", "application/json", 60 * 1000, 60 * 60 * 1000, null);
            var uResponse = JsonConvert.DeserializeObject<ApiResult<List<UserInfo>>>(ret);

            if (uResponse?.Code == ApiResultStatus.Success && uResponse?.Data?.Count > 0)
            {
                var userInfo = uResponse?.Data?.FirstOrDefault();
                var authCookieValue = LoginProvider.Encrypt(JsonConvert.SerializeObject(userInfo));
                HttpUtityHelper.Current.Response.Cookies.Append(_authCookieName, authCookieValue, new CookieOptions { Path = "/", Expires = DateTime.Now.AddYears(_expireTime) });
                return userInfo;
            }
            return null;
        }
        public bool IsLogin()
        {
            HttpUtityHelper.Current.Request.Cookies.TryGetValue(_authCookieName, out string authKey);
            if (!string.IsNullOrWhiteSpace(authKey)) return LoginProvider.IsAuthed(authKey, out UserInfo userInfo);
            return false;
        }
        public void LoginOut()
        {
            HttpUtityHelper.Current.Response.Cookies.Delete(_authCookieName);
        }
        public UserInfo GetUserInfo()
        {
            var authKey = HttpUtityHelper.Current.Request.Cookies[_authCookieName];
            LoginProvider.IsAuthed(authKey, out UserInfo userInfo);
            return userInfo;
        }
        public List<UserInfo> GetUsers() {
            List<UserInfo> list = new List<UserInfo>();

            return list;
        }
    }
}
