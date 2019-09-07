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

        [HttpGet]
        [Route("QueryWithdraw")]
        public async Task<IActionResult> QueryWithdraw(Withdraw withdraw)
        {
            try
            {
                var withdrawRet = await _profitService.QueryWithdraw(withdraw);
                return Json(withdrawRet);
            }
            catch (Exception ex)
            {
                _log.Error($"获取用户【{withdraw.UserId}】提现申请数据失败：{ex.ToString()}");
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddProfits(Profit profit)
        {
            try
            {
                await _profitService.AddProfits(profit);
                return Ok();
            }
            catch (Exception ex)
            {
                _log.Error($"ProfitController::AddProfits: 添加用户受益失败：{ex.ToString()}");
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetWithdrawApply")]
        public async Task<IActionResult> GetWithdrawApply(JqTableParams param)
        {
            try
            {
                var pagedData = await _profitService.QueryWithdrawData(param);
                return Ok(pagedData);
            }
            catch (Exception ex)
            {
                _log.Error($"获取分页数据失败：{ex.ToString()}");
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("ChangeStatus")]
        public ActionResult ChangeWithdrawStatus(int id, WithdrawStatus state)
        {
            try
            {
                if (_profitService.ChangeWithdrawStatus(id, state)) return Ok("success");
                else return Ok("failed");
            }
            catch (Exception ex)
            {
                _log.Error($"修改状态失败：{ex.ToString()}");
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
