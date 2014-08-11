using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch02.Ex02
{
    class MainApp
    {
        public void Login(string userId, string pwd)
        {
            // 透過 DI 容器解析型別並建立物件。
            var msgService = MyDIContainer.Resolve<IMessageService>();

            var authService = new AuthenticationService(msgService);  // 於建立物件時注入相依性。
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
