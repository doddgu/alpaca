using Alpaca.Data.EFCore;
using Alpaca.Data.Entities;
using Alpaca.Infrastructure.Caching;
using Alpaca.Infrastructure.Mapping;
using Alpaca.Interfaces.Account.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Plugins.Account.OwnIntegration
{
    public class UserMemoryCache
    {
        internal MemoryCache<int, UserModel> User { get; } = new MemoryCache<int, UserModel>();
        internal MemoryCache<int, List<UserPermissionModel>> UserPermission { get; } = new MemoryCache<int, List<UserPermissionModel>>();

        public UserMemoryCache(ADbContext dbContext)
        {
            var lstUser = dbContext.User.Where(u => !u.IsDeleted).ToList();
            var mapperUser = new MapperWrapper<UserModel, User>();

            lstUser.ForEach(u =>
            {
                User.TryAdd(u.ID, id => mapperUser.GetModel(u));
            });

            var lstUserPermission = dbContext.UserPermission.Where(u => !u.IsDeleted).ToList();
            var mapperUserPermission = new MapperWrapper<UserPermissionModel, UserPermission>();

            lstUserPermission.GroupBy(up => up.UserID).ToList().ForEach(gup =>
            {
                UserPermission.TryAdd(gup.Key, k => mapperUserPermission.GetModelList(gup.ToList()));
            });
        }
    }
}
