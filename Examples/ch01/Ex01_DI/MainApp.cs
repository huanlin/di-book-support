using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch01.Ex01_DI
{
    class MainApp
    {
        public void Login(string userId, string pwd, string messageServiceType) 
        {
            IMessageService msgService = null;
            switch (messageServiceType)
            {
                case "EmailService":
                    msgService = new EmailService();
                    break;
                case "ShortMessageService":
                    msgService = new ShortMessageService();
                    break;
                default:
                    throw new ArgumentException("Unknown message service type!");
            }

            var authService = new AuthenticationService(msgService);  // 於建立物件時注入相依性
            if (authService.TwoFactorLogin(userId, pwd))  
            {
                // 請使用者收信，然後回來輸入信中提示的驗證碼。
                string userInputToken = "123456";
                if (authService.VerifyToken(userInputToken))
                {
                    // 登入成功。
                }
            }
            // 登入失敗。
        }
    }
}
