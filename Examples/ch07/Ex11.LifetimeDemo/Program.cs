using System;
using Unity.Lifetime;
using Unity;

namespace Ex11.LifetimeDemo
{
    static class Program
    {
        static void Main(string[] args)
        {
            TestDefaultLifetime();
            TestContainerControlledLifetime();
            TestExternallyControlledLifetime();

            TestTransientLifetime();
            TestPerResolveLifetime();

            TestTransientLifetime_Nested();
            TestPerResolveLifetime_Nested();

            TestHierarchicalLifetime();
        }

        static void TestHierarchicalLifetime()
        {
            Console.WriteLine("Test HierarchicalLifetimeManager");
            LifetimeTest.ResetCounter();
            using (var parentContainer = new UnityContainer())
            {
                var lifeManager = new ContainerControlledLifetimeManager(); // HierarchicalLifetimeManager();
                parentContainer.RegisterType<ILifetimeTest, LifetimeTest>(lifeManager);

                // 建立子容器
                var childContainer = parentContainer.CreateChildContainer();

                var obj1 = parentContainer.Resolve<ILifetimeTest>(); // 使用父容器解析
                var obj2 = childContainer.Resolve<ILifetimeTest>();  // 使用子容器解析
                LifetimeTest.PrintCounter();  // 印出 ObjectCounter=2
            }
            LifetimeTest.PrintCounter();      // 印出 ObjectCounter=0
        }


        static void TestTransientLifetime()
        {
            Console.WriteLine("Test TransientLifetimeManager");
            LifetimeTest.ResetCounter();
            using (var container = new UnityContainer())
            {
                var lifeManager = new TransientLifetimeManager();
                container.RegisterType<ILifetimeTest, LifetimeTest>(lifeManager);

                var obj1 = container.Resolve<ILifetimeTest>();
                var obj2 = container.Resolve<ILifetimeTest>();
                LifetimeTest.PrintCounter();
            }
            LifetimeTest.PrintCounter();
        }

        static void TestTransientLifetime_Nested()
        {
            Console.WriteLine("Test TransientLifetimeManager_Nested");
            LifetimeTest.ResetCounter();
            using (var container = new UnityContainer())
            {
                var lifeManager = new TransientLifetimeManager();
                container.RegisterType<ILifetimeTest, LifetimeTest>(lifeManager);
                

                var obj1 = container.Resolve<Foo>();
                LifetimeTest.PrintCounter();
            }
            LifetimeTest.PrintCounter();
        }


        static void TestPerResolveLifetime()
        {
            Console.WriteLine("Test PerResolveLifetimeManager");
            LifetimeTest.ResetCounter();
            using (var container = new UnityContainer())
            {
                var lifeManager = new PerResolveLifetimeManager();
                container.RegisterType<ILifetimeTest, LifetimeTest>(lifeManager);

                var obj1 = container.Resolve<ILifetimeTest>();
                var obj2 = container.Resolve<ILifetimeTest>();
                LifetimeTest.PrintCounter();
            }
            LifetimeTest.PrintCounter();
        }

        static void TestPerResolveLifetime_Nested()
        {
            Console.WriteLine("Test PerResolveLifetimeManager_Nested");
            LifetimeTest.ResetCounter();
            using (var container = new UnityContainer())
            {
                var lifeManager = new PerResolveLifetimeManager();
                container.RegisterType<ILifetimeTest, LifetimeTest>(lifeManager);


                var obj1 = container.Resolve<Foo>();
                LifetimeTest.PrintCounter();
            }
            LifetimeTest.PrintCounter();
        }


        static void TestExternallyControlledLifetime()
        {
            Console.WriteLine("Test ExternallyControlledLifetimeManager");
            LifetimeTest.ResetCounter();
            using (var container = new UnityContainer())
            {
                var lifeManager = new ExternallyControlledLifetimeManager();
                container.RegisterType<ILifetimeTest, LifetimeTest>(lifeManager);

                var obj1 = container.Resolve<ILifetimeTest>();
                var obj2 = container.Resolve<ILifetimeTest>();
                obj1.Dispose();
                LifetimeTest.PrintCounter();
            }
            LifetimeTest.PrintCounter();
        }

        static void TestContainerControlledLifetime()
        {
            Console.WriteLine("Test ContainerControlledLifetimeManager");
            LifetimeTest.ResetCounter();
            using (var container = new UnityContainer())
            {
                var lifeManager = new ContainerControlledLifetimeManager();
                container.RegisterType<ILifetimeTest, LifetimeTest>(lifeManager);

                var obj1 = container.Resolve<ILifetimeTest>();
                var obj2 = container.Resolve<ILifetimeTest>();
                LifetimeTest.PrintCounter();
            }
            LifetimeTest.PrintCounter();
        }

        static void TestDefaultLifetime()
        {
            Console.WriteLine("Test default lifetime of RegisterInstance()");
            LifetimeTest.ResetCounter();     
            using (var container = new UnityContainer())
            {
                var theObj = new LifetimeTest();
                container.RegisterInstance<ILifetimeTest>(theObj);

                var obj1 = container.Resolve<ILifetimeTest>();
                var obj2 = container.Resolve<ILifetimeTest>();

                System.Diagnostics.Debug.Assert(obj1 == obj2);

                LifetimeTest.PrintCounter();

                //var c2 = new UnityContainer().RegisterInstance<LifetimeTest>(theObj);
                //var obj3 = c2.Resolve<LifetimeTest>();
                //LifetimeTest.PrintCounters();
            }

            LifetimeTest.PrintCounter();

            Console.WriteLine("Test default lifetime of RegisterType()");
            LifetimeTest.ResetCounter();
            using (var container = new UnityContainer())
            {
                container.RegisterType<ILifetimeTest, LifetimeTest>();

                var obj1 = container.Resolve<ILifetimeTest>();
                var obj2 = container.Resolve<ILifetimeTest>();

                LifetimeTest.PrintCounter();
            }
            LifetimeTest.PrintCounter();
        }
    }
}
