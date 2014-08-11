using LayeredMvcDemo.Application.Services;
using LayeredMvcDemo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LayeredMvcDemo.Web.Controllers
{
    public class MyControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (controllerName == "Customer")
            {
                var service = new CustomerService();
                var controller = new CustomerController(service);
                return controller;
            }
            else
            {
                return null;
            }
        }
    }
}