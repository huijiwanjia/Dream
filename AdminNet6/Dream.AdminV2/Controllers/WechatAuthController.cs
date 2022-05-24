using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dream.Security;
using Dream.Security.LoginUtil;
using Dream.Admin.Models;
using System.Net;
using System.IO;
using System.Text;
using Dream.Logger;

namespace SC.Admin.Controllers
{
    public class WechatAuthController : Controller
    {

        private ILog _logger;
        public WechatAuthController(ILog l)
        {
            _logger = l;
        }
        // GET: WechatAuth
        public ActionResult AuthCallback(string code, string state)
        {
            _logger.Info($"Code: {code}, state: {state}");
            ViewBag.State = state;
            string apiUrl = "https://api.weixin.qq.com/sns/oauth2/access_token?appid=wxda337f3186c93879&secret=26fb5076ed7e8317e93b478208f8c045&code=" + code + "&grant_type=authorization_code";
            ViewBag.Token = GetInfo(apiUrl);
            return View();
        }

        //用作验证接入
        //[HttpGet]
        //public ActionResult AuthCallback(string signature, string timestamp, string nonce, string echostr)
        //{
        //    return Content(echostr);
        //}

        private string GetInfo(string Url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Proxy = null;
            request.KeepAlive = false;
            request.Method = "GET";
            request.ContentType = "application/json; charset=UTF-8";
            request.AutomaticDecompression = DecompressionMethods.GZip;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();

            myStreamReader.Close();
            myResponseStream.Close();

            if (response != null)
            {
                response.Close();
            }
            if (request != null)
            {
                request.Abort();
            }

            return retString;
        }
    }
}