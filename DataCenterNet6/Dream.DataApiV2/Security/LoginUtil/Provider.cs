using Dream.Model.Admin;
using Dream.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Dream.Model;

namespace Dream.Security.LoginUtil
{
    public class LoginProvider
    {
        private static readonly string _desKey = "pcs_auth";
        private static TimeSpan _expireTime = TimeSpan.FromDays(ConfigUtil.GetConfig<AdminAppSettings>("AppSettings").AuthExpireTime);

        public static string Encrypt(string key)
        {
            string timespan = TimeConvert.GetCurrentUTCTimeSpan();
            string mixedKey = $"{timespan}&{key}&{_desKey}";
            return DESProvider.Encrypt(mixedKey, _desKey);
        }

        public static bool IsAuthed(string key, out UserInfo userInfo)
        {
            userInfo = null;
            try
            {
                var mixedKey = DESProvider.Decrypt(key, _desKey);
                var parameters = mixedKey.Split('&');
                var keyTime = TimeConvert.TimeSpanToUTCDateTime(parameters[0]);
                if ((DateTime.UtcNow - keyTime) > _expireTime || parameters[2] != _desKey)
                {
                    return false;
                }
                userInfo = JsonConvert.DeserializeObject<UserInfo>(parameters[1]);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
