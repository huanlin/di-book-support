using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch01.Ex01
{
    class MainApp
    {
        public void Login(string userId, string password)
        {           
            var authService = new AuthenticationService();
            if (authService.TwoFactorLogin(userId, password))  
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
