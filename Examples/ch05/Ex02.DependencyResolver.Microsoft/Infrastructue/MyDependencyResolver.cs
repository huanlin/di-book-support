using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Controllers;
using System.Web.Http.Dependencies;
using Ch05.Common.Services;
using Ex02.DependencyResolver.Microsoft.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace Ex02.DependencyResolver.Microsoft.Infrastructue
{
    public class MyDependencyResolver : IDependencyResolver
    {
        private readonly ServiceProvider _provider;


        public MyDependencyResolver(ServiceProvider provider)
        {
            _provider = provider;
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            return _provider.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _provider.GetServices(serviceType);
        }

        public void Dispose()
        {
            /* 注意: 這裡不可釋放 _provider。
             * 因為 ASP.NET Web API 每處理一個 request 就會呼叫一次 BeginScope()，
             * 然後在 request 結束時呼叫 IDependencyScope.Dispose()。
             * 這裡的 BeginScope() 返回的是自己（this），也就是說，此物件同時扮演 
             * resolver 和 scope（子容器）的角色。若在此方法中釋放 _provider，那麼在第一次
             * request 結束時就會把 _provider 釋放，導致第二次 request 沒有 _provider 
             * 可用而發生執行時期錯誤。
             */ 
        }
    }
}