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

namespace Dream.DataApi.Controllers
{
    [Route("dream/[controller]")]
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
        public void Get(UserInfo user)
        {

        }

        [HttpPost]
        //[ApiAuthorize]
        public async Task<IActionResult> Post([FromBody]UserInfo user)
        {
            var authedUser = await _accountService.Login(user);
            return Ok(authedUser);
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
