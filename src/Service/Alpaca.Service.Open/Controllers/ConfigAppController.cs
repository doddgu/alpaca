using Alpaca.Biz.Config;
using Alpaca.Infrastructure.Security.Attributes;
using Alpaca.Model.Config.ConfigAppModels;
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
    public class ConfigAppController : ControllerBase
    {
        ConfigAppBiz _biz = null;

        public ConfigAppController(ConfigAppBiz biz)
        {
            _biz = biz;
        }

        [HttpGet]
        [Route("GetList")]
        public List<ConfigAppViewModel> GetList()
        {
            return _biz.GetList();
        }

        [HttpGet]
        public GetConfigAppViewModel Get(int ID)
        {
            return _biz.Get(ID);
        }

        [HttpPost]
        public GetConfigAppViewModel Post(AddConfigAppViewModel model)
        {
            return _biz.Add(model, User.GetUserID());
        }

        [HttpPut]
        public GetConfigAppViewModel Put(UpdateConfigAppViewModel model)
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
