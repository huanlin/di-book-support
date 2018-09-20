using System;
using Microsoft.Practices.Unity.Configuration;
using Unity;
using Ch07.Common.Contracts;

namespace Ex03.ConfigFile
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            container.LoadConfiguration();
            var svc = container.Resolve<IMessageService>();
            svc.SendMessage("Michael", "Hello!");
        }
    }
}
