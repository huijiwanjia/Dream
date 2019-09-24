using Dream.Logger;
using Dream.Model.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using Dream.DataAccess.IService;
using Dream.Model;
using System.Linq;
using Dream.Model.Admin;
using Dapper.Contrib.Extensions;
using Dream.Model.Enums;
using Dream.Util;

namespace Dream.DataAccess.IService
{
    public class AccountService : IAccountService
    {
        private IUserService _userService;
        private IRecommentService _recommentService;
        public AccountService(IUserService u, IRecommentService r)
        {
            _userService = u;
            _recommentService = r;
        }
        public async Task<UserInfo> Login(UserInfo user)
        {
            var userFound = await _userService.QueryAsync(user.UnionId);
            return userFound == null ? await Regist(user) : userFound;

        }
        public async Task<UserInfo> Regist(UserInfo user)
        {
            if (user == null) return null;
            using (IDbConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                var recoment = await _recommentService.QueryAsync(user.UnionId);
                if (recoment != null)
                {
                    //检查推荐人是否达到合伙人资格
                    var team = await _userService.GetTeamByIdAsync(recoment.PId);
                    if (ConfigUtil.GetConfig<DataApiAppSettings>("AppSettings").RecommentNumberToTeamMember == team.TeamMember?.Count() + 1)
                        user.Type = UserType.TeamMember;
                    else user.Type = UserType.Commom;
                }
                user.PId = recoment?.PId;
                user.AccountStatus = 0;
                user.CreateTime = DateTime.Now;
                user.UserId = await conn.InsertAsync<UserInfo>(user);
                return user;
            }
        }
    }
}
