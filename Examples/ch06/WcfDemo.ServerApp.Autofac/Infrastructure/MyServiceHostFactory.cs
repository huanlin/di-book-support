using System;
using System.ServiceModel.Activation;
using Autofac;
using Autofac.Integration.Wcf;
using System.ServiceModel;

namespace WcfDemo.ServerApp.Autofac.Infrastructure
{
    /// <summary>
    /// Note: 須手動加入 .NET 組件參考：System.ServiceModel.Activation.dll
    /// </summary>
    public class MyServiceHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {   
            var host = base.CreateServiceHost(serviceType, baseAddresses);

            // 呼叫 Autofac.Wcf 套件所提供的擴充方法。
            host.AddDependencyInjectionBehavior(serviceType, App.Container);

            return host;
        }
    }
}
