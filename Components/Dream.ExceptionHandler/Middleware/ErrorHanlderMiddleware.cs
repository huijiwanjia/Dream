using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream.Logger;

namespace Dream.ExceptionHandler.Middleware
{
    public class ErrorHanlderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostingEnvironment _env;
        private readonly ILog _log;

        public ErrorHanlderMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, IHostingEnvironment env, ILog log)
        {
            _next = next;
            _env = env;
            _log = log;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);

                if (context.Response.HasStarted)
                {
                    _log.Info("The response has already started, the error page middleware will not be executed.");
                    throw;
                }
                try
                {
                    context.Response.Clear();
                    context.Response.StatusCode = 404;
                    return;
                }
                catch (Exception ex2)
                {
                    _log.Error(ex2.Message);
                }
                throw;
            }
        }
    }
}
