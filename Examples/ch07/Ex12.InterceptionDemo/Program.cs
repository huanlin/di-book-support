using System;
using System.Collections.Generic;
using Ch07.Common.Contracts;
using Ch07.Common.Services;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity;

namespace Ex12.InterceptionDemo
{
    static class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();

            // 為容器加入攔截功能。
            container.AddNewExtension<Interception>();

            // 註冊型別時，一併設定攔截器。
            container.RegisterType<IMessageService, EmailService>(
                new Interceptor(new InterfaceInterceptor()), 
                new InterceptionBehavior(typeof(MyLoggerBehavior)),
                new InterceptionBehavior(typeof(MyLoggerBehavior2)));

            // 解析 IMessageService 物件。
            var msgService = container.Resolve<IMessageService>();

            // 呼叫方法。
            msgService.SendMessage("Michael", "Hello, 利用 Unity 攔截物件的方法!");

            // Prevent screen from closing
            Console.ReadLine();
        }
    }

    public class MyLoggerBehavior : IInterceptionBehavior
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            // 呼叫方法之前
            Console.WriteLine("正要執行此方法：{0}", input.MethodBase.Name);

            // 呼叫目標方法（被攔截的方法）
            var result = getNext()(input, getNext);

            // 呼叫方法之後
            Console.WriteLine("正要離開此方法：{0}，時間：{1}", input.MethodBase.Name, DateTime.Now.ToString());

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

    public class MyLoggerBehavior2 : IInterceptionBehavior
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            // 呼叫方法之前
            Console.WriteLine("2 before");

            // 呼叫目標方法（被攔截的方法）
            var result = getNext()(input, getNext);

            // 呼叫方法之後
            Console.WriteLine("2 after");

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
