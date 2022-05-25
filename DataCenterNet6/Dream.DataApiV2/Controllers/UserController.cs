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

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetAsync(int userId)
        {
            try
            {
                var userViewModel = await _userService.GetViewModelByUserIdAsync(userId);
                return Ok(userViewModel);
            }
            catch (Exception ex)
            {
                _log.Error($"UserController::GetAsync: {ex.Message}");
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetTeamById")]
        public async Task<IActionResult> GetTeamByIdAsync(int userId)
        {
            try
            {
                var team = await _userService.GetTeamByIdAsync(userId);
                return Ok(team);
            }
            catch (Exception ex)
            {
                _log.Error($"UserController::GetAsync: {ex.Message}");
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserAsync([FromBody]UserInfo userInfo)
        {
            try
            {
                var updatedUser = await _userService.UpdateUserAsync(userInfo);
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                _log.Error($"UserController::UpdateUserInfo: {ex.Message}");
                return BadRequest();
            }
        }
    }
}
