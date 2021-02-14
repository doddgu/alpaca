using Alpaca.Biz.Config;
using Alpaca.Infrastructure.Enums;
using Alpaca.Infrastructure.Mapping;
using Alpaca.Infrastructure.Robust.Exceptions;
using Alpaca.Model.Config.ConfigAppModels;
using Alpaca.Plugins.Account.OwnIntegration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Alpaca.Test.Account
{
    [TestClass]
    public class UTConfigApp
    {
        [TestMethod]
        public void Test()
        {
            var addConfigApp = new AddConfigAppViewModel()
            {
                Name = $"{DateTime.Now.Ticks}"
            };

            var biz = new ConfigAppBiz(new UserService());

            var newConfigApp = biz.Add(addConfigApp, 0);

            Assert.IsTrue(newConfigApp.ID > 0);

            try
            {
                var temp = biz.Add(addConfigApp, 0);

                biz.Delete(newConfigApp.ID, 0);
                biz.Delete(temp.ID, 0);
                Assert.Fail("check app name failed.");
            }
            catch (AException aex)
            {
                Assert.AreEqual((int)ErrorCode.NameExist, aex.ErrorCode);
            }

            var updateConfigApp = new MapperWrapper<UpdateConfigAppViewModel, GetConfigAppViewModel>().GetModel(newConfigApp);
            updateConfigApp.Name += "_D";
            biz.Update(updateConfigApp, 0);

            Assert.AreEqual(updateConfigApp.Name, biz.Get(newConfigApp.ID).Name);

            biz.Delete(newConfigApp.ID, 0);
        }
    }
}
