using Alpaca.Data.EFCore;
using Alpaca.Infrastructure.Config;
using Alpaca.Infrastructure.Enums;
using Alpaca.Infrastructure.Logging;
using Alpaca.Interfaces.Account;
using Alpaca.Interfaces.Dispatch;
using Alpaca.Plugins.Account.OwnIntegration;
using Alpaca.Plugins.Dispatch.OwnIntegration;
using Alpaca.Plugins.Dispatch.Redis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Alpaca.Service.Open
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddIOC(this IServiceCollection services)
        {
            services.AddSingleton(services);
            services.AddSingleton<IUserService, UserService>();

            services.AddDbContext<ADbContext>(options => options.UseSqlServer(AlpacaConfigWrapper.GetConnectionString()));

            // Auto load all biz type
            var bizDlls = Directory.GetFiles(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Alpaca.Biz.*.dll");
            bizDlls.ToList().ForEach(dll =>
            {
                Assembly
                    .LoadFrom(dll)
                    .GetTypes()
                    .Where(t => t.Name.EndsWith("Biz"))
                    .ToList()
                    .ForEach(bizType => services.AddScoped(bizType));
            });

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

            IDispatchService dispatchService = null;

            switch (configDispatchType)
            {
                case ConfigDispatchType.Redis:
                    dispatchService = new RedisDispatchService();
                    break;
                case ConfigDispatchType.OwnIntegration:
                    dispatchService = new OwnIntegrationDispatchService();
                    break;
                default:
                    {
                        Logger.Error($"Not implement config dispatch type {configDispatchType}");
                        return;
                    }
            }

            dispatchService.ReloadConfig();

            var descriptor = new ServiceDescriptor(typeof(IDispatchService), sp => dispatchService, ServiceLifetime.Singleton);

            services.Replace(descriptor);
        }
    }
}
