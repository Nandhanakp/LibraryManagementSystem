using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

namespace NewFolder.Controllers   // <- Must match your other controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Skip login check for AccountController
            if (context.Controller is not AccountController && HttpContext.Session.GetString("UserName") == null)
            {
                context.Result = RedirectToAction("Login", "Account");
            }
            base.OnActionExecuting(context);
        }

        // Optional helper
        protected bool IsStaff() => HttpContext.Session.GetString("Role") == "Staff";
    }
}
