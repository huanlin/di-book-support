using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
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
