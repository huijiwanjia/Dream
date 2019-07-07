using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Dream.Admin.Controllers
{
    public class ErrorController : Controller
    {
        [Route("error/404")]
        public IActionResult Error404()
        {
            return View();
        }
    }
}