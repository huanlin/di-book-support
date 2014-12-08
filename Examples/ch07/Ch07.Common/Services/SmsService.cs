using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ch07.Common.Contracts;

namespace Ch07.Common.Services
{
    public class SmsService : IMessageService
    {
        public SmsService()
        {
            Console.WriteLine("SmsMessageService.ctor()");
        }

        public void SendMessage(string to, string msg)
        {
            Console.WriteLine("透過 SmsService 發送簡訊給 {0}。", to);
        }

        public void Dispose()
        {
            Console.WriteLine("Disposing SmsMessageService object.");
        }
    }
}
