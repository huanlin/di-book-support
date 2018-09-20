using System;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using Unity;

namespace WcfDemo.ServerApp.Unity.Infrastructure
{
    public class MyInstanceProvider : IInstanceProvider
    {
        private Type _contractType;

        public MyInstanceProvider(Type contractType)
        {
            _contractType = contractType;
        }

        public object GetInstance(InstanceContext instanceContext, System.ServiceModel.Channels.Message message)
        {
            return this.GetInstance(instanceContext);
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            try
            {
                // 解析 IService1 時會一併解析 IHelloService。
                return App.UnityContainer.Resolve(_contractType);
            }
            catch
            {
                // 若無法解析服務，則使用 Reflection 機制來建立物件。
                return Activator.CreateInstance(_contractType);
            }            
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            if (instance is IDisposable)
            {
                (instance as IDisposable).Dispose();
            }
        }
    }

}
