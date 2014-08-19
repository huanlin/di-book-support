using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using Autofac;

namespace WebFormsDemo.Autofac.Infrastructure
{
    public class AutofacPageHandlerFactory : System.Web.UI.PageHandlerFactory
    {
        public override IHttpHandler GetHandler(HttpContext context, string requestType, string virtualPath, string path)
        {
            Page page = base.GetHandler(context, requestType, virtualPath, path) as Page;

            if (page == null)
            {
                return null;
            }

            IContainer container = context.Application["Container"] as IContainer;
            container.InjectProperties(page);

            return page;
        }
    }
}