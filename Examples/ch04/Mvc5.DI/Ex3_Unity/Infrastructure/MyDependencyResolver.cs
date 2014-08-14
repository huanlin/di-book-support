using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;

namespace Ex3_Unity.Infrastructure
{
    public class MyDependencyResolver : System.Web.Mvc.IDependencyResolver
    {
        private readonly IUnityContainer _container;

        public MyDependencyResolver(IUnityContainer container)
        {
            _container = container;
        }

        public object GetService(Type serviceType)
        {
            if (_container.IsRegistered(serviceType)) 
            {
                return _container.Resolve(serviceType);
            }
            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.ResolveAll(serviceType);
        }
    }
}