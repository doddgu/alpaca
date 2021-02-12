using Alpaca.Biz.Config;
using Alpaca.Interfaces.Account;
using Alpaca.Model.Config.ConfigEnvironmentModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alpaca.Service.Open.Controllers
{
    [Authorize]
    [EnableCors("AllowCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigEnvironmentController : ControllerBase
    {
        ConfigEnvironmentBiz _biz = null;

        public ConfigEnvironmentController(ConfigEnvironmentBiz biz)
        {
            _biz = biz;
        }

        [HttpGet]
        [Route("GetList")]
        public List<ConfigEnvironmentViewModel> GetList()
        {
            return _biz.GetList();
        }

        [HttpGet]
        public GetConfigEnvironmentViewModel Get(int ID)
        {
            return _biz.Get(ID);
        }

        [HttpPost]
        public GetConfigEnvironmentViewModel Post(AddConfigEnvironmentViewModel model)
        {
            return _biz.Add(model, User.GetUserID());
        }

        [HttpPut]
        public GetConfigEnvironmentViewModel Put(UpdateConfigEnvironmentViewModel model)
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
