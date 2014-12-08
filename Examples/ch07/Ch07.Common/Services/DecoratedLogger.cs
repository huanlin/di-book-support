using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ch07.Common.Contracts;

namespace Ch07.Common.Services
{
    public class DecoratedLogger : ILogger
    {
        private ILogger _logger;

        public DecoratedLogger(ILogger logger)
        {
            _logger = logger;
        }

        public void Log(string msg)
        {
            _logger.Log(DateTime.Now.ToString() + " - " + msg);
        }
    }
}
