using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ex0_Common.Services
{
    public class HelloService : IHelloService
    {
        public string Hello()
        {
            return "Hello there!";
        }
    }
}