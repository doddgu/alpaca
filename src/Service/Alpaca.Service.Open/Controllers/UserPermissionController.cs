using Alpaca.Biz.Account;
using Alpaca.Infrastructure.Security.Attributes;
using Alpaca.Model.Account.UserPermissionModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alpaca.Service.Open.Controllers
{
    [AAtuh]
    [EnableCors("AllowCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserPermissionController : ControllerBase
    {
        UserPermissionBiz _biz = null;

        public UserPermissionController(UserPermissionBiz biz)
        {
            _biz = biz;
        }

        [HttpGet]
        [Route("GetList")]
        public List<UserPermissionViewModel> GetList(int userID)
        {
            return _biz.GetList(userID);
        }

        [HttpGet]
        public GetUserPermissionViewModel Get(int ID)
        {
            return _biz.Get(ID);
        }

        [HttpPost]
        public GetUserPermissionViewModel Post(AddUserPermissionViewModel model)
        {
            return _biz.Add(model, User.GetUserID());
        }

        [HttpPut]
        public GetUserPermissionViewModel Put(UpdateUserPermissionViewModel model)
        {
            return _biz.Update(model, User.GetUserID());
        }

        [HttpDelete]
        public string Delete(int ID)
        {
            _biz.Delete(ID, User.GetUserID());

            return "success";
        }
    }
}
