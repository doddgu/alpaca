﻿using Alpaca.Data.EFCore;
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
        private ADbContext _dbContext = null;
        private IUserService _userServica = null;

        public ConfigAppBiz(ADbContext dbContext, IUserService userServica)
        {
            _dbContext = dbContext;
            _userServica = userServica;
        }

        public List<ConfigAppViewModel> GetList()
        {
            var lstEntity = _dbContext.ConfigApp.Where(ca => !ca.IsDeleted).OrderByDescending(ca => ca.UpdateTime).ToList();

            var lstModel = new MapperWrapper<ConfigAppViewModel, ConfigApp>().GetModelList(lstEntity);

            lstModel.ForEach(m =>
            {
                m.UpdateUserName = _userServica.Get(m.UpdateUserID).NickName;
            });

            return lstModel;
        }

        public GetConfigAppViewModel Get(int ID)
        {
            var entity = _dbContext.ConfigApp.Single(ca => ca.ID == ID);

            var model = new MapperWrapper<GetConfigAppViewModel, ConfigApp>().GetModel(entity);
            model.AppEnvironmentList = _dbContext.ConfigAppEnvironment.Where(cae => cae.ConfigAppID == ID && !cae.IsDeleted).Select(cae => cae.ConfigEnvironmentID).ToList();

            return model;
        }

        public GetConfigAppViewModel Add(AddConfigAppViewModel model, int userID)
        {
            if (_dbContext.ConfigApp.Any(ca => ca.Name == model.Name && !ca.IsDeleted))
            {
                throw new AException(ErrorCode.NameExist);
            }

            var entity = new MapperWrapper<AddConfigAppViewModel, ConfigApp>().GetEntity(model);

            using (var transaction = _dbContext.Database.BeginTransaction())
            {

                try
                {
                    _dbContext.Add<ConfigApp, int>(entity, userID);

                    _dbContext.AddRange<ConfigAppEnvironment, int>(model.AppEnvironmentList.Select(eid => new ConfigAppEnvironment()
                    {
                        ConfigAppID = entity.ID,
                        ConfigEnvironmentID = eid
                    }).ToList(), userID);

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }

            return new MapperWrapper<GetConfigAppViewModel, ConfigApp>().GetModel(entity);
        }

        public GetConfigAppViewModel Update(UpdateConfigAppViewModel model, int userID)
        {
            if (_dbContext.ConfigApp.Any(ca => ca.Name == model.Name && ca.ID != model.ID && !ca.IsDeleted))
            {
                throw new AException(ErrorCode.NameExist);
            }

            var entity = new MapperWrapper<UpdateConfigAppViewModel, ConfigApp>().GetEntity(model);
            var lstAppEnvironment = _dbContext.ConfigAppEnvironment.Where(cae => cae.ConfigAppID == model.ID && !cae.IsDeleted).ToList();
            var lstEnvironmentID = lstAppEnvironment.Select(cae => cae.ConfigEnvironmentID).ToList();

            var lstDeleteEnvironmentID = lstEnvironmentID.Except(model.AppEnvironmentList).ToList();
            var lstDeleteAppEnvironments = lstAppEnvironment.Where(cae => lstDeleteEnvironmentID.Contains(cae.ConfigEnvironmentID)).ToList();
            var lstAddEnvironmentID = model.AppEnvironmentList.Except(lstEnvironmentID).ToList();

            //using (var transaction = _dbContext.Database.BeginTransaction())
            //{

            //    try
            //    {
            _dbContext.Update<ConfigApp, int>(entity, userID);

            if (lstDeleteAppEnvironments.Count > 0)
                _dbContext.DeleteAll<ConfigAppEnvironment, int>(lstDeleteAppEnvironments, userID);

            if (lstAddEnvironmentID.Count > 0)
                _dbContext.AddRange<ConfigAppEnvironment, int>(lstAddEnvironmentID.Select(eid => new ConfigAppEnvironment()
                {
                    ConfigAppID = entity.ID,
                    ConfigEnvironmentID = eid
                }).ToList(), userID);

            //    transaction.Commit();
            //}
            //catch (Exception)
            //{
            //    transaction.Rollback();
            //    throw;
            //}
            //}

            return new MapperWrapper<GetConfigAppViewModel, ConfigApp>().GetModel(entity);
        }

        public void Delete(int ID, int userID)
        {
            var entity = _dbContext.ConfigApp.SingleOrDefault(u => u.ID == ID && !u.IsDeleted);

            _dbContext.Delete<ConfigApp, int>(entity, userID);
        }
    }
}
