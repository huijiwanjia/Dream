using System;
using System.Collections.Generic;
using System.Text;
using Dream.Model;
using Dream.Model.Admin;
using ServiceStack.Redis;

namespace Dream.Util.Cache
{
    public class RedisCache : ICache
    {
        private RedisManagerPool _redisManagerPool;
        public RedisCache()
        {
            var redisServer = ConfigUtil.GetConfig<AdminAppSettings>("AppSettings").RedisServer;
            _redisManagerPool = new RedisManagerPool(redisServer);
        }

        public void Set(string key, object value, TimeSpan expireIn)
        {
            using (var client = _redisManagerPool.GetClient())
            {
                client.Set(key, value, expireIn);
            }
        }

        public void Set(string key, object value, DateTime expirAt)
        {
            using (var client = _redisManagerPool.GetClient())
            {
                client.Set(key, value, expirAt);
            }
        }

        public T Get<T>(string key)
        {
            using (var client = _redisManagerPool.GetClient())
            {
                return client.Get<T>(key);
            }
        }
    }
}
