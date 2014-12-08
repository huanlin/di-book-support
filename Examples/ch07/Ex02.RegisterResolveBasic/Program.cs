using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Ch07.Common.Contracts;
using Ch07.Common.Services;

namespace Ex02.RegisterTypeBasicDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ResolveConcreteClassDemo();

            ResolveAllDemo();

            GenericsDemo();
        }

        static void ResolveConcreteClassDemo()
        {
            Console.WriteLine("\n<<< ResolveConcreteClassDemo >>>");

            var container = new UnityContainer();
            var svc = container.Resolve<HelloService>();  // 具象類別不用預先註冊，Unity 可直接解析。
            Console.WriteLine(svc.Hello("Michael"));
            Console.WriteLine();
        }

        static void ResolveAllDemo()
        {
            Console.WriteLine("\n<<< ResolveAllDemo >>>");

            var container = new UnityContainer();
            container.RegisterType<IMessageService, EmailService>();  // 預設註冊
            container.RegisterType<IMessageService, EmailService>("Email"); // 具名註冊
            container.RegisterType<IMessageService, SmsService>("SMS");   // 具名註冊
            container.RegisterType<IMessageService, SmsService>("SMS");   // 具名註冊

            // 解析物件
            var services = container.ResolveAll<IMessageService>();
            foreach (var svc in services) 
            {
                svc.SendMessage("Michael", "You are resolved.");
            }
        }

        static string GetRegistrationName(Type t)
        {
            if (t.Name.IndexOf("Service") > 0)
            {
                string regName = t.Name.Replace("Service", "");
                return regName;
            }
            return String.Empty;
        }

        static void GenericsDemo()
        {
            Console.WriteLine("\n<<< GenericsDemo >>>");

            var container = new UnityContainer()
                .RegisterType<ICollection<string>, List<string>>(new InjectionConstructor());

            var list = container.Resolve<ICollection<string>>();
            list.Add("柯博文");

            foreach (var item in container.Registrations)
            {
                var s = String.Format(
                    "Name: '{0}', map from: {1}, map to: {2}", 
                    item.Name, item.RegisteredType.Name, item.MappedToType);
                Console.WriteLine(s);
            }

            Console.WriteLine(list.First());
        }
    }
}
