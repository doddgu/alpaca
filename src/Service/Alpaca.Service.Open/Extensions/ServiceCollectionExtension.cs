using Alpaca.Biz.Config;
using Alpaca.Infrastructure.Config;
using Alpaca.Infrastructure.Enums;
using Alpaca.Interfaces.Account;
using Alpaca.Interfaces.Dispatch;
using Alpaca.Plugins.Account.OwnIntegration;
using Alpaca.Plugins.Dispatch.OwnIntegration;
using Alpaca.Plugins.Dispatch.Redis;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alpaca.Service.Open
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddIOC(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();

            services.AddSingleton(typeof(ConfigEnvironmentBiz));
            services.AddSingleton(typeof(ConfigAppBiz));

            return services;
        }

        public static IServiceCollection AddConfigDispatch(this IServiceCollection services)
        {
            AddConfigDispatchByConfig(services, AlpacaConfigWrapper.GetConfiguration());

            AlpacaConfigWrapper.RegisterChangeCallback(obj =>
            {
                AddConfigDispatchByConfig(services, AlpacaConfigWrapper.GetConfiguration());
            });

            return services;
        }

        private static void AddConfigDispatchByConfig(IServiceCollection services, object obj)
        {
            var configDispatchType = (ConfigDispatchType)Enum.Parse(typeof(ConfigDispatchType), ((IConfiguration)obj)["ConfigDispatch:Type"]);

            services.RemoveAll(typeof(IDispatchService));

            switch (configDispatchType)
            {
                case ConfigDispatchType.Redis:
                    services.AddSingleton<IDispatchService, RedisDispatchService>();
                    break;
                case ConfigDispatchType.OwnIntegration:
                    services.AddSingleton<IDispatchService, OwnIntegrationDispatchService>();
                    break;
                default:
                    break;
            }

            var dispatchService = services.BuildServiceProvider().GetService<IDispatchService>();
            dispatchService.ReloadConfig();
        }
    }
}
