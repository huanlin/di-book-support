using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using Ex0_Common.Services;
using Ex3_Unity.Infrastructure;
using Ex3_Unity.Controllers;

namespace Ex3_Unity
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            // 設定 DI 容器（註冊型別）。
            var container = new UnityContainer();
            container.RegisterType<IHelloService, HelloService>();
            container.RegisterType<HomeController>();

            // 換掉 MVC 框架的 dependency resolver。
            DependencyResolver.SetResolver(new MyDependencyResolver(container));

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
