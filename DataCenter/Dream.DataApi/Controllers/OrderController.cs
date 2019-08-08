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
    public class OrderController: BaseController
    {
        private ILog _log;
        private IOrderService _orderService;

        public OrderController(ILog log, IOrderService o)
        {
            _log = log;
            _orderService = o;
        }

        [HttpPost]
        //[ApiAuthorize]
        public async Task<IActionResult> Post([FromBody]Order order)
        {
            try
            {
                _log.Info($"[OrderController]订单核对，订单信息：{JsonConvert.SerializeObject(order)}");
                await _orderService.UserOrderCheckAndMappingAsync(order);
                return Ok("order check success");
            }
            catch (Exception ex)
            {
                _log.Error($"[OrderController]订单核对失败，错误信息：{ex.Message}");
                return BadRequest("order check failed");
            }
        }
    }
}
