using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using LayeredMvcDemo.Application.Services;
using LayeredMvcDemo.DataAccess;

namespace LayeredMvcDemo.Web.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: 如欲透過 web.config 來設定 Unity 容器，可恢復底下這行註解掉的程式碼。
            //       別忘了還要引用命名空間 Microsoft.Practices.Unity.Configuration。
            // container.LoadConfiguration();

            // 在此註冊你的型別。
            container.RegisterType<ICustomerService, CustomerService>();
            container.RegisterType<SouthwindContext, SouthwindContext>(new PerRequestLifetimeManager());
        }
    }
}
