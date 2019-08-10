using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Dream.Security.LoginUtil;
using System.Linq;
using System.Threading.Tasks;

namespace Dream.Security.Auth
{
    public class DreamAuthorizeAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var loginService = new AuthenticationService();
            bool isAuthorized = loginService.IsLogin();
            if (!isAuthorized)
            {
                filterContext.Result = new RedirectResult("/login");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}