using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ch07.Common.Contracts;
using Ch07.Common.Services;

namespace Ex10.CustomFactory
{
    class MessageServiceFactory : IMessageServiceFactory
    {
        public IMessageService GetService()
        {
            if (UsingEmail())
            {
                return new EmailService();
            }
            else
            {
                return new SmsService();
            }
        }

        private bool UsingEmail()
        {
            return false;
        }
    }
}
