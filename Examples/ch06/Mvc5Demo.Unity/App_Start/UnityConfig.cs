using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Examples.Common.Services;

namespace Mvc5Demo.Unity.App_Start
{
    /// <summary>
    /// 用來設定主要的 Unity 容器。
    /// </summary>
    public class UnityConfig
    {
        #region Unity 容器
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// 取得 Unity 容器的執行個體。
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>向 Unity 容器註冊型別對應。</summary>
        /// <param name="container">欲設定的 Unity 容器。</param>
        /// <remarks>
        ///   除非你想要改變預設行為，否則不需要自行註冊具象類別，例如 controllers 或 
        ///   API controllers；因為無論是否預先註冊具象類別，Unity 都能自動解析它們。
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // 如欲透過 web.config 來設定 Unity 容器，可恢復底下這行註解掉的程式碼。
            // 別忘了還要引用命名空間 Microsoft.Practices.Unity.Configuration。

            // 在此註冊你的型別。
            container.RegisterType<IMessageService, MessageService>();
        }
    }
}
