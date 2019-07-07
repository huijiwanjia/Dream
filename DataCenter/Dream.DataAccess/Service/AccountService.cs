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
            var userFound = await _userService.QueryAsync(user.OpenId);
            return userFound == null ? await Regist(user) : userFound;

        }
        public async Task<UserInfo> Regist(UserInfo user)
        {
            if (user == null) return null;
            using (IDbConnection conn = DBConnection.CreateConnection())
            {
                conn.Open();
                var recoment = await _recommentService.QueryAsync(user.UnionId);
                user.PId = recoment.PId;
                user.AccountStatus = 0;
                user.AgencyType = AgencyType.NotAgency;
                user.CreateTime = DateTime.Now;
                user.UserId = await conn.InsertAsync<UserInfo>(user);
                return user;
            }
        }
        public async Task RecordRecomment(string unionId, int pId)
        {
            await Task.FromResult(0);
            //Recomment recomment = new Recomment();
            //using (var context = SCContext.NewInstance)
            //{
            //    if (context.SCUsers.Where(u => u.UnionId == unionId).FirstOrDefault() != null) return;
            //    if (context.Recomments.Where(r => r.Unionid == unionId).FirstOrDefault() != null) return;
            //    recomment.Unionid = unionId;
            //    recomment.PId = pId;
            //    context.Recomments.Add(recomment);
            //    context.SaveChanges();
            //}
        }
    }
}
