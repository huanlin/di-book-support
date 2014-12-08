using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Ch07.Common.Contracts;
using Ch07.Common.Services;

namespace Ex09.AutoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            INotificationManager notySvc;
            
            //notySvc = GetNotificationService_V1();          
            //notySvc = GetNotificationService_V2();           
            //notySvc = GetNotificationService_V3();            
            notySvc = GetNotificationService_AutoFactory();
            
            notySvc.Notify("Michael", "Automatic factory example.");
        }

        // Version 1: a humble way.
        static INotificationManager GetNotificationService_V1()
        {
            return new NotificationManager(new EmailService(), new SmsService());
        }

        // Version 2: using a factory.
        static INotificationManager GetNotificationService_V2()
        {
            return new NotificationManager(new MessageServiceFactory());
        }

        // Version 3: using Func<T> as a factory method.
        static INotificationManager GetNotificationService_V3()
        {
            Func<IMessageService> factoryMethod = new MessageServiceFactory().GetService;
            return new NotificationManager(factoryMethod);
        }

        // Version 4: using Unity auto factory.
        //            這讓你可以用 Constructor Injection 的方式來注入 Func<T> 物件，而且不用自己寫物件工廠。
        //            此外，呼叫 Unity 容器的 RegisterType 方法時，也是用一般的寫法就行，無須特別指定 Func<T>。
        static INotificationManager GetNotificationService_AutoFactory()
        {
            var container = new UnityContainer();
            container.RegisterType<IMessageService, EmailService>();

            // Note: 看一下 NotificationManager2 的建構函式!
            return container.Resolve<NotificationManager2>(); 
        }
    }
}
