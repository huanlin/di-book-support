using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Controllers;
using Microsoft.Practices.Unity;
using Ch05.Common.Services;
using Ex01.HttpControllerActivator.Unity.Controllers;

namespace Ex01.HttpControllerActivator.Unity.Infrastructue
{
    public class MyHttpControllerActivator : IHttpControllerActivator
    {
        private IUnityContainer _container;

        public MyHttpControllerActivator(IUnityContainer container)
        {
            _container = container;
        }

        public IHttpController Create(
            HttpRequestMessage request, 
            HttpControllerDescriptor controllerDescriptor, 
            Type controllerType)
        {
            /* 不使用 DI 容器的寫法：
            if (controllerType == typeof(CustomerController))
            {
                var customerService = new CustomerService(); // 建立相依物件
                request.Properties.Add("Time", DateTime.Now); // 傳遞額外資訊
                return new CustomerController(customerService);
            }
            return null;
            */

            // 使用 DI 容器，程式碼更簡潔：
            var controller = _container.Resolve(controllerType);
            request.Properties.Add("Time", DateTime.Now); // 傳遞額外參數給 controller
            return controller as IHttpController;
        }
    }
}