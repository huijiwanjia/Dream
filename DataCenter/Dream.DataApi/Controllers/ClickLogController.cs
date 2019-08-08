using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dream.DataAccess.IService;
using Dream.Logger;
using Dream.Model;
using Dream.Model.Api;
using Dream.Security;
using Newtonsoft.Json;

namespace Dream.DataApi.Controllers
{
    public class ClickLogController : BaseController
    {
        private ILog _log;
        private IClickLogService _clickLogService;

        public ClickLogController(ILog log, IClickLogService c)
        {
            _log = log;
            _clickLogService = c;
        }

        [HttpPost]
        //[ApiAuthorize]
        public async Task<IActionResult> Post([FromBody]ClickLog log)
        {
            try
            {
                _log.Info($"[ClickLogController]点击日志：{JsonConvert.SerializeObject(log)}");
                await _clickLogService.InsertLogAsync(log);
                return Ok("request success");
            }
            catch (Exception ex)
            {
                _log.Error($"[ClickLogController]点击日志记录失败，错误信息：{ex.Message}");
                return BadRequest("request failed");
            }
        }
    }
}
