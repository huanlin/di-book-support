using System;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Ch05.Common.Services;
using Ex01.HttpControllerActivator.Unity.Infrastructue;
using Unity;

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
