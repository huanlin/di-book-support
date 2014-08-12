using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using System.Diagnostics;

namespace Ch03.TestObjectLifetime
{
    class TestAutofac
    {
        public void Run()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Foo>().As<IFoo>();
            var container = builder.Build();

            while (true)
            {
                var obj = container.Resolve<IFoo>();
                
                Process proc = Process.GetCurrentProcess();
                Console.WriteLine("Memory used: {0} MB", proc.PrivateMemorySize64 / (1024 * 1024));
            }
        }
    }
}
