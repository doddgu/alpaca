using Alpaca.Infrastructure.Robust.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Service.Open.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (KeyNotFoundException knfEx)
            {
                httpContext.Response.StatusCode = 404;
                httpContext.Response.ContentType = "text/plain;charset=utf-8";
                await httpContext.Response.WriteAsync(knfEx.Message, Encoding.UTF8).ConfigureAwait(false);
            }
            catch (AException aex)
            {
                httpContext.Response.StatusCode = 500;
                httpContext.Response.ContentType = "application/json;charset=utf-8";
                await httpContext.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    aex.ErrorCode,
                    aex.ZHMessage,
                    aex.ENMessage
                }), Encoding.UTF8).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                httpContext.Response.StatusCode = 500;
                httpContext.Response.ContentType = "text/plain;charset=utf-8";
                await httpContext.Response.WriteAsync(ex.ToString(), Encoding.UTF8).ConfigureAwait(false);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class GlobalExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}
