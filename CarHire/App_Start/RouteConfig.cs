namespace CarHire
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //vehicles routes
            routes.MapRoute("VehiclesIndex", "Vehicles/Index/{locationId}",
                        new { controller = "Vehicles", action = "Index", locationId = UrlParameter.Optional });


            //default
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}