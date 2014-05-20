using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Studynung.Helpers;

namespace Studynung.Filters
{
    public class AuthSystem : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (SessionHelper.User == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Auth" }, { "action", "Login" }});
            }
            base.OnActionExecuting(filterContext);
        }
    }
}