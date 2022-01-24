using DL;
using Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace priceTracker
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RatingMiddleware
    {
        private readonly RequestDelegate _next;
        private PriceTrackerContext _context ;

        public RatingMiddleware(RequestDelegate next)
        {
            _next = next;
            

        }

        public async Task Invoke(HttpContext httpContext, PriceTrackerContext context)
        {
            
            _context = context;
            await _next(httpContext);
            Rating r = new Rating { 
                Host = httpContext.Request.Host.ToString(), 
                RecordDate = DateTime.Now,
                Method = httpContext.Request.Method, 
                Path = httpContext.Request.Path,
                UserAgent = httpContext.Request.Headers["User-Agent"].ToString(),
                Referer = httpContext.Request.Headers["Referer"],
            };
            _context.Ratings.Add(r);
            await _context.SaveChangesAsync();


        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RatingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRatingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingMiddleware>();
        }
    }
}
