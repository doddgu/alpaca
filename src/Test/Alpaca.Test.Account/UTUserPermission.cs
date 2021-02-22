using Alpaca.Biz.Account;
using Alpaca.Data.EFCore;
using Alpaca.Interfaces.Account;
using Alpaca.Model.Account.UserPermissionModels;
using Alpaca.Service.Open;
using Microsoft.Extensions.DependencyInjection;
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
            var services = new ServiceCollection();
            services.AddIOC();
            _dbContext = services.BuildServiceProvider().GetService<ADbContext>();
            _userService = services.BuildServiceProvider().GetService<IUserService>();
        }

        [TestMethod]
        public void Test()
        {
            var permissionCode = DateTime.Now.Ticks.ToString();
            var addUserPermission = new AddUserPermissionViewModel()
            {
                UserID = 1,
                PermissionCode = permissionCode
            };

            var biz = new UserPermissionBiz(_dbContext, _userService);

            var newUserPermission = biz.Add(addUserPermission, 0);

            Assert.IsTrue(newUserPermission.ID > 0);

            var temp = biz.Add(addUserPermission, 0);

            var lstUserPermission = _userService.GetUserPermissionList(addUserPermission.UserID);

            Assert.IsTrue(lstUserPermission.Contains(permissionCode));

            biz.Delete(newUserPermission.ID, 0);

            lstUserPermission = _userService.GetUserPermissionList(addUserPermission.UserID);

            Assert.IsFalse(lstUserPermission.Contains(permissionCode));

            if (newUserPermission.ID != temp.ID)
                biz.Delete(temp.ID, 0);

            Assert.AreEqual(newUserPermission.ID, temp.ID);
        }
    }
}
