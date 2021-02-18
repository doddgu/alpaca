using Alpaca.Biz.Account;
using Alpaca.Infrastructure.Enums;
using Alpaca.Infrastructure.Security.Attributes;
using Alpaca.Model.Account;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alpaca.Service.Open.Controllers
{
    [EnableCors("AllowCors")]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        UserBiz _biz = null;

        public UserController(UserBiz biz)
        {
            _biz = biz;
        }

        [HttpGet]
        public UserViewModel Get(string userName, string password)
        {
            return _biz.GetByPassword(userName, password);
        }

        [AAtuh(nameof(PermissionCode.UserManagemenet))]
        [HttpPost]
        public UserViewModel Post(AddUserViewModel model)
        {
            return _biz.Add(model, User.GetUserID());
        }
        [AAtuh(nameof(PermissionCode.UserManagemenet))]
        [HttpPut]
        public UserViewModel UpadatePassword(EditUserPasswordViewModel model)
        {
            return _biz.UpdatePassword(model.ID, model.Password);
        }

        [AAtuh(nameof(PermissionCode.UserManagemenet))]
        [HttpDelete]
        public string Delete()
        {
            _biz.Delete(User.GetUserID());

            return "success";
        }
    }
}
