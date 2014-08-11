using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch02.Ex02
{
    interface IMessageService
    {
        void Send(User user, string msg);
    }
}
