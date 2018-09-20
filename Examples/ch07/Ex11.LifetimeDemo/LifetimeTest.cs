using System;

namespace Ex11.LifetimeDemo
{

    interface ILifetimeTest : IDisposable
    {
        // 空介面，不定義任何方法。
    }

    class LifetimeTest : ILifetimeTest 
    {
        public static int ObjectCounter { get; private set; }

        public static void ResetCounter()
        {
            ObjectCounter = 0;
        }

        public static void PrintCounter()
        {
            Console.WriteLine("  ObjectCounter={0}", ObjectCounter);
        }

        public LifetimeTest()
        {
            LifetimeTest.ObjectCounter++;
        }

        public void Dispose()
        {
            LifetimeTest.ObjectCounter--;
        }
    }

    class Qoo : ILifetimeTest
    {

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    class Foo
    {
        public Foo(Bar bar, ILifetimeTest lifetimeTest)
        {            
        }
    }

    class Bar
    {
        public Bar(ILifetimeTest lifetimeTest)
        {

        }
    }
}
