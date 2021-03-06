using Alpaca.Biz.Config;
using Alpaca.Data.EFCore;
using Alpaca.Infrastructure.Enums;
using Alpaca.Infrastructure.Mapping;
using Alpaca.Infrastructure.Robust.Exceptions;
using Alpaca.Model.Config.ConfigAppModels;
using Alpaca.Plugins.Account.OwnIntegration;
using Alpaca.Service.Open;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alpaca.Test.Config
{
    [TestClass]
    public class UTConfigApp
    {
        private ConfigAppBiz _biz;
        private ServiceCollection _services = new ServiceCollection();

        [TestInitialize]
        public void Initialize()
        {
            _services = new ServiceCollection();
            _services.AddIOC();
            _biz = _services.BuildServiceProvider().GetService<ConfigAppBiz>();
        }

        [TestMethod]
        public void Test()
        {
            var addConfigApp = new AddConfigAppViewModel()
            {
                Name = $"{DateTime.Now.Ticks}",
                AppEnvironmentList = new List<int>() { 1, 2 }
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
            updateConfigApp.AppEnvironmentList = new List<int>() { 2, 3 };

            // refresh dbcontext change tracker
            _biz = _services.BuildServiceProvider().GetService<ConfigAppBiz>();
            _biz.Update(updateConfigApp, 0);

            Assert.AreEqual(updateConfigApp.Name, _biz.Get(newConfigApp.ID).Name);

            var updatedConfigApp = _biz.Get(updateConfigApp.ID);

            Assert.IsTrue(updatedConfigApp.AppEnvironmentList.Intersect(new List<int>() { 2, 3 }).Count() == 2);

            _biz.Delete(newConfigApp.ID, 0);
        }
    }
}
