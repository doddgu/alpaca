using Alpaca.Data.EFCore;
using Alpaca.Data.Entities;
using Alpaca.Infrastructure.Caching;
using Alpaca.Infrastructure.Enums;
using Alpaca.Infrastructure.Mapping;
using Alpaca.Interfaces.Account;
using Alpaca.Interfaces.Account.Models;
using Alpaca.Model.Account.UserPermissionModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alpaca.Plugins.Account.OwnIntegration
{
    public class UserService : IUserService
    {
        private static MemoryCache<int, UserModel> _mcUser = new MemoryCache<int, UserModel>();
        private static MemoryCache<int, List<UserPermissionViewModel>> _mcUserPermission = new MemoryCache<int, List<UserPermissionViewModel>>();

        static UserService()
        {
            using (var dbContext = ADbContext.Create())
            {
                var lstUser = dbContext.User.Where(u => !u.IsDeleted).ToList();
                var mapperUser = new MapperWrapper<UserModel, User>();

                lstUser.ForEach(u =>
                {
                    _mcUser.TryAdd(u.ID, id => mapperUser.GetModel(u));
                });

                var lstUserPermission = dbContext.UserPermission.Where(u => !u.IsDeleted).ToList();
                var mapperUserPermission = new MapperWrapper<UserPermissionViewModel, UserPermission>();

                lstUserPermission.GroupBy(up => up.UserID).ToList().ForEach(gup =>
                {
                    _mcUserPermission.TryAdd(gup.Key, k => mapperUserPermission.GetModelList(gup.ToList()));
                });
            }
        }

        public UserModel Get(int ID)
        {
            return _mcUser.GetOrAdd(ID, id =>
            {
                using (var dbContext = ADbContext.Create())
                {
                    var user = dbContext.User.FirstOrDefault(u => u.ID == id);
                    var mapper = new MapperWrapper<UserModel, User>();

                    return mapper.GetModel(user);
                }
            });
        }

        public List<string> GetUserPermissionList(int userID)
        {
            if (_mcUserPermission.Get(userID, out var lstUserPermission))
            {
                return lstUserPermission.Select(up => up.PermissionCode).ToList();
            }
            else
            {
                return new List<string>();
            }
        }
    }
}
