using Alpaca.Biz.Account;
using Alpaca.Model.Account;
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
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public UserViewModel Get(string userName, string password)
        {
            return new UserBiz().GetByPassword(userName, password);
        }
    }
}
