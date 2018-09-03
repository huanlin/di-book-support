using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Ch07.Common.Contracts;
using Unity.Attributes;

namespace Ex06.AutoWiring
{
    public class EmailService : IMessageService
    {
        [InjectionConstructor]
        public EmailService()
        {
            Console.WriteLine("EmailMessageService ctor()");
        }

        public EmailService(string smtpHost)
        {
            Console.WriteLine("EmailMessageService ctor(smtpHost)");
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
