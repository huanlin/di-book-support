using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Examples.Common.Services;
using WcfDemo.ServerApp.Autofac;

namespace WcfDemo.ServerApp.Autofac.Infrastructure
{
    public static class App
    {
        private static Lazy<IContainer> _container = new Lazy<IContainer>(ConfigAutofac);

        private static IContainer ConfigAutofac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MessageService>().As<IMessageService>();
            builder.RegisterType<Service1>();

            return builder.Build();
        }

        public static IContainer Container
        {
            get
            {
                return _container.Value;
            }
        }
    }
}