using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Common.Services
{
    public class MessageService : IMessageService
    {
        public string Hello(string name)
        {
            return "Hello, " + name;
        }
    }
}
