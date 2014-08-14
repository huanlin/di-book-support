using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Ex0_Common.Services;

namespace Ex4_UnityMvc5
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // 在這裡向容器註冊你的元件。你的 controller 不用註冊。
            container.RegisterType<IHelloService, HelloService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}