using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Studynung.Database;
using Studynung.Helpers;
using Studynung.Logic;

namespace Studynung.Filters
{
    public class AuthSystem : ActionFilterAttribute
    {
        public UserRoles Roles { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (SessionHelper.User == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Auth" }, { "action", "Login" }, {"area", ""}});
                FormsAuthentication.RedirectToLoginPage();
            }
            else
            {
                using (var container = new StudynungContainer())
                {
                    var roles = container.Roles.ToList().First(r => r.Name == Roles.GetDescription());
                    if (roles.Users.Any(u=>u.Id == SessionHelper.User.Id) == false)
                    {
                        filterContext.Result = new RedirectResult("~/Auth/Login");                        
                    }
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}