using Dream.Model.Admin;
using Dream.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Dream.Admin.AppCode
{
    public class UrlBuilder
    {
        public static String BuildJsCssUrl(string file, bool debug = false)
        {
            if (!debug) return string.Concat(ConfigUtil.GetConfig<AdminAppSettings>("AppSettings").StaticServer, file);
            return file;
        }
        public static string BuildFileUrl(FileType type, string patentID)
        {
            return Path.Combine(ConfigUtil.GetConfig<AdminAppSettings>("AppSettings").FileServer, type.ToString().ToUpper(), patentID);
        }
    }

    public enum FileType
    {
        PDF,
        TIF
    }
}
