using Alpaca.Biz.Config;
using Alpaca.Interfaces.Account;
using Alpaca.Plugins.Account.OwnIntegration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
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

            return services;
        }
    }
}
