using System;
using System.Collections.Generic;
using Ch03.Common.Logging;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;
using Unity.Interception.ContainerIntegration;
using Unity;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;

namespace Ch03.UnityInterception
{
    static class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();

            // 為容器加入攔截功能。
            container.AddNewExtension<Interception>();

            // 註冊型別時，一併設定攔截器。
            container.RegisterType<ILogger, ConsoleLogger>(
                new Interceptor(new InterfaceInterceptor()), new InterceptionBehavior(typeof(MyLoggerBehavior)));

            // 解析 ILogger 物件。
            var logger = container.Resolve<ILogger>();

            // 呼叫 Log 方法。
            logger.Log("Hello, 利用 Unity 攔截物件的方法!");

            // Prevent screen from closing
            Console.ReadLine();
        }
    }

    public class MyLoggerBehavior : IInterceptionBehavior
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            // 呼叫方法之前
            Console.WriteLine("正要執行方法：" + input.MethodBase.Name);

            // 呼叫方法
            var result = getNext()(input, getNext);

            // 呼叫方法之後
            Console.WriteLine("方法執行完畢於：" + DateTime.Now.ToString());

            return result;
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            // 傳回空的型別集合，表示欲攔截之物件可以是任何型別。 
            return new Type[] { };
        }

        public bool WillExecute
        {
            get
            {
                return true;
            }
        }
    }
}
