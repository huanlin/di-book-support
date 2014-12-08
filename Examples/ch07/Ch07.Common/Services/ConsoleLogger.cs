using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ch07.Common.Contracts;

namespace Ch07.Common.Services
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
