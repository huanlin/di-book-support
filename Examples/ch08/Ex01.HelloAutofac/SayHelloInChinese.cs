using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01.HelloAutofac
{
    class SayHelloInChinese : ISayHello, IDisposable
    {
        public void Run()
        {
            Console.WriteLine("哈囉, Autofac!");
        }

        public void Dispose()
        {
            Console.WriteLine("SayHelloInChinese.Dispose()");
        }
    }
}
