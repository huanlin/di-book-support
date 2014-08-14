using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ex0_Common.Services;
using Ex2_DependencyResolver.Controllers;

namespace Ex2_DependencyResolver.Infrastructure
{
    public class MyDependencyResolver : System.Web.Mvc.IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            // 觀察 MVC 框架有哪些服務會透過 dependency resolver 來解析。
            System.Diagnostics.Debug.WriteLine(serviceType.FullName);

            // 解析特定 controller。
            if (serviceType == typeof(HomeController))
            {
                var helloSvc = new HelloService();
                var controller = new HomeController(helloSvc);
                return controller;
            }

            // 不需要在此解析的型別，必須傳回 null。（不可拋異常！）
            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            // 沒有特別要解析的型別，故傳回空集合。（不可拋異常！）
            return new List<object>();
        }
    }
}