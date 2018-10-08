using System.Web.Mvc;

namespace Archery.Areas.BackOffice
{
    public class BackOfficeAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BackOffice";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BackOffice_IdentificationAdmin",
                "BackOffice/{controller}/{action}",
                new { controller = "Authentication", action = "Login"}
            );
            context.MapRoute(
                "Administration",
                "BackOffice/{controller}/{action}/{id}",
                new {  controller = "Dashboard", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
}