using Alpaca.Biz.Config;
using Alpaca.Data.EFCore;
using Alpaca.Infrastructure.Enums;
using Alpaca.Infrastructure.Mapping;
using Alpaca.Infrastructure.Robust.Exceptions;
using Alpaca.Model.Config.ConfigAppModels;
using Alpaca.Plugins.Account.OwnIntegration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Alpaca.Test.Config
{
    [TestClass]
    public class UTConfigApp
    {
        private ConfigAppBiz _biz;

        [TestInitialize]
        public void Initialize()
        {
            _biz = new ConfigAppBiz(ADbContext.Create(), new UserService());
        }

        [TestMethod]
        public void Test()
        {
            var addConfigApp = new AddConfigAppViewModel()
            {
                Name = $"{DateTime.Now.Ticks}"
            };

            var newConfigApp = _biz.Add(addConfigApp, 0);

            Assert.IsTrue(newConfigApp.ID > 0);

            try
            {
                var temp = _biz.Add(addConfigApp, 0);

                _biz.Delete(newConfigApp.ID, 0);
                _biz.Delete(temp.ID, 0);
                Assert.Fail("check app name failed.");
            }
            catch (AException aex)
            {
                Assert.AreEqual((int)ErrorCode.NameExist, aex.ErrorCode);
            }

            var updateConfigApp = new MapperWrapper<UpdateConfigAppViewModel, GetConfigAppViewModel>().GetModel(newConfigApp);
            updateConfigApp.Name += "_D";
            _biz.Update(updateConfigApp, 0);

            Assert.AreEqual(updateConfigApp.Name, _biz.Get(newConfigApp.ID).Name);

            _biz.Delete(newConfigApp.ID, 0);
        }
    }
}
