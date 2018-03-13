using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.Middleware
{
    public class ProcessRequestTimer
    {
        private readonly RequestDelegate next;
        private readonly IHostingEnvironment env;

        public ProcessRequestTimer(RequestDelegate next, IHostingEnvironment env)
	    {
            this.next = next;
            this.env = env;
        }

        public async Task Invoke(HttpContext context)
        {
            if(env.IsDevelopment())
            {
                var timer = Stopwatch.StartNew();
                await next(context);
                await context.Response.WriteAsync($"===================>Request took {timer.ElapsedMilliseconds}ms");
            }
        }
    }

    public static class MiddlewareHelper
    {
        public static IApplicationBuilder UseRequestTimerMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ProcessRequestTimer>();
        }
    }
}
