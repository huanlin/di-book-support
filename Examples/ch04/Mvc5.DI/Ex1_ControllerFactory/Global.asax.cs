using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ex1_ControllerFactory.Infrastructure;

namespace Ex1_ControllerFactory
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);           

            // 把 MVC 框架的預設 controller factory 換掉。
            var ctrlFactory = new MyControllerFactory();
            ControllerBuilder.Current.SetControllerFactory(ctrlFactory);
        }
    }
}
