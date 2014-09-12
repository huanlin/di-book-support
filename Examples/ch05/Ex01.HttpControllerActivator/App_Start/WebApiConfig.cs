using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Ch05.Common.Services;
using Ex01.HttpControllerActivator.Infrastructue;
using Ex01.HttpControllerActivator.Controllers;

namespace Ex01.HttpControllerActivator
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

            // 替換 IHttpControllerActivator 實作
            config.Services.Replace(typeof(IHttpControllerActivator),
            new MyHttpControllerActivator());
        }
    }
}
