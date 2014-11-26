using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Ch05.Common.Services;

namespace Ex02.DependencyResolver.AutofacDemo
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

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(typeof(WebApiConfig).Assembly);
            builder.RegisterType<CustomerService>().As<ICustomerService>(); // RegisterType<實作類別>().As<抽象型別>()

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            config.DependencyResolver = resolver; 
        }
    }
}
