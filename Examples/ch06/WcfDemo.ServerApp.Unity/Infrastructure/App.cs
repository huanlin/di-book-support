using Examples.Common.Services;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfDemo.ServerApp.Unity.Infrastructure
{
    public static class App
    {
        private static Lazy<IUnityContainer> _container = new Lazy<IUnityContainer>(() => 
            {
                var container = new UnityContainer();
                ConfigUnity(container);
                return container;
            });

        private static void ConfigUnity(IUnityContainer container)
        {
            container.RegisterType<IHelloService, HelloService>();
            container.RegisterType<IService1, Service1>();
        }

        public static IUnityContainer UnityContainer
        {
            get
            {
                return _container.Value;
            }
        }
    }
}