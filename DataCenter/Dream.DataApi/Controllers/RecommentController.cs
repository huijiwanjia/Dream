using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dream.DataAccess.IService;
using Dream.Logger;
using Dream.Model;
using Dream.Model.Api;
using Dream.Model.Admin;
using Dream.Security;
using Newtonsoft.Json;
using Dream.DataAccess.Service;

namespace Dream.DataApi.Controllers
{
    public class RecommentController : BaseController
    {
        private IRecommentService _recommentService;
        private ILog _log;
        public RecommentController(IRecommentService r, ILog l)
        {
            _recommentService = r;
            _log = l;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Recomment recomment)
        {
            try
            {
                _log.Info($"RecommentController::Recomment info{JsonConvert.SerializeObject(recomment)}");
                await _recommentService.RecordAsync(recomment);
                return Ok();
            }
            catch (Exception ex)
            {
                _log.Error($"绑定推荐关系失败：{ex.ToString()}");
                return BadRequest();
            }
        }

    }
}
