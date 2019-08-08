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
        [HttpGet]
        public IHttpActionResult Get(string q) {

            var url = "https://eco.taobao.com/router/rest";
            var appkey = "26005994";
            var secret = "7f8eb75441e1b5917a8dafe3b89bd285";
            ITopClient client = new DefaultTopClient(url, appkey, secret);
            TbkItemGetRequest req = new TbkItemGetRequest();
            req.Fields = "num_iid,title,pict_url,small_images,reserve_price,zk_final_price,user_type,provcity,item_url,seller_id,volume,nick";
            req.Q = q;
            //req.Cat = "16,18";
            //req.Itemloc = "杭州";
            //req.Sort = "tk_rate_des";
            //req.IsTmall = false;
            //req.IsOverseas = false;
            //req.StartPrice = 10L;
            //req.EndPrice = 10L;
            //req.StartTkRate = 123L;
            //req.EndTkRate = 123L;
            req.Platform = 2L;
            req.PageNo = 1L;
            req.PageSize = 200L;
            TbkItemGetResponse rsp = client.Execute(req);
            return Ok(rsp.Body);
        }
    }
}
