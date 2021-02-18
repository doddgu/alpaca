using Alpaca.Biz.Account;
using Alpaca.Data.EFCore;
using Alpaca.Infrastructure.Enums;
using Alpaca.Infrastructure.Robust.Exceptions;
using Alpaca.Plugins.Account.OwnIntegration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Alpaca.Test.Account
{
    [TestClass]
    public class UTUser
    {
        private UserBiz _biz = null;

        [TestInitialize]
        public void Initialize()
        {
            _biz = new UserBiz(ADbContext.Create(), new UserService());
        }

        [TestMethod]
        [DataRow("admin", "admin")]
        public void TestGet(string userName, string password)
        {
            var user = _biz.GetByPassword(userName, password);

            Assert.IsTrue(user.ID > 0);
        }

        [TestMethod]
        public void TestAddAndDelete()
        {
            var newUser = new Model.Account.AddUserViewModel()
            {
                Name = $"{DateTime.Now.Ticks}",
                NickName = "Test",
                Password = "Test",
            };
            var user = _biz.Add(newUser, 0);

            Assert.IsTrue(user.ID > 0);

            try
            {
                var temp = _biz.Add(newUser, 0);

                _biz.Delete(user.ID);
                _biz.Delete(temp.ID);
                Assert.Fail("check user name failed.");
            }
            catch (AException aex)
            {
                Assert.AreEqual((int)ErrorCode.UserNameExist, aex.ErrorCode);
            }

            _biz.Delete(user.ID);
        }

        [TestMethod]
        [DataRow(1, "admin")]
        public void TestResetPassword(int userID, string password)
        {
            var user = _biz.UpdatePassword(userID, password);
            Assert.IsTrue(user != null);
        }
    }
}
