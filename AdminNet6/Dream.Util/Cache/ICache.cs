using System;
using System.Collections.Generic;
using System.Text;

namespace Dream.Util.Cache
{
    public interface ICache
    {
        void Set(string key, object value, TimeSpan expireTime);
        T Get<T>(string key);
    }
}
