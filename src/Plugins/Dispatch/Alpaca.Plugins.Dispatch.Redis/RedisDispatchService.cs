using Alpaca.Infrastructure.Config;
using Alpaca.Infrastructure.Logging;
using Alpaca.Interfaces.Dispatch;
using Alpaca.Plugins.Dispatch.Redis.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Plugins.Dispatch.Redis
{
    public class RedisDispatchService : IDispatchService
    {
        public void ReloadConfig()
        {
            var dc = AlpacaConfigWrapper.GetModel<DispatchConfig>("ConfigDispatch:Config");

            Logger.Debug($"{nameof(RedisDispatchService)}: ReloadConfig.ConnectionString = {dc.ConnectionString}");
        }
    }
}
