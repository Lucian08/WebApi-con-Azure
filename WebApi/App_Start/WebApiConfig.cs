using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de Web API

            // Rutas de Web API
            config.MapHttpAttributeRoutes();

            //que convierte en formato json
            var json = config.Formatters.JsonFormatter;

            //request y responde, son serializado por NewtonSoft, el cual
            //
            json.SerializerSettings.PreserveReferencesHandling =
                Newtonsoft.Json.PreserveReferencesHandling.Objects;


            //quita la salida en formato XML.
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            /*activa la primera ruta por defecto, cuando se levanta el 
             servicio*/

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
