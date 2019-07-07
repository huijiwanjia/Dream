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
    public class HomeController : BaseController
    {
       
        [HttpGet]
        public string Index()
        {
            return "dream!!!";
        }
    }
}
