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
    public class LoginController : Controller
    {
        private IAuthenticationService _authenticationService;
        public LoginController(IAuthenticationService a)
        {
            _authenticationService = a;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string account, string password)
        {
            //if (string.IsNullOrWhiteSpace(account)) return Ok("用户名不能为空");
            //if (string.IsNullOrWhiteSpace(password)) return Ok("密码不能为空");
            //var userInfo = await _authenticationService.Login(account, password);
            //if (userInfo != null) return Ok("success");
            //return Redirect("/login");
            return Redirect("/control/page");
        }

        public IActionResult LoginOut()
        {
            _authenticationService.LoginOut();
            return Redirect("/login");
        }
    }
}
