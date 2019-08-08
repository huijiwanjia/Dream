using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;

namespace TBKAPI.Controllers
{
    public class TbkController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post(TbkDgMaterialOptionalRequest req) {

            var url = "https://eco.taobao.com/router/rest";
            var appkey = "26005994";
            var secret = "7f8eb75441e1b5917a8dafe3b89bd285";
            var format = "json";
            ITopClient client = new DefaultTopClient(url, appkey, secret, format);
            req.AdzoneId = 79264527L;
            TbkDgMaterialOptionalResponse rsp = client.Execute(req);
            return Json(rsp.Body);
        }
    }
}
