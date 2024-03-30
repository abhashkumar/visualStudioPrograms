using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class MyCustomeMiddleWare2
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public MyCustomeMiddleWare2(RequestDelegate next, ILoggerFactory logFactory)
        {
            _next = next;

            _logger = logFactory.CreateLogger("MyMiddleware");
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("Custom Middleware Incoming Request \n");
            await _next(httpContext);
            await httpContext.Response.WriteAsync("Custom Middleware Outgoing Response \n");

        }
    }
}
