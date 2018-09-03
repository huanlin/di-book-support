using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Ch07.Common.Contracts;
using Unity;

namespace Ex06.AutoWiring
{
    static class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();

            // 注意這裡的 EmailService 是本專案的類別，不是 Ex07.Common.Service.EmailService。
            var svc = container.Resolve<EmailService>(); 

            svc.SendMessage("michael", "hello!");
        }
    }
}
