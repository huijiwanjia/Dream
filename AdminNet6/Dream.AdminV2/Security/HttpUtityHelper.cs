using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dream.Security
{
    public static class HttpUtityHelper
    {
        private static IHttpContextAccessor _contextAccessor;

        public static HttpContext Current => _contextAccessor.HttpContext;


        public static void Configure(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
    }
}
