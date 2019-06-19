using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Dream.Logger;
using System.Net.Http.Headers;
using System.IO;
using Dream.Security;
using Dream.Model.Api;
using Dream.FileServer.Util;

namespace Dream.FileServer.Controllers
{
    public class HomeController : BaseController
    {
       
        [HttpGet]
        public string Index()
        {
            return "pcs file server";
        }
    }
}
