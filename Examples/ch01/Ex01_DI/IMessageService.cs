using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch01.Ex01_DI
{
    interface IMessageService
    {
        void Send(User user, string msg);
    }
}
