using Alpaca.Data.EFCore;
using Alpaca.Data.Entities;
using Alpaca.Infrastructure.Enums;
using Alpaca.Infrastructure.Mapping;
using Alpaca.Infrastructure.Robust.Exceptions;
using Alpaca.Interfaces.Account;
using Alpaca.Model.Config.ConfigAppModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alpaca.Biz.Config
{
    public class ConfigAppBiz
    {
        private IUserService _userServica = null;

        public ConfigAppBiz(IUserService userServica)
        {
            _userServica = userServica;
        }

        public List<ConfigAppViewModel> GetList()
        {
            using (var dbContext = ADbContext.Create())
            {
                var lstEntity = dbContext.ConfigApp.Where(ca => !ca.IsDeleted).OrderByDescending(ca => ca.UpdateTime).ToList();

                var lstModel = new MapperWrapper<ConfigAppViewModel, ConfigApp>().GetModelList(lstEntity);

                lstModel.ForEach(m =>
                {
                    m.UpdateUserName = _userServica.Get(m.UpdateUserID).NickName;
                });

                return lstModel;
            }
        }

        public GetConfigAppViewModel Get(int ID)
        {
            using (var dbContext = ADbContext.Create())
            {
                var entity = dbContext.ConfigApp.Single(ca => ca.ID == ID);

                var model = new MapperWrapper<GetConfigAppViewModel, ConfigApp>().GetModel(entity);

                return model;
            }
        }

        public GetConfigAppViewModel Add(AddConfigAppViewModel model, int userID)
        {
            using (var dbContext = ADbContext.Create())
            {
                if (dbContext.ConfigApp.Any(ca => ca.Name == model.Name && !ca.IsDeleted))
                {
                    throw new AException(ErrorCode.NameExist);
                }

                var entity = new MapperWrapper<AddConfigAppViewModel, ConfigApp>().GetEntity(model);

                dbContext.Add<ConfigApp, int>(entity, userID);

                return new MapperWrapper<GetConfigAppViewModel, ConfigApp>().GetModel(entity);
            }
        }

        public GetConfigAppViewModel Update(UpdateConfigAppViewModel model, int userID)
        {
            using (var dbContext = ADbContext.Create())
            {
                if (dbContext.ConfigApp.Any(ca => ca.Name == model.Name && ca.ID != model.ID && !ca.IsDeleted))
                {
                    throw new AException(ErrorCode.NameExist);
                }

                var entity = new MapperWrapper<UpdateConfigAppViewModel, ConfigApp>().GetEntity(model);

                dbContext.Update<ConfigApp, int>(entity, userID);

                return new MapperWrapper<GetConfigAppViewModel, ConfigApp>().GetModel(entity);
            }
        }

        public void Delete(int ID, int userID)
        {
            using (var dbContext = ADbContext.Create())
            {
                var entity = dbContext.ConfigApp.SingleOrDefault(u => u.ID == ID && !u.IsDeleted);

                dbContext.Delete<ConfigApp, int>(entity, userID);

                dbContext.SaveChanges();
            }
        }
    }
}
