using System;
using Unity;
using Examples.Common.Services;

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
            container.RegisterType<IMessageService, MessageService>();
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