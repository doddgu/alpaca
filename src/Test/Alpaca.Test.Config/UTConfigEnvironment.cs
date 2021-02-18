using Alpaca.Biz.Config;
using Alpaca.Data.EFCore;
using Alpaca.Infrastructure.Enums;
using Alpaca.Infrastructure.Mapping;
using Alpaca.Infrastructure.Robust.Exceptions;
using Alpaca.Model.Config.ConfigEnvironmentModels;
using Alpaca.Plugins.Account.OwnIntegration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Alpaca.Test.Config
{
    [TestClass]
    public class UTConfigEnvironment
    {
        private ConfigEnvironmentBiz _biz;

        [TestInitialize]
        public void Initialize()
        {
            _biz = new ConfigEnvironmentBiz(ADbContext.Create(), new UserService());
        }

        [TestMethod]
        public void Test()
        {
            var addConfigEnvironment = new AddConfigEnvironmentViewModel()
            {
                Name = $"{DateTime.Now.Ticks}"
            };

            var newConfigEnvironment = _biz.Add(addConfigEnvironment, 0);

            Assert.IsTrue(newConfigEnvironment.ID > 0);

            try
            {
                var temp = _biz.Add(addConfigEnvironment, 0);

                _biz.Delete(newConfigEnvironment.ID, 0);
                _biz.Delete(temp.ID, 0);
                Assert.Fail("check environment name failed.");
            }
            catch (AException aex)
            {
                Assert.AreEqual((int)ErrorCode.NameExist, aex.ErrorCode);
            }

            var updateConfigEnvironment = new MapperWrapper<UpdateConfigEnvironmentViewModel, GetConfigEnvironmentViewModel>().GetModel(newConfigEnvironment);
            updateConfigEnvironment.Name += "_D";
            _biz.Update(updateConfigEnvironment, 0);

            Assert.AreEqual(updateConfigEnvironment.Name, _biz.Get(newConfigEnvironment.ID).Name);

            _biz.Delete(newConfigEnvironment.ID, 0);
        }
    }
}
