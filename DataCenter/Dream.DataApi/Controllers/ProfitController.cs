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
using Dream.Model.Enums;

namespace Dream.DataApi.Controllers
{
    public class ProfitController : BaseController
    {
        private ILog _log;
        private IProfitService _profitService;

        public ProfitController(ILog log, IProfitService p)
        {
            _log = log;
            _profitService = p;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(int userId)
        {
            try
            {
                var profits = await _profitService.GetUserProfits(userId);
                return Ok(profits);
            }
            catch (Exception ex)
            {
                _log.Error($"获取用户【{userId}】收益信息失败：{ex.ToString()}");
                return BadRequest();
            }
        }

        #region Withdraw Apply


        [HttpGet]
        [Route("GetRemainAmount")]
        public async Task<IActionResult> GetRemainAmount(int userId)
        {
            try
            {
                return Ok(await _profitService.GetRemainAmountAsync(userId));
            }
            catch (Exception ex)
            {
                _log.Error($"ProfitController::GetRemainAmount: {ex.Message}");
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("WithdrawApply")]
        public async Task<IActionResult> WithdrawApply(int userId)
        {
            try
            {
                await _profitService.WithdrawApplyAsync(userId);
                return Ok();
            }
            catch (Exception ex)
            {
                _log.Error($"ProfitController::WithdrawApply: {ex.Message}");
                return BadRequest();
            }
        }

        #endregion
    }
}
