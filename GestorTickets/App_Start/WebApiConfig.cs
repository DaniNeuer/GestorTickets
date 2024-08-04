// Espacio de nombres que contiene tipos fundamentales y bases de .NET.
using System;

// Proporciona interfaces y clases genéricas para definir colecciones fuertemente tipadas.
using System.Collections.Generic;

// Proporciona clases e interfaces para consultas en colecciones.
using System.Linq;

// Proporciona la clase base para un controlador API en ASP.NET.
using System.Web.Http;

// Define el espacio de nombres para la configuración de Web API.
namespace GestorTickets
{
    // Clase estática para la configuración de Web API.
    public static class WebApiConfig
    {
        // Método para registrar la configuración de Web API.
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de Web API.

            // Rutas de Web API.
            config.MapHttpAttributeRoutes();

            // Definición de la ruta predeterminada de Web API.
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
