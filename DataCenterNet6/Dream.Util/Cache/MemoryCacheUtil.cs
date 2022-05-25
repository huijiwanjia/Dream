using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dream.Util.Cache
{
    public class MemoryCacheUtil
    {
        private static MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        public static void Set(string key, object value, TimeSpan ts)
        {
            object aa = _cache.Set(key, value, ts);
        }

        public static T Get<T>(string key, string param)
        {
            key = string.Format(key, param);
            T retValue = _cache.Get<T>(key);
            return retValue;
        }
    }
}
