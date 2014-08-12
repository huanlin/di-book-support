using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch03.Common.Logging
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
