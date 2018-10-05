using System.Web.Mvc;
using System.Web.Routing;

namespace Archery
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes(); // si on veut mapper directement dans le controler 


          
           //routes.MapRoute(
           //    name:"SingIn",
           //    url: "/{}/{controller}/{action}/{id}",
           //    defaults: new {controller = "AuthenticationShooter", action ="Login"}
           //    );

            // ROUTE PAR DEFAUT toujours en dernier !!
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
