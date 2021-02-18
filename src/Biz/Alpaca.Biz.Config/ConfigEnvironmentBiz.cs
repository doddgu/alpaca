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
        private ADbContext _dbContext = null;
        private IUserService _userService = null;

        public ConfigEnvironmentBiz(ADbContext dbContext, IUserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        public List<ConfigEnvironmentViewModel> GetList()
        {
            var lstEntity = _dbContext.ConfigEnvironment.Where(ce => !ce.IsDeleted).OrderByDescending(ce => ce.UpdateTime).ToList();

            var lstModel = new MapperWrapper<ConfigEnvironmentViewModel, ConfigEnvironment>().GetModelList(lstEntity);

            lstModel.ForEach(m =>
            {
                m.UpdateUserName = _userService.Get(m.UpdateUserID).NickName;
            });

            return lstModel;
        }

        public GetConfigEnvironmentViewModel Get(int ID)
        {
            var entity = _dbContext.ConfigEnvironment.Single(ce => ce.ID == ID);

            var model = new MapperWrapper<GetConfigEnvironmentViewModel, ConfigEnvironment>().GetModel(entity);

            return model;
        }

        public GetConfigEnvironmentViewModel Add(AddConfigEnvironmentViewModel model, int userID)
        {
            if (_dbContext.ConfigEnvironment.Any(ce => ce.Name == model.Name && !ce.IsDeleted))
            {
                throw new AException(ErrorCode.NameExist);
            }

            var entity = new MapperWrapper<AddConfigEnvironmentViewModel, ConfigEnvironment>().GetEntity(model);

            _dbContext.Add<ConfigEnvironment, int>(entity, userID);

            return new MapperWrapper<GetConfigEnvironmentViewModel, ConfigEnvironment>().GetModel(entity);
        }

        public GetConfigEnvironmentViewModel Update(UpdateConfigEnvironmentViewModel model, int userID)
        {
            if (_dbContext.ConfigEnvironment.Any(ce => ce.Name == model.Name && ce.ID != model.ID && !ce.IsDeleted))
            {
                throw new AException(ErrorCode.NameExist);
            }

            var entity = new MapperWrapper<UpdateConfigEnvironmentViewModel, ConfigEnvironment>().GetEntity(model);

            _dbContext.Update<ConfigEnvironment, int>(entity, userID);

            return new MapperWrapper<GetConfigEnvironmentViewModel, ConfigEnvironment>().GetModel(entity);
        }

        public void Delete(int ID, int userID)
        {
            var entity = _dbContext.ConfigEnvironment.SingleOrDefault(u => u.ID == ID && !u.IsDeleted);

            _dbContext.Delete<ConfigEnvironment, int>(entity, userID);
        }
    }
}
