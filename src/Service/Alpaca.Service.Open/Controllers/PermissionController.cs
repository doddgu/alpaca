using Alpaca.Biz.Account;
using Alpaca.Infrastructure.Enums;
using Alpaca.Infrastructure.Security.Attributes;
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
    public class PermissionController : ControllerBase
    {
        [HttpGet]
        [Route("GetList")]
        public dynamic GetList()
        {
            return Enum.GetNames(typeof(PermissionCode)).Select(pc =>
            {
                var permissionCode = Enum.Parse(typeof(PermissionCode), pc);
                var desc = EnumWrapper.GetEnumDescription(permissionCode);

                return new
                {
                    desc.EN,
                    desc.ZH,
                    Code = ((int)permissionCode).ToString()
                };
            }).ToList();
        }
    }
}
