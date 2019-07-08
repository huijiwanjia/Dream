using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dream.DataAccess.IService;
using Dream.Logger;
using Dream.Model;
using Dream.Model.Api;
using Dream.Model.Admin;
using Dream.Security;
using Newtonsoft.Json;

namespace Dream.DataApi.Controllers
{
    public class AuthController : BaseController
    {
        private ILog _log;
        private IAccountService _accountService;

        public AuthController(ILog log, IAccountService a)
        {
            _log = log;
            _accountService = a;
        }

        [HttpGet]
        //[ApiAuthorize]
        public string Get()
        {
            return "1";
        }

        [HttpPost]
        //[ApiAuthorize]
        public async Task<IActionResult> Post([FromBody]UserInfo user)
        {
            try
            {
                _log.Info($"[AuthController]登陆用户信息：{JsonConvert.SerializeObject(user)}");
                var authedUser = await _accountService.Login(user);
                return Ok(authedUser);
            }
            catch (Exception ex)
            {
                _log.Error($"[AuthController]登陆失败，错误信息：{ex.Message}");
                return BadRequest("登陆失败");
            }
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
