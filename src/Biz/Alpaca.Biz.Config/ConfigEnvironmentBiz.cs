using Alpaca.Data.EFCore;
using Alpaca.Data.Entities;
using Alpaca.Infrastructure.Enums;
using Alpaca.Infrastructure.Mapping;
using Alpaca.Infrastructure.Robust.Exceptions;
using Alpaca.Interfaces.Account;
using Alpaca.Model.Config.ConfigEnvironmentModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alpaca.Biz.Config
{
    public class ConfigEnvironmentBiz
    {
        private IUserService _userService = null;

        public ConfigEnvironmentBiz(IUserService userService)
        {
            _userService = userService;
        }

        public List<ConfigEnvironmentViewModel> GetList()
        {
            using (var dbContext = ADbContext.Create())
            {
                var lstEntity = dbContext.ConfigEnvironment.Where(ce => !ce.IsDeleted).ToList();

                var lstModel = new MapperWrapper<ConfigEnvironmentViewModel, ConfigEnvironment>().GetModelList(lstEntity);

                lstModel.ForEach(m =>
                {
                    m.UpdateUserName = _userService.Get(m.UpdateUserID).NickName;
                });

                return lstModel;
            }
        }

        public GetConfigEnvironmentViewModel Get(int ID)
        {
            using (var dbContext = ADbContext.Create())
            {
                var entity = dbContext.ConfigEnvironment.Single(ce => ce.ID == ID);

                var model = new MapperWrapper<GetConfigEnvironmentViewModel, ConfigEnvironment>().GetModel(entity);

                return model;
            }
        }

        public GetConfigEnvironmentViewModel Add(AddConfigEnvironmentViewModel model, int userID)
        {
            using (var dbContext = ADbContext.Create())
            {
                if (dbContext.ConfigEnvironment.Any(ce => ce.Name == model.Name && !ce.IsDeleted))
                {
                    throw new AException(ErrorCode.NameExist);
                }

                var entity = new MapperWrapper<AddConfigEnvironmentViewModel, ConfigEnvironment>().GetEntity(model);

                dbContext.Add<ConfigEnvironment, int>(entity, userID);

                return new MapperWrapper<GetConfigEnvironmentViewModel, ConfigEnvironment>().GetModel(entity);
            }
        }

        public GetConfigEnvironmentViewModel Update(UpdateConfigEnvironmentViewModel model, int userID)
        {
            using (var dbContext = ADbContext.Create())
            {
                if (dbContext.ConfigEnvironment.Any(ce => ce.Name == model.Name && ce.ID != model.ID && !ce.IsDeleted))
                {
                    throw new AException(ErrorCode.NameExist);
                }

                var entity = new MapperWrapper<UpdateConfigEnvironmentViewModel, ConfigEnvironment>().GetEntity(model);

                dbContext.Update<ConfigEnvironment, int>(entity, userID);

                return new MapperWrapper<GetConfigEnvironmentViewModel, ConfigEnvironment>().GetModel(entity);
            }
        }

        public void Delete(int ID, int userID)
        {
            using (var dbContext = ADbContext.Create())
            {
                var entity = dbContext.ConfigEnvironment.SingleOrDefault(u => u.ID == ID && !u.IsDeleted);

                dbContext.Delete<ConfigEnvironment, int>(entity, userID);

                dbContext.SaveChanges();
            }
        }
    }
}
