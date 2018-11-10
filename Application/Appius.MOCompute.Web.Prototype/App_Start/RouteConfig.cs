using System.Web.Mvc;
using System.Web.Routing;

namespace Appius.MOCompute.Web.Prototype
{
    /// <summary>
    /// On-start route configuration
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Regster the default application routes and enable attriute routing
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("Services/{filename}.svc");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                       name: "Default",
                       url: "{controller}/{action}/{id}",
                       defaults: new { controller = "HomePage", action = "Index", id = UrlParameter.Optional }
                   );
        }
    }
}
