using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.ActionFilters
{
    public class RateLimiting2: ActionFilterAttribute
    {
        private readonly IMemoryCache memoryCache;
        public RateLimiting2(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // throw new NotImplementedException();
            var host = context.HttpContext.Request.Host;
            var action = context.ActionDescriptor.DisplayName;
            int count;
            if (memoryCache.TryGetValue(action, out count))
            {
                if (count < 5)
                    memoryCache.Set(action, count + 1);
                else
                {
                    context.Result = new NotFoundObjectResult("Service not available");
                    return;
                }
            }
            else
                memoryCache.Set(action, 0);
        }
    }
}
