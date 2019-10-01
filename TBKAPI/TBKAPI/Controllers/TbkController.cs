using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;

namespace TBKAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TbkController : ApiController
    {
        private static string _tbkApiUrl = "https://eco.taobao.com/router/rest";
        private static string _appkey = "26005994";
        private static string _secret = "7f8eb75441e1b5917a8dafe3b89bd285";
        private static string _format = "json";
        private static long _adzoneId = 79264527L;
        [HttpPost]
        public IHttpActionResult Post(TbkDgMaterialOptionalRequest req) {
            ITopClient client = new DefaultTopClient(_tbkApiUrl, _appkey, _secret, _format);
            req.AdzoneId = _adzoneId;
            TbkDgMaterialOptionalResponse rsp = client.Execute(req);
            return Json(rsp.Body);
        }
        /// <summary>
        /// 淘口令转换
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("TPWDCreate")]
        public IHttpActionResult TPWDCreate(TbkTpwdCreateRequest req)
        {
            ITopClient client = new DefaultTopClient(_tbkApiUrl, _appkey, _secret, _format);
            TbkTpwdCreateResponse rsp = client.Execute(req);
            return Json(rsp.Body);
        }
        /// <summary>
        /// 淘抢购
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("TQGGet")]
        public IHttpActionResult TQGGet(TbkJuTqgGetRequest req)
        {
            ITopClient client = new DefaultTopClient(_tbkApiUrl, _appkey, _secret, _format);
            req.AdzoneId = _adzoneId;
            req.Fields = "click_url,pic_url,reserve_price,zk_final_price,total_amount,sold_num,title,category_name,start_time,end_time";
            TbkJuTqgGetResponse rsp = client.Execute(req);
            return Json(rsp.Body);
        }
        /// <summary>
        /// 选品库商品信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("FavoritesItemGet")]
        public IHttpActionResult FavoritesItemGet(TbkUatmFavoritesItemGetRequest req)
        {
            ITopClient client = new DefaultTopClient(_tbkApiUrl, _appkey, _secret, _format);
            req.AdzoneId = _adzoneId;
            TbkUatmFavoritesItemGetResponse rsp = client.Execute(req);
            return Json(rsp.Body);
        }
        /// <summary>
        /// 选品库信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("FavoritesGet")]
        public IHttpActionResult FavoritesGet(TbkUatmFavoritesGetRequest req)
        {
            ITopClient client = new DefaultTopClient(_tbkApiUrl, _appkey, _secret, _format);
            TbkUatmFavoritesGetResponse rsp = client.Execute(req);
            return Json(rsp.Body);
        }
        /// <summary>
        /// 商品精选
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/OptimusGet")]
        public IHttpActionResult OptimusGet(TbkDgOptimusMaterialRequest req)
        {
            ITopClient client = new DefaultTopClient(_tbkApiUrl, _appkey, _secret, _format);
            req.AdzoneId = _adzoneId;
            TbkDgOptimusMaterialResponse rsp = client.Execute(req);
            return Json(rsp.Body);
        }
        
    }
}
