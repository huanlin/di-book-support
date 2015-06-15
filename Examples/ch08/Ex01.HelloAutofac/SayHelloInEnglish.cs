using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01.HelloAutofac
{
    class SayHelloInEnglish : ISayHello
    {
        public void Run()
        {
            Console.WriteLine("Hello, Autofac!");
        }
    }
}
