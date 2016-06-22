using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CarHire
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "VehiclesApi", 
                "api/Cars/{vehicleId}", 
                new { controller = "VehiclesApi", vehicleId = RouteParameter.Optional });


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
