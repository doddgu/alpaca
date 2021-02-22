using Alpaca.Data.EFCore;
using Alpaca.Data.Entities;
using Microsoft.Extensions.DependencyInjection;
using Alpaca.Infrastructure.Mapping;
using Alpaca.Interfaces.Account;
using Alpaca.Interfaces.Account.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alpaca.Plugins.Account.OwnIntegration
{
    public class UserService : IUserService
    {
        private static UserMemoryCache _userMemoryCache = null;
        private static IServiceProvider _serviceProvider = null;

        public UserService(IServiceProvider serviceProvider)
        {
            if (_serviceProvider != null) return;

            _serviceProvider = serviceProvider;

            using var dbContext = _serviceProvider.GetService<ADbContext>();
            _userMemoryCache = new UserMemoryCache(dbContext);
        }

        public UserModel Get(int ID)
        {
            return _userMemoryCache.User.GetOrAdd(ID, id =>
            {
                using var dbContext = _serviceProvider.GetService<ADbContext>();

                var user = dbContext.User.FirstOrDefault(u => u.ID == id);
                var mapper = new MapperWrapper<UserModel, User>();

                return mapper.GetModel(user);
            });
        }

        public List<string> GetUserPermissionList(int userID)
        {
            if (_userMemoryCache.UserPermission.Get(userID, out var lstUserPermission))
            {
                return lstUserPermission.Select(up => up.PermissionCode).ToList();
            }
            else
            {
                return new List<string>();
            }
        }

        public void UpsertUser(UserModel user)
        {
            _userMemoryCache.User.AddOrUpdate(user.ID, id => user);
        }

        public void DeleteUser(int userID)
        {
            _userMemoryCache.User.Remove(userID);
        }

        public void AddUserPermission(UserPermissionModel userPermissionModel)
        {
            _userMemoryCache.UserPermission.Get(userPermissionModel.UserID, out var lstUserPermission);

            lstUserPermission = lstUserPermission ?? new List<UserPermissionModel>();

            lstUserPermission.Add(userPermissionModel);

            _userMemoryCache.UserPermission.AddOrUpdate(userPermissionModel.ID, id => lstUserPermission);
        }

        public void DeleteUserPermission(int userID, int userPermissionID)
        {
            _userMemoryCache.UserPermission.Get(userID, out var lstUserPermission);

            lstUserPermission = lstUserPermission ?? new List<UserPermissionModel>();

            lstUserPermission.RemoveAll(up => up.ID == userPermissionID);

            _userMemoryCache.UserPermission.AddOrUpdate(userID, id => lstUserPermission);
        }
    }
}
