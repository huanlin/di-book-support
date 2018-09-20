using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Ch07.Common.Contracts;
using Ch07.Common.Services;
using Unity;

namespace Ex08.DeferredResolution
{
    static class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            container.RegisterType<IMessageService, EmailService>();

            var svc = container.Resolve<IMessageService>();
            var lazySvc = container.Resolve<Lazy<IMessageService>>();

            Console.WriteLine("After resolution.");

            lazySvc.Value.SendMessage("Michael", "Hello!");
        }
    }
}
