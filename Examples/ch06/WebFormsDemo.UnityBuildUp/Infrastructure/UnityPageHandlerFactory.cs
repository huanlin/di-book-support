using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using Unity;

namespace WebFormsDemo.UnityBuildUp.Infrastructure
{
    public class UnityPageHandlerFactory : System.Web.UI.PageHandlerFactory
    {
        public override IHttpHandler GetHandler(HttpContext context, string requestType, string virtualPath, string path)
        {
            Page page = base.GetHandler(context, requestType, virtualPath, path) as Page;
            if (page != null)
            {
                var container = context.Application["Container"] as Unity.IUnityContainer;

                container.BuildUp(page.GetType(), page);
            }
            return page;
        }
    }
}