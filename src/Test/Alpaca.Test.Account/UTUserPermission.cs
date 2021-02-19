using Alpaca.Biz.Account;
using Alpaca.Data.EFCore;
using Alpaca.Infrastructure.Enums;
using Alpaca.Infrastructure.Mapping;
using Alpaca.Infrastructure.Robust.Exceptions;
using Alpaca.Interfaces.Account;
using Alpaca.Model.Account.UserPermissionModels;
using Alpaca.Plugins.Account.OwnIntegration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Alpaca.Test.Account
{
    [TestClass]
    public class UTUserPermission
    {
        private ADbContext _dbContext;
        private IUserService _userService;

        [TestInitialize]
        public void Initialize()
        {
            _dbContext = ADbContext.Create();
            _userService = new UserService();
        }

        [TestMethod]
        public void Test()
        {
            var addUserPermission = new AddUserPermissionViewModel()
            {
                UserID = 1,
                PermissionCode = $"{DateTime.Now.Ticks}"
            };

            var biz = new UserPermissionBiz(_dbContext, _userService);

            var newUserPermission = biz.Add(addUserPermission, 0);

            Assert.IsTrue(newUserPermission.ID > 0);

            var temp = biz.Add(addUserPermission, 0);

            biz.Delete(newUserPermission.ID, 0);

            if (newUserPermission.ID != temp.ID)
                biz.Delete(temp.ID, 0);

            Assert.AreEqual(newUserPermission.ID, temp.ID);

            var updateUserPermission = new MapperWrapper<UpdateUserPermissionViewModel, GetUserPermissionViewModel>().GetModel(newUserPermission);
            updateUserPermission.PermissionCode += "_D";
            biz.Update(updateUserPermission, 0);

            Assert.AreEqual(updateUserPermission.PermissionCode, biz.Get(newUserPermission.ID).PermissionCode);

            biz.Delete(newUserPermission.ID, 0);
        }
    }
}
