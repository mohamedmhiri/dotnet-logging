using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Serilog;
using Serilog.Formatting.Compact;

namespace LoggingExample
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
            /*config.Services.Add(typeof(LoggerConfiguration), new LoggerConfiguration()
           .WriteTo.Console()
           .WriteTo.File(new CompactJsonFormatter(), @"D:\Log.json")
           .CreateLogger());*/
        }
    }
}
