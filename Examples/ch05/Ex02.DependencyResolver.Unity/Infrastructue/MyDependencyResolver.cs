using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Controllers;
using System.Web.Http.Dependencies;
using Microsoft.Practices.Unity;
using Ch05.Common.Services;
using Ex02.DependencyResolver.Unity.Controllers;

namespace Ex02.DependencyResolver.Unity.Infrastructue
{
    public class MyDependencyResolver : IDependencyResolver
    {
        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            System.Diagnostics.Debug.WriteLine(serviceType.FullName);
            if (serviceType == typeof(CustomerController))
            {
                var service = new CustomerService();
                return new CustomerController(service);
            }
            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
            
        }
    }
}