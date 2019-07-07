using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dream.Security;
using Dream.Security.LoginUtil;
using Dream.Admin.Models;

namespace Dream.Admin.Controllers
{
    public class ControlController : Controller
    {

        // GET: Home
        public ActionResult Page()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }
    }
}