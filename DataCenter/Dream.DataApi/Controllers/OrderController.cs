﻿using System;
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

    }
}
