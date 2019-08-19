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
    public class OrderController : BaseController
    {
        private ILog _log;
        private IOrderService _orderService;

        public OrderController(ILog log, IOrderService o)
        {
            _log = log;
            _orderService = o;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(JqTableParams param)
        {
            try
            {
                var pagedData = await _orderService.QueryPaginationData(param);
                return Ok(pagedData);
            }
            catch (Exception ex)
            {
                _log.Error($"获取分页数据失败：{ex.ToString()}");
                return BadRequest();
            }
        }

        /// <summary>
        /// 改变返利状态
        /// </summary>
        /// <param name="projectCode">项目编号</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChangeOrderStatus(int projectId, int currentStatu)
        {
            try
            {
                string returnMsg = _orderService.ChangeOrderStatus(projectId, currentStatu);
                return Json(returnMsg);
            }
            catch (Exception ex)
            {
                _log.Error($"获取分页数据失败：{ex.ToString()}");
                return BadRequest();
            }
        }

        //[HttpPost]
        ////[ApiAuthorize]
        //public async Task<IActionResult> Post([FromBody]OrderInfo order)
        //{
        //    try
        //    {
        //        _log.Info($"[OrderController]订单核对，订单信息：{JsonConvert.SerializeObject(order)}");
        //        await _orderService.UserOrderCheckAndMappingAsync(order);
        //        return Ok("order check success");
        //    }
        //    catch (Exception ex)
        //    {
        //        _log.Error($"[OrderController]订单核对失败，错误信息：{ex.ToString()}");
        //        return BadRequest("order check failed");
        //    }
        //}

        //[HttpGet]
        ////[ApiAuthorize]
        //public async Task<IActionResult> Get(int userId)
        //{
        //    try
        //    {
        //        var orders = await _orderService.GetUserOrders(userId);
        //        return Json(orders);
        //    }
        //    catch (Exception ex)
        //    {
        //        _log.Error($"[OrderController]获取用户订单失败，错误信息：{ex.ToString()}");
        //        return BadRequest("get order failed");
        //    }
        //}
    }
}
