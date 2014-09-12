using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Controllers;
using Ch05.Common.Services;
using Ex01.HttpControllerActivator.Controllers;

namespace Ex01.HttpControllerActivator.Infrastructue
{
    public class MyHttpControllerActivator : IHttpControllerActivator
    {
        public IHttpController Create(
            HttpRequestMessage request, 
            HttpControllerDescriptor controllerDescriptor, 
            Type controllerType)
        {
            if (controllerType == typeof(CustomerController))
            {
                var customerService = new CustomerService(); // 建立相依物件
                request.Properties.Add("Time", DateTime.Now); // 傳遞額外資訊
                return new CustomerController(customerService);
            }
            return null;
        }
    }
}