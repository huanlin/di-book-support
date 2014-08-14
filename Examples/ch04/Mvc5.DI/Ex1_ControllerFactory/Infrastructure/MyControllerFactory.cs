using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ex1_ControllerFactory.Controllers;
using Ex0_Common.Services;

namespace Ex1_ControllerFactory.Infrastructure
{
    public class MyControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (controllerName.ToLower() == "home")
            {
                // 建立相依物件並注入至新建立的 controller。
                var service = new HelloService();
                var controller = new HomeController(service);
                return controller;
            }

            // 其他不需要特殊處理的 controller 型別就使用 MVC 內建的工廠來建立。
            return base.CreateController(requestContext, controllerName);
        }

        public override void ReleaseController(IController controller)
        {
            // 如果需要釋放其他物件資源，可寫在這裡。
            base.ReleaseController(controller);
        }
    }
}