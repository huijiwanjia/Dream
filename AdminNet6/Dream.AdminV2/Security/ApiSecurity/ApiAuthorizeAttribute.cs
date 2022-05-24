using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;
using Dream.Model;

namespace Dream.Security
{
    public class ApiAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            bool isAuthorized = false;
            var authToken = HttpUtityHelper.Current.Request.Headers["pcssecurity"].FirstOrDefault();
            if (!string.IsNullOrWhiteSpace(authToken) && Provider.KeyIsAvailable(authToken)) isAuthorized = true;
            if (!isAuthorized)
            {
                context.HttpContext.Response.StatusCode = 200; // api接口总是返回200
                var apiError = new ApiResult<string>()
                {
                    Code = ApiResultStatus.Failed,
                    Description = new ApiResultDescription() { ErrorInfo = "don't have access to server" }
                };
                context.Result = new JsonResult(apiError);
            }
            base.OnActionExecuting(context);
        }
    }
}