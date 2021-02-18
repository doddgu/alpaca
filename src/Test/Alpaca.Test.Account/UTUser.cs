using Alpaca.Biz.Account;
using Alpaca.Infrastructure.Enums;
using Alpaca.Infrastructure.Robust.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Alpaca.Test.Account
{
    [TestClass]
    public class UTUser
    {
        [TestMethod]
        [DataRow("admin", "admin")]
        public void TestGet(string userName, string password)
        {
            var user = new UserBiz().GetByPassword(userName, password);

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
            var user = new UserBiz().Add(newUser, 0);

            Assert.IsTrue(user.ID > 0);

            try
            {
                var temp = new UserBiz().Add(newUser, 0);

                new UserBiz().Delete(user.ID);
                new UserBiz().Delete(temp.ID);
                Assert.Fail("check user name failed.");
            }
            catch (AException aex)
            {
                Assert.AreEqual((int)ErrorCode.UserNameExist, aex.ErrorCode);
            }

            new UserBiz().Delete(user.ID);
        }

        [TestMethod]
        [DataRow(1, "admin")]
        public void TestResetPassword(int userID, string password)
        {
            var user = new UserBiz().UpdatePassword(userID, password);
            Assert.IsTrue(user != null);
        }
    }
}
