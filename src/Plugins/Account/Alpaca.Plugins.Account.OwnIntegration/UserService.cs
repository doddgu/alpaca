using Alpaca.Data.EFCore;
using Alpaca.Data.Entities;
using Alpaca.Infrastructure.Caching;
using Alpaca.Infrastructure.Mapping;
using Alpaca.Interfaces.Account;
using Alpaca.Interfaces.Account.Models;
using System;
using System.Linq;

namespace Alpaca.Plugins.Account.OwnIntegration
{
    public class UserService : IUserService
    {
        private static MemoryCache<int, UserModel> _mcUser = new MemoryCache<int, UserModel>();

        static UserService()
        {
            using (var dbContext = ADbContext.Create())
            {
                var lstUser = dbContext.User.Where(u => !u.IsDeleted).ToList();
                var mapper = new MapperWrapper<UserModel, User>();

                lstUser.ForEach(u =>
                {
                    _mcUser.TryAdd(u.ID, id => mapper.GetModel(u));
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
    }
}
