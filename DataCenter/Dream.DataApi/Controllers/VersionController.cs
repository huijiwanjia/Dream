using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dream.DataAccess.IService;
using Dream.Logger;
using Dream.Model;
using Dream.Model.Api;
using Dream.Security;

namespace Dream.DataApi.Controllers
{
    public class VersionController : BaseController
    {
        [HttpGet]
        public string Index()
        {
            return "1.0";
        }

        [HttpGet]
        [Route("Android")]
        public string Android()
        {
            return "1.0";
        }

        [HttpGet]
        [Route("IsCheck")]
        public int  IsCheck()
        {
            return 0;
        }
    }
}
