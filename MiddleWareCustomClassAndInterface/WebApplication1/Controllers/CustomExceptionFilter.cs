using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class CustomExceptionFilter: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            string message = string.Empty;
            if(context.Exception.InnerException == null)
            {
                message = context.Exception.Message;
            }
            else
            {
                message = context.Exception.InnerException.Message;
            }
            context.HttpContext.Response.StatusCode = 400;
            context.Result = new JsonResult(new
            {
                error = new[] { context.Exception.Message }
            });
        }
    }
}
