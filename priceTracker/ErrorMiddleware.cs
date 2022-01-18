using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace priceTracker
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext,ILogger<ErrorMiddleware> _logger)
        {

            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message,ex.StackTrace);
                httpContext.Response.StatusCode = 500;
            }
            
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ErrorMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorMiddleware>();
        }
    }
}
