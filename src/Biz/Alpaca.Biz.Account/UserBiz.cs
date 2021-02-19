using Alpaca.Data.EFCore;
using Alpaca.Data.Entities;
using Alpaca.Infrastructure.Enums;
using Alpaca.Infrastructure.Mapping;
using Alpaca.Infrastructure.Robust.Exceptions;
using Alpaca.Infrastructure.Security;
using Alpaca.Interfaces.Account;
using Alpaca.Model.Account;
using Alpaca.Model.Account.UserPermissionModels;
using System;
using System.Linq;

namespace Alpaca.Biz.Account
{
    public class UserBiz
    {
        private IUserService _userService = null;
        private ADbContext _dbContext = null;

        public UserBiz(ADbContext dbContext, IUserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        public UserViewModel GetByPassword(string userName, string password)
        {
            var entity = _dbContext.User.SingleOrDefault(u => u.Name == userName && !u.IsDeleted);

            if (entity == null && userName == "admin")
            {
                var admin = Add(new AddUserViewModel()
                {
                    Name = "admin",
                    NickName = "Admin",
                    Password = "admin",
                }, 0);

                var adminPermission = new UserPermissionBiz(_dbContext, _userService).Add(new AddUserPermissionViewModel()
                {
                    UserID = admin.ID,
                    PermissionCode = ((int)PermissionCode.Admin).ToString(),
                }, 0);

                _userService.Refresh();

                admin.AccessToken = TokenMaker.GetJWT(admin.ID, admin.Name, _userService.GetUserPermissionList(admin.ID));

                return admin;
            }

            if (entity == null)
                throw new AException(ErrorCode.UserNameNotExist);

            if (entity.Password != PasswordWrapper.Encrypt(password))
                throw new AException(ErrorCode.PasswordIncorrect);

            var user = new MapperWrapper<UserViewModel, User>().GetModel(entity);
            user.AccessToken = TokenMaker.GetJWT(entity.ID, entity.Name, _userService.GetUserPermissionList(entity.ID));

            return user;
        }

        public UserViewModel Add(AddUserViewModel model, int userID)
        {
            if (_dbContext.User.Any(u => u.Name == model.Name && !u.IsDeleted))
            {
                throw new AException(ErrorCode.UserNameExist);
            }

            var entity = new MapperWrapper<AddUserViewModel, User>().GetEntity(model);

            entity.Password = PasswordWrapper.Encrypt(model.Password);

            _dbContext.Add<User, int>(entity, userID);

            _userService.Refresh();

            return new MapperWrapper<UserViewModel, User>().GetModel(entity);
        }

        public void Delete(int userID)
        {
            var entity = _dbContext.User.SingleOrDefault(u => u.ID == userID && !u.IsDeleted);

            _dbContext.Delete<User, int>(entity, userID);

            _userService.Refresh();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        public UserViewModel UpdatePassword(int userID, string password)
        {

            password = PasswordWrapper.Encrypt(password);

            var entity = _dbContext.User.SingleOrDefault(u => u.ID == userID && !u.IsDeleted);
            if (entity == null)
            {
                return default(UserViewModel);
            }
            entity.Password = password;
            _dbContext.Update<User, int>(entity, userID);

            _userService.Refresh();

            return new MapperWrapper<UserViewModel, User>().GetModel(entity);
        }
    }
}
