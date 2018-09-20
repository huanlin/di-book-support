using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace Test.ParameterOverrides
{
    static class Program
    {
        private static IUnityContainer _container;

        static void Main(string[] args)
        {
            _container = new UnityContainer();

            RegisterTypes(_container);

            var factory = _container.Resolve<IMyWebClientFactory>();
            var client = factory.Create("http://huan-lin.blogspot.com/");

            var content = client.DownloadString();
            Console.WriteLine(content);
        }

        static void RegisterTypes(IUnityContainer container)
        {              
            container.RegisterType<IMyWebClientFactory, MyWebClientFactory>(new ContainerControlledLifetimeManager());
            container.RegisterType<IMyWebClient, MyWebClient>(new PerResolveLifetimeManager());
        }
    }
}
