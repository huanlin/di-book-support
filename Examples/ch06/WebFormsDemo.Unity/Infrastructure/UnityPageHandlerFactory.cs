using System;
using System.Reflection;
using System.Web;
using System.Web.UI;
using Unity;

namespace WebFormsDemo.Unity.Infrastructure
{
    public class UnityPageHandlerFactory : System.Web.UI.PageHandlerFactory
    {
        public override IHttpHandler GetHandler(HttpContext context, string requestType, string virtualPath, string path)
        {
            Page page = base.GetHandler(context, requestType, virtualPath, path) as Page;
            if (page != null)
            {
                var container = context.Application["Container"] as IUnityContainer;
                var properties = GetInjectableProperties(page.GetType());

                foreach (var prop in properties) 
                {
                    try
                    {
                        var service = container.Resolve(prop.PropertyType);
                        if (service != null)
                        {
                            prop.SetValue(page, service);
                        }
                    }
                    catch
                    {
                        // 沒辦法解析型別就算了。
                    }
                }
            }
            return page;
        }

        public static PropertyInfo[] GetInjectableProperties(Type type)
        {
            var propFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;
            var props = type.GetProperties(propFlags);
            if (props.Length == 0)
            {
                // 傳入的型別若是由 ASPX 頁面所生成的類別，那就必須取得其父類別（code-behind 類別）的屬性。
                props = type.BaseType.GetProperties(propFlags);
            }
            return props;
        }        
    }
}