using System.Web.Mvc;
using System.Web.Routing;

namespace Preparation.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Preparation",
                    action = "List", 
                    id = UrlParameter.Optional
                }
            );


            routes.MapRoute(null,
             "",
             new
             {
                 controller = "Preparation",
                 action = "Filter",
                 filter = (string)null,
                 value = (string)null
             }
             );
        }
    }
}