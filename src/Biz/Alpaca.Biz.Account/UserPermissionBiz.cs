using Alpaca.Data.EFCore;
using Alpaca.Data.Entities;
using Alpaca.Infrastructure.Mapping;
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
        public List<UserPermissionViewModel> GetList(int userID)
        {
            using (var dbContext = ADbContext.Create())
            {
                var lstEntity = dbContext.UserPermission.Where(up => up.UserID == userID && !up.IsDeleted).OrderByDescending(up => up.UpdateTime).ToList();

                var lstModel = new MapperWrapper<UserPermissionViewModel, UserPermission>().GetModelList(lstEntity);

                return lstModel;
            }
        }

        public GetUserPermissionViewModel Get(int ID)
        {
            using (var dbContext = ADbContext.Create())
            {
                var entity = dbContext.UserPermission.Single(up => up.ID == ID);

                var model = new MapperWrapper<GetUserPermissionViewModel, UserPermission>().GetModel(entity);

                return model;
            }
        }

        public GetUserPermissionViewModel Add(AddUserPermissionViewModel model, int userID)
        {
            using (var dbContext = ADbContext.Create())
            {
                var mapper = new MapperWrapper<GetUserPermissionViewModel, UserPermission>();

                var existsUserPermission = dbContext.UserPermission.FirstOrDefault(up => up.UserID == model.UserID && up.PermissionCode == model.PermissionCode && up.AppID == model.AppID && !up.IsDeleted);
                if (existsUserPermission != null)
                {
                    return mapper.GetModel(existsUserPermission);
                }

                var entity = new MapperWrapper<AddUserPermissionViewModel, UserPermission>().GetEntity(model);

                dbContext.Add<UserPermission, int>(entity, userID);

                return mapper.GetModel(entity);
            }
        }

        public GetUserPermissionViewModel Update(UpdateUserPermissionViewModel model, int userID)
        {
            using (var dbContext = ADbContext.Create())
            {
                var mapper = new MapperWrapper<GetUserPermissionViewModel, UserPermission>();

                var existsUserPermission = dbContext.UserPermission.FirstOrDefault(up => up.UserID == model.UserID && up.PermissionCode == model.PermissionCode && up.AppID == model.AppID && up.ID != model.ID && !up.IsDeleted);
                if (existsUserPermission != null)
                {
                    return mapper.GetModel(existsUserPermission);
                }

                var entity = new MapperWrapper<UpdateUserPermissionViewModel, UserPermission>().GetEntity(model);

                dbContext.Update<UserPermission, int>(entity, userID);

                return new MapperWrapper<GetUserPermissionViewModel, UserPermission>().GetModel(entity);
            }
        }

        public void Delete(int ID, int userID)
        {
            using (var dbContext = ADbContext.Create())
            {
                var entity = dbContext.UserPermission.SingleOrDefault(u => u.ID == ID && !u.IsDeleted);

                dbContext.Delete<UserPermission, int>(entity, userID);

                dbContext.SaveChanges();
            }
        }
    }
}
