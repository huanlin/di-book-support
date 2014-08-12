using Ch03.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch03.Common.Services
{
    public class EmailService : IMessageService
    {
        public void Send(User user, string msg)
        {            
            // 寄送電子郵件給指定的 user (略)
            Console.WriteLine("寄送電子郵件給使用者，訊息內容：" + msg);
        }
    }
}
