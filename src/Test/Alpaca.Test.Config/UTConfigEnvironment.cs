using Alpaca.Biz.Config;
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
        [TestMethod]
        public void Test()
        {
            var addConfigEnvironment = new AddConfigEnvironmentViewModel()
            {
                Name = $"{DateTime.Now.Ticks}"
            };

            var biz = new ConfigEnvironmentBiz(new UserService());

            var newConfigEnvironment = biz.Add(addConfigEnvironment, 0);

            Assert.IsTrue(newConfigEnvironment.ID > 0);

            try
            {
                var temp = biz.Add(addConfigEnvironment, 0);

                biz.Delete(newConfigEnvironment.ID, 0);
                biz.Delete(temp.ID, 0);
                Assert.Fail("check environment name failed.");
            }
            catch (AException aex)
            {
                Assert.AreEqual((int)ErrorCode.NameExist, aex.ErrorCode);
            }

            var updateConfigEnvironment = new MapperWrapper<UpdateConfigEnvironmentViewModel, GetConfigEnvironmentViewModel>().GetModel(newConfigEnvironment);
            updateConfigEnvironment.Name += "_D";
            biz.Update(updateConfigEnvironment, 0);

            Assert.AreEqual(updateConfigEnvironment.Name, biz.Get(newConfigEnvironment.ID).Name);

            biz.Delete(newConfigEnvironment.ID, 0);
        }
    }
}
