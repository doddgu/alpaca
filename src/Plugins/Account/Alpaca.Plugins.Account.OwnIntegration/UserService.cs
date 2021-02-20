using Alpaca.Data.EFCore;
using Alpaca.Data.Entities;
using Alpaca.Infrastructure.Caching;
using Alpaca.Infrastructure.Enums;
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
        private static MemoryCache<int, UserModel> _mcUser = new MemoryCache<int, UserModel>();
        private static MemoryCache<int, List<UserPermissionModel>> _mcUserPermission = new MemoryCache<int, List<UserPermissionModel>>();

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
                var mapperUserPermission = new MapperWrapper<UserPermissionModel, UserPermission>();

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

        public void UpsertUser(UserModel user)
        {
            _mcUser.AddOrUpdate(user.ID, id => user);
        }

        public void DeleteUser(int userID)
        {
            _mcUser.Remove(userID);
        }

        public void AddUserPermission(UserPermissionModel userPermissionModel)
        {
            _mcUserPermission.Get(userPermissionModel.UserID, out var lstUserPermission);

            lstUserPermission = lstUserPermission ?? new List<UserPermissionModel>();

            lstUserPermission.Add(userPermissionModel);

            _mcUserPermission.AddOrUpdate(userPermissionModel.ID, id => lstUserPermission);
        }

        public void DeleteUserPermission(int userID, int userPermissionID)
        {
            _mcUserPermission.Get(userID, out var lstUserPermission);

            lstUserPermission = lstUserPermission ?? new List<UserPermissionModel>();

            lstUserPermission.RemoveAll(up => up.ID == userPermissionID);

            _mcUserPermission.AddOrUpdate(userID, id => lstUserPermission);
        }
    }
}
