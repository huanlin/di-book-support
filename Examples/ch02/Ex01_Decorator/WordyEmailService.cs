using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ch02.Ex01_Decorator
{
    class WordyEmailService : IMessageService
    {
        private IMessageService msgService;

        // 從建構函式串接（注入）相同介面的物件。
        public WordyEmailService(IMessageService service)
        {
            this.msgService = service;
        }

        // 實作 IMessageService.Send 方法。
        public void Send(User user, string msg)
        {
            msg += "\r\n此信件為系統自動發送，請勿回信。";
            this.msgService.Send(user, msg);
        }
    }
}
