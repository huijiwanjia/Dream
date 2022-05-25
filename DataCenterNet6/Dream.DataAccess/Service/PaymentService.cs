using Dream.Logger;
using Dream.Model.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using Dream.DataAccess.IService;
using Dream.Model;
using System.Linq;
using Dream.Model.Admin;
using Dapper.Contrib.Extensions;
using Dream.Model.Enums;
using Alipay.AopSdk.Core.Request;
using Alipay.AopSdk.Core;
using Dream.Util;
using Alipay.AopSdk.Core.Domain;
using Alipay.AopSdk.Core.Response;

namespace Dream.DataAccess.Service
{
    public class PaymentService : IPaymentService
    {
        public string GeneratePayInfo(string subject, string totalAmount)
        {
            var config = ConfigUtil.GetConfig<DataApiAppSettings>("AppSettings");
            IAopClient client = new DefaultAopClient(config.AlipayServer, config.AlipayAppId, config.AlipayPrivateKey, "json", "1.0", "RSA2", config.AlipayPublicKey, "UTF-8", false);
            //实例化具体API对应的request类,类名称和接口名称对应,当前调用接口名称如：alipay.trade.app.pay
            AlipayTradeAppPayRequest request = new AlipayTradeAppPayRequest();
            //SDK已经封装掉了公共参数，这里只需要传入业务参数。以下方法为sdk的model入参方式(model和biz_content同时存在的情况下取biz_content)。
            AlipayTradeAppPayModel model = new AlipayTradeAppPayModel();
            model.Body = "惠及万家支付";
            model.Subject = subject;
            model.TotalAmount = totalAmount;
            model.ProductCode = "QUICK_MSECURITY_PAY";
            model.OutTradeNo = PrimaryKey.Current.ID.ToString();
            model.TimeoutExpress = "30m";
            request.SetBizModel(model);
            request.SetNotifyUrl(config.AlipayNotifyUrl);
            //这里和普通的接口调用不同，使用的是sdkExecute
            AlipayTradeAppPayResponse response = client.SdkExecute(request);
            return response.Body;
        }
    }
}
