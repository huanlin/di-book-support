using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ch07.Common.Contracts;

namespace Ch07.Common.Services
{
    public class HelloService : IHelloService
    {
        public string Hello(string name)
        {
            return "Hello, " + name;
        }
    }
}
