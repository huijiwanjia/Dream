using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream.Security
{
    public class Provider
    {
        private static readonly string _desKey = "pcs_safe";
        private static TimeSpan _expireTime = TimeSpan.FromMinutes(10);//十分钟过期
        private static readonly string _pcsKey = "e5a193b1-0560-11e8-b1b7-7cd30ab8a58e";

        public static string PCSKEY { get { return _pcsKey; } }
        public static TimeSpan ExpireTime { get { return _expireTime; } set { _expireTime = value; } }

        public static string Encrypt(string key)
        {
            string timespan = TimeConvert.GetCurrentUTCTimeSpan();
            string mixedKey = $"{timespan}&{key}&{_desKey}";
            return DESProvider.Encrypt(mixedKey, _desKey);
        }

        public static bool KeyIsAvailable(string key)
        {
            try
            {
                var mixedKey = DESProvider.Decrypt(key, _desKey);
                var parameters = mixedKey.Split('&');
                var keyTime = TimeConvert.TimeSpanToUTCDateTime(parameters[0]);
                if ((DateTime.UtcNow - keyTime) > _expireTime || parameters[1] != _pcsKey || parameters[2] != _desKey) return false;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
