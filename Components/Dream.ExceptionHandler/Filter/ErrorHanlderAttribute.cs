using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Dream.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dream.ExceptionHandler.Filter
{
    public class ErrorHanlderAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = 200; // api接口总是返回200
            var apiError = new ApiResult<string>()
            {
                Code = ApiResultStatus.Failed,
                Description = new ApiResultDescription() { ErrorInfo = context.Exception.GetBaseException().Message }
            };
            context.Result = new JsonResult(apiError);
            base.OnException(context);
        }
    }
}
