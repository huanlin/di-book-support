using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Ch07.Common.Contracts;
using Ch07.Common.Services;

namespace Ex10.CustomFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            // 註冊型別時一併指定工廠方法
            var container = new UnityContainer();
            Func<IMessageService> factoryMethod = new MessageServiceFactory().GetService;
            container.RegisterType<IMessageService>(new InjectionFactory(c => factoryMethod()));

            // 解析
            var notyManager = container.Resolve<NotificationManager2>();

            notyManager.Notify("Michael", "Hello!");
        }
    }
}
