        using Autofac;
        
        namespace Ex01.HelloAutofac
        {
            class Program
            {
                private static IContainer _container;
        
                static void Main(string[] args)
                {
                    var builder = new ContainerBuilder();
                    builder.RegisterType<SayHelloInChinese>().As<ISayHello>();
        
                    _container = builder.Build();
        
                    SayHello();
                }
        
                static void SayHello()
                {
                    using (var scope = _container.BeginLifetimeScope())
                    {
                        ISayHello hello = _container.Resolve<ISayHello>();
                        hello.Run();
                    }                
                }
            }
        }
        