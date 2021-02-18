using Alpaca.Biz.Account;
using Alpaca.Model.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        [HttpGet]
        public UserViewModel Get(string userName, string password)
        {
            return new UserBiz().GetByPassword(userName, password);
        }

        [Authorize]
        [HttpPost]
        public UserViewModel Post(AddUserViewModel model)
        {
            return new UserBiz().Add(model, User.GetUserID());
        }
        [Authorize]
        [HttpPut]
        public UserViewModel UpadatePassword(EditUserPasswordViewModel model)
        {
            return new UserBiz().UpdatePassword(model.ID, model.Password);
        }

        [Authorize]
        [HttpDelete]
        public string Delete()
        {
            new UserBiz().Delete(User.GetUserID());

            return "success";
        }
    }
}
