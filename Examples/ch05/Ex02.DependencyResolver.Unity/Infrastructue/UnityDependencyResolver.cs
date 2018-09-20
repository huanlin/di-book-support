using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Unity;

namespace Ex02.DependencyResolver.Unity.Infrastructue
{
    public class UnityDependencyResolver : IDependencyResolver
    {
        protected readonly IUnityContainer _container;

        public UnityDependencyResolver(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            _container = container;
        }

        public IDependencyScope BeginScope()
        {
            IUnityContainer childContainer = _container.CreateChildContainer();
            return new UnityDependencyResolver(childContainer);
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch 
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType);
            }
            catch
            {
                return new List<object>();
            }
        }

        public void Dispose()
        {
            _container.Dispose();
        }
    }
}