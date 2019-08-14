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
using Dream.DataAccess.Service;

namespace Dream.DataApi.Controllers
{
    public class UserController : BaseController
    {
        private IUserService _userService;
        private ILog _log;
        public UserController(IUserService u, ILog l)
        {
            _userService = u;
            _log = l;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(JqTableParams param)
        {
            try
            {
                var pagedData = await _userService.QueryPaginationData(param);
                return Ok(pagedData);
            }
            catch (Exception ex)
            {
                _log.Error($"获取分页数据失败：{ex.ToString()}");
                return BadRequest();
            }
        }

    }
}
