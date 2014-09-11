using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Autofac;
using Examples.Common.Services;

namespace WebFormsDemo.Autofac
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<MessageService>().As<IMessageService>();

            Application["Container"] = builder.Build(); // 把容器物件保存在共用變數裡
        }
    }
}