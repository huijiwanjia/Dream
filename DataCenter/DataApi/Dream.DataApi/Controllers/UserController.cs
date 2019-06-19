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
    [Route("pcs/[controller]")]
    public class UserController : BaseController
    {
        private ILog _log;
        private IUserService _UserService;

        public UserController(ILog log, IUserService u)
        {
            _log = log;
            _UserService = u;
        }

        [HttpGet]
        //[ApiAuthorize]
        public async Task<IActionResult> Get(UserQuery userQuery)
        {
            var ret = await _UserService.Query(userQuery);
            return Json(ret);
        }

        [HttpPost]
        public void Post([FromBody]UserInfo userInfo)
        {
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
