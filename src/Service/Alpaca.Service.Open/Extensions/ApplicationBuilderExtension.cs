using Alpaca.Data.EFCore;
using Alpaca.Data.Entities;
using Alpaca.Infrastructure.Diagnostics;
using Alpaca.Infrastructure.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Alpaca.Service.Open
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseDatabase(this IApplicationBuilder app)
        {
            using var scopedService = app.ApplicationServices.CreateScope();
            using var db = scopedService.ServiceProvider.GetService<ADbContext>();

            db.Database.Migrate();

            return app;
        }

        public static IApplicationBuilder UseAlpacaDiagnostic(this IApplicationBuilder app)
        {
            DiagnosticListener.AllListeners.Subscribe(new AlpacaDiagnosticObserver());

            return app;
        }
    }
}
