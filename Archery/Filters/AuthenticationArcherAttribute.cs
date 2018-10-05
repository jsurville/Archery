using System;
using System.Web.Mvc;

namespace Archery.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class AuthenticationArcherAttribute : ActionFilterAttribute  // création d'un attribut de filtre d'authentification
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            if (filterContext.HttpContext.Session["ARCHER"] == null)
            {
                // filterContext.Result = new RedirectResult(@"\authenticationshooter\login");
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "authenticationshooter", action = "login", area = "" }));
            }
        }
    }
}