using System;
using System.ServiceModel.Activation;

namespace WcfDemo.ServerApp.Unity.Infrastructure
{
    /// <summary>
    /// Note: 須手動加入 .NET 組件參考：System.ServiceModel.Activation.dll
    /// </summary>
    public class MyServiceHostFactory : ServiceHostFactory
    {
        protected override System.ServiceModel.ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new MyServiceHost(serviceType, baseAddresses);
        }
    }
}
