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

        [HttpGet]
        public IActionResult Get(object requestItems)
        {
            return Ok("dream");
        }
        [HttpPost]
        public Task<IActionResult> Post(string subject, string totalAmount)
        {
            return null;
            //try
            //{
            //    IAopClient client = new DefaultAopClient(SCEnvironment.AlipayServerUrl, SCEnvironment.AlipayAppId, SCEnvironment.AlipayPrivateKey, "json", "1.0", "RSA2", SCEnvironment.AlipayPublicKey, SCEnvironment.AlipayCharset, false);
            //    //实例化具体API对应的request类,类名称和接口名称对应,当前调用接口名称如：alipay.trade.app.pay
            //    AlipayTradeAppPayRequest request = new AlipayTradeAppPayRequest();
            //    //SDK已经封装掉了公共参数，这里只需要传入业务参数。以下方法为sdk的model入参方式(model和biz_content同时存在的情况下取biz_content)。
            //    AlipayTradeAppPayModel model = new AlipayTradeAppPayModel();
            //    model.Body = "共享人脉支付";
            //    model.Subject = subject;
            //    model.TotalAmount = totalAmount;
            //    model.ProductCode = "QUICK_MSECURITY_PAY";
            //    model.OutTradeNo = CreatePrimaryKey.Current.ID.ToString();
            //    model.TimeoutExpress = "30m";
            //    request.SetBizModel(model);
            //    request.SetNotifyUrl("http://sc.handsave.com/api/alipay/");
            //    //这里和普通的接口调用不同，使用的是sdkExecute
            //    AlipayTradeAppPayResponse response = client.SdkExecute(request);
            //    return Ok(response.Body);
            //}
            //catch (Exception ex)
            //{
            //    Trace.TraceError($"AlipayController::GeneratePayInfo: {ex.Message}");
            //    return InternalServerError();
            //}
        }
    }
}
