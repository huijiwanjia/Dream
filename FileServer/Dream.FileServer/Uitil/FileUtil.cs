using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dream.Util;
using Dream.Model.Api;

namespace Dream.FileServer.Util
{
    public class FileUtil
    {
        public static string FileRootFolder { get => Path.Combine(ConfigUtil.GetConfig<FileServerAppSettings>("AppSettings").FileRootPath); }
        public static void Init()
        {
            if (!Directory.Exists(FileRootFolder))
                Directory.CreateDirectory(FileRootFolder);
        }

        public static FileStream GetFileStream(string url)
        {
            string fileLocation = Path.Combine(FileRootFolder, url);
            var stream = new FileStream(fileLocation, FileMode.Open, FileAccess.Read);
            return stream;
        }

        public static async Task<byte[]> GetFileBytesAsyc(string url)
        {
            string fileLocation = Path.Combine(FileRootFolder, url);
            var bytes = await File.ReadAllBytesAsync(fileLocation);
            return bytes;
        }

        public static async Task<string> GetFileStringAsyc(string url)
        {
            string fileLocation = Path.Combine(FileRootFolder, url);
            var fileStr = await File.ReadAllTextAsync(fileLocation);
            return fileStr;
        }
        public static void DeleteFile(string url)
        {
            string fileLocation = Path.Combine(FileRootFolder, url);
            File.Delete(fileLocation);
        }
    }
}
