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


            // Sinon
            //routes.MapRoute(
            //    name:"AboutRoute",
            //    url: "a-propos",
            //    defaults: new {controller = "Home", action ="About"}
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
