using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ex4_UnityMvc5
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            // 加入底下這行，然後在此方法中註冊你的型別。 
            UnityConfig.RegisterComponents();    

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
