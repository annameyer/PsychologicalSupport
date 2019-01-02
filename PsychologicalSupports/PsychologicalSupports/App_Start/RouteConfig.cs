using System.Web.Mvc;
using System.Web.Routing;

namespace PsychologicalSupports
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default2",
                url: "{classed}",
                defaults: new { controller = "Students", action = "Index", classed = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default1",
                url: "{number}/{classed}",
                defaults: new { controller = "Students", action = "Index", number = UrlParameter.Optional, classed = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Students", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "Home",
                url: "{controller}/{action}",
                defaults: new { controller = "Students", action = "Index" }
            );

        }
    }
}
