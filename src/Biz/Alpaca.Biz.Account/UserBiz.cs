using Alpaca.Data.EFCore;
using Alpaca.Data.Entities;
using Alpaca.Infrastructure.Enums;
using Alpaca.Infrastructure.Mapping;
using Alpaca.Infrastructure.Robust.Exceptions;
using Alpaca.Infrastructure.Security;
using Alpaca.Model.Account;
using System;
using System.Linq;

namespace Alpaca.Biz.Account
{
    public class UserBiz
    {
        public UserViewModel GetByPassword(string userName, string password)
        {
            using (var dbContext = ADbContext.Create())
            {
                var entity = dbContext.User.SingleOrDefault(u => u.Name == userName && !u.IsDeleted);

                if (entity == null)
                    throw new AException(ErrorCode.UserNameNotExist);

                if (entity.Password != PasswordWrapper.Encrypt(password))
                    throw new AException(ErrorCode.PasswordIncorrect);

                var user = new MapperWrapper<UserViewModel, User>().GetModel(entity);
                user.AccessToken = TokenMaker.GetJWT(entity.ID, entity.Name);

                return user;
            }
        }

        public UserViewModel Add(AddUserViewModel model, int userID)
        {
            var entity = new MapperWrapper<AddUserViewModel, User>().GetEntity(model);

            entity.CreateUserID = entity.UpdateUserID = userID;
            entity.Password = PasswordWrapper.Encrypt(model.Password);

            using (var dbContext = ADbContext.Create())
            {
                dbContext.Add(entity);

                dbContext.SaveChanges();
            }

            return new MapperWrapper<UserViewModel, User>().GetModel(entity);
        }
    }
}
