using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ex2_DependencyResolver.Infrastructure;

namespace Ex2_DependencyResolver
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);           

            // 設定 MVC 應用程式的全域 dependency resolver 物件。
            var myResolver = new MyDependencyResolver();
            DependencyResolver.SetResolver(myResolver);
        }
    }
}
