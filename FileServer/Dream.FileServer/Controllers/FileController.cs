using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Dream.Logger;
using System.Net.Http.Headers;
using System.IO;
using Dream.Security;
using Dream.Model.Api;
using Dream.FileServer.Util;
using Dream.Model;

namespace Dream.FileServer.Controllers
{
    [Route("pcs/[controller]")]
    public class FileController : BaseController
    {
        private ILog _log;

        public FileController(ILog log)
        {
            _log = log;
        }

        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "pcs file server";
        }

        [HttpGet("{type}/{name}")]
        public async Task<IActionResult> Get(string type, string name)
        {
            var relativePath = $"{type}/{name}.{type}";
            var fileName = $"{name}.{type}";
            var contentType = "application/octet-stream";
            _log.Info($"begin to request file: {relativePath}");
            var fileBytes = await FileUtil.GetFileBytesAsyc(relativePath);
            return File(fileBytes, contentType, fileName);
        }

        [HttpPost("{type}/{name}"), DisableRequestSizeLimit]
        [ApiAuthorize]
        public async Task<IActionResult> Post(string type, string name)
        {
            var ret = new ApiResult<string>();
            var file = Request.Form.Files[0];
            if (file.Length > 0)
            {
                var relativePath = $"{type}/{name}.{type}";
                _log.Info($"begin to save file: {relativePath}");
                var fullPath = Path.Combine(FileUtil.FileRootFolder, relativePath);
                var fileDirectory = Path.GetDirectoryName(fullPath);
                if (!Directory.Exists(fileDirectory)) Directory.CreateDirectory(fileDirectory);
                if (System.IO.File.Exists(fullPath)) System.IO.File.Delete(fullPath);
                using (var stream = new FileStream(fullPath, FileMode.Create)) await file.CopyToAsync(stream);
                ret.Code = ApiResultStatus.Success;
                ret.Data = $"save file: {relativePath} successful";
            }
            else
            {
                ret.Code = ApiResultStatus.Failed;
                ret.Description = new ApiResultDescription() { ErrorInfo = "can not find only file" };
            }
            return Json(ret);

        }

        [HttpDelete("{type}/{name}")]
        [ApiAuthorize]
        public IActionResult Delete(string type, string name)
        {
            var ret = new ApiResult<string>();
            var relativePath = $"{type}/{name}.{type}";
            _log.Info($"begin to delete file: {relativePath}");
            FileUtil.DeleteFile(relativePath);
            ret.Code = ApiResultStatus.Success;
            ret.Data = $"delete file: {relativePath} successful";
            return Json(ret);
        }
    }
}
