using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Microsoft.Practices.Unity;
using Ch05.Common.Services;
using Ex01.HttpControllerActivator.Unity.Infrastructue;
using Ex01.HttpControllerActivator.Unity.Controllers;

namespace Ex01.HttpControllerActivator.Unity
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

            var container = new UnityContainer();
            container.RegisterType<ICustomerService, CustomerService>();
            
            var myControllerActivator = new MyHttpControllerActivator(container);
            config.Services.Replace(typeof(IHttpControllerActivator), myControllerActivator);
        }
    }
}
