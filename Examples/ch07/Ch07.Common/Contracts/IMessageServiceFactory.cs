using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch07.Common.Contracts
{
    public interface IMessageServiceFactory
    {
        IMessageService GetService();
    }
}
