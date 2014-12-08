using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ch07.Common.Contracts
{
    public interface IMessageService : IDisposable
    {
        void SendMessage(string to, string msg);
    }
}
