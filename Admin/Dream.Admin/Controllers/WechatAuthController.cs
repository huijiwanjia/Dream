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

namespace SC.Admin.Controllers
{
    public class WechatAuthController : Controller
    {
        // GET: WechatAuth
        //public ActionResult AuthCallback(string code, string state)
        //{
        //    ViewBag.State = state;
        //    string apiUrl = "https://api.weixin.qq.com/sns/oauth2/access_token?appid=wx457087c6f3e2d3be&secret=fae0a7e5a5c6e480f7e50c7cca4988b2&code=" + code + "&grant_type=authorization_code";
        //    ViewBag.Token = GetInfo(apiUrl);
        //    return View();
        //}
        [HttpGet]
        public ActionResult AuthCallback(string signature, string timestamp, string nonce, string echostr)
        {
            return Content(echostr);
        }

        public string GetInfo(string Url)
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