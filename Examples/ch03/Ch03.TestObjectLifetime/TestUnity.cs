using System;
using System.Diagnostics;
using Unity;
using Unity.Lifetime;

namespace Ch03.TestObjectLifetime
{
    class TestUnity
    {
        public void Run()
        {
            var container = new UnityContainer();
            container.RegisterType<IFoo, Foo>(new ContainerControlledLifetimeManager());

            while (true)
            {
                var obj = container.Resolve<IFoo>();
                obj.Hello();

                Process proc = Process.GetCurrentProcess();
                Console.WriteLine("Memory used: {0} MB", proc.PrivateMemorySize64 / (1024 * 1024));
            }

            //container.Dispose();          
        }
    }

}
