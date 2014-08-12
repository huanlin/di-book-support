using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ch03.Common.Services;

namespace Ch03.MyDIContainerV1
{
    class Program
    {
        static void Main(string[] args)
        {
            string userId = "michael";
            string password = "1234";
            string messageServiceType = "EmailService";

            var app = new MainApp();
            app.Login(userId, password, messageServiceType);
        }
    }

    public class MainApp
    {
        public void Login(string userId, string pwd, string messageServiceType)
        {
            IMessageService msgService = null;

            // 用字串比對的方式來決定該建立哪一種訊息服務物件。
            switch (messageServiceType)
            {
                case "EmailService":
                    msgService = new EmailService();
                    break;
                case "ShortMessageService":
                    msgService = new ShortMessageService();
                    break;
                default:
                    throw new ArgumentException(" 無效的訊息服務型別!");
            }
            var authService = new AuthenticationService(msgService); // 注入相依物件。
            if (authService.TwoFactorLogin(userId, pwd))
            {
                // 與主題無關，故省略。
            }
        }
    }
}
