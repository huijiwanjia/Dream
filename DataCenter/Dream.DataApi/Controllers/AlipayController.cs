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

namespace Dream.DataApi.Controllers
{
    public class AlipayController : BaseController
    {

        private IPaymentService _paymentService;
        private ILog _log;
        public AlipayController(IPaymentService p, ILog l)
        {
            _paymentService = p;
            _log = l;
        }

        [HttpGet]
        public IActionResult Get(object requestItems)
        {
            return Ok("dream");
        }

        [HttpPost]
        public IActionResult Post(string subject, string totalAmount)
        {
            try
            {
                return Ok(_paymentService.GeneratePayInfo(subject, totalAmount));
            }
            catch (Exception ex)
            {
                _log.Error($"生成支付信息失败：{ex.Message}");
                return BadRequest();
            }
        }
    }
}
