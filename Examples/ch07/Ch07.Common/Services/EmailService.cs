using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ch07.Common.Contracts;

namespace Ch07.Common.Services
{
    public class EmailService : IMessageService
    {
        public EmailService()
        {
            Console.WriteLine("EmailMessageService ctor()");
        }

        public void SendMessage(string to, string msg)
        {
            Console.WriteLine("透過 EmailMessageService 發送郵件給 {0}。", to); 
        }

        public void Dispose()
        {
            Console.WriteLine("Disposing EmailMessageService object.");
        }
    }
}
