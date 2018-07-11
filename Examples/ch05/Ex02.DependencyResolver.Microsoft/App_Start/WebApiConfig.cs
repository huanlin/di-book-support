using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Ch05.Common.Services;
using Ex02.DependencyResolver.Microsoft.Infrastructue;
using Microsoft.Extensions.DependencyInjection;

namespace Ex02.DependencyResolver.Microsoft
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 設定和服務
            var services = new ServiceCollection();

            services.AddTransient<CustomerService>();

            var provider = services.BuildServiceProvider();

            config.DependencyResolver = new MyDependencyResolver(provider);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
