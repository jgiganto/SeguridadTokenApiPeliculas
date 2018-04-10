using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SeguridadTokenApiPeliculas
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            // Web API routes
            config.MapHttpAttributeRoutes();
            //  config.Routes.MapHttpRoute(
            //    name: "Distribuidora",
            //    routeTemplate: "Distribuidoras",
            //    defaults: new { controller = "Peliculas", action= "MostrarDistribuidoras"  }
            //);

            //  config.Routes.MapHttpRoute(
            //    name: "Pelis",
            //    routeTemplate: "Pelis",
            //    defaults: new { controller = "Peliculas", action = "MostrarPeliculas" }
            //);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
           

            
        }
    }
}
