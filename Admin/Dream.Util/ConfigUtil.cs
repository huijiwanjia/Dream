using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Dream.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Dream.Util.Cache;

namespace Dream.Util
{
    public class ConfigUtil
    {
        private const String CacheKeyConfig = "Key_CacheKeyConfig";
        private const String CacheKeyArgs = "0";
        public static T GetConfig<T>(string key) where T : class, new()
        {
            T retValue = new T();
            var models = MemoryCacheUtil.Get<T>(CacheKeyConfig, nameof(retValue));
            if (models == null)
            {
                var config = new ConfigurationBuilder()
                                  .AddInMemoryCollection()
                                  .SetBasePath(Directory.GetCurrentDirectory())
                                  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                  .Build();
                retValue = new ServiceCollection()
                           .AddOptions()
                           .Configure<T>(config.GetSection(key))
                           .BuildServiceProvider()
                           .GetService<IOptions<T>>()
                           .Value;
                MemoryCacheUtil.Set(CacheKeyConfig, retValue, TimeSpan.FromDays(30));
            }
            else
            {
                retValue = models;
            }
            return retValue;
        }
        public static List<Rewrite> GetURLRewriteConfig()
        {
            List<Rewrite> listR = new List<Rewrite>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Directory.GetCurrentDirectory() + @"/Config/RewriteRules.config");
            //取指定的结点的集合
            XmlNodeList nodeList = xmlDoc.SelectNodes("rewriter/rewrite");
            foreach (XmlNode node in nodeList)
            {
                if (node != null) listR.Add(new Rewrite { to = node.Attributes["to"].Value, url = node.Attributes["url"].Value });
            }
            return listR;
        }
    }
}
