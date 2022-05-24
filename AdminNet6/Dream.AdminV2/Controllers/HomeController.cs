﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dream.Admin.Models;

namespace Dream.Admin.Controllers
{
    public class HomeController : AuthController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
