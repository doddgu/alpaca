using Alpaca.Data.EFCore;
using Alpaca.Data.Entities;
using Alpaca.Infrastructure.Mapping;
using Alpaca.Interfaces.Account;
using Alpaca.Model.Account.UserPermissionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Biz.Account
{
    public class UserPermissionBiz
    {
        private ADbContext _dbContext = null;
        private IUserService _userService = null;

        public UserPermissionBiz(ADbContext dbContext, IUserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        public List<UserPermissionViewModel> GetList(int userID)
        {
            var lstEntity = _dbContext.UserPermission.Where(up => up.UserID == userID && !up.IsDeleted).OrderByDescending(up => up.UpdateTime).ToList();

            var lstModel = new MapperWrapper<UserPermissionViewModel, UserPermission>().GetModelList(lstEntity);

            return lstModel;
        }

        public GetUserPermissionViewModel Get(int ID)
        {
            var entity = _dbContext.UserPermission.Single(up => up.ID == ID);

            var model = new MapperWrapper<GetUserPermissionViewModel, UserPermission>().GetModel(entity);

            return model;
        }

        public GetUserPermissionViewModel Add(AddUserPermissionViewModel model, int userID)
        {
            var mapper = new MapperWrapper<GetUserPermissionViewModel, UserPermission>();

            var existsUserPermission = _dbContext.UserPermission.FirstOrDefault(up => up.UserID == model.UserID && up.PermissionCode == model.PermissionCode && up.AppID == model.AppID && !up.IsDeleted);
            if (existsUserPermission != null)
            {
                return mapper.GetModel(existsUserPermission);
            }

            var entity = new MapperWrapper<AddUserPermissionViewModel, UserPermission>().GetEntity(model);

            _dbContext.Add<UserPermission, int>(entity, userID);

            _userService.Refresh();

            return mapper.GetModel(entity);
        }

        public GetUserPermissionViewModel Update(UpdateUserPermissionViewModel model, int userID)
        {
            var mapper = new MapperWrapper<GetUserPermissionViewModel, UserPermission>();

            var existsUserPermission = _dbContext.UserPermission.FirstOrDefault(up => up.UserID == model.UserID && up.PermissionCode == model.PermissionCode && up.AppID == model.AppID && up.ID != model.ID && !up.IsDeleted);
            if (existsUserPermission != null)
            {
                return mapper.GetModel(existsUserPermission);
            }

            var entity = new MapperWrapper<UpdateUserPermissionViewModel, UserPermission>().GetEntity(model);

            _dbContext.Update<UserPermission, int>(entity, userID);

            _userService.Refresh();

            return new MapperWrapper<GetUserPermissionViewModel, UserPermission>().GetModel(entity);
        }

        public void Delete(int ID, int userID)
        {
            var entity = _dbContext.UserPermission.SingleOrDefault(u => u.ID == ID && !u.IsDeleted);

            _dbContext.Delete<UserPermission, int>(entity, userID);

            _userService.Refresh();
        }
    }
}
