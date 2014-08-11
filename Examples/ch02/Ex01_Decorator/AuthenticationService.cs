using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch02.Ex01_Decorator
{
    class AuthenticationService
    {
        private IMessageService msgService;

        public AuthenticationService(IMessageService service)
        {
            this.msgService = service;
        }
        
        public bool TwoFactorLogin(string userId, string pwd)
        {
            // 檢查帳號密碼，若正確，則傳回一個包含使用者資訊的物件。
            User user = CheckPassword(userId, pwd);
            if (user != null)
            {
                // 接著發送驗證碼給使用者，假設隨機產生的驗證碼為 "123456"。
                this.msgService.Send(user, "您的登入驗證碼為 123456");
                return true;
            }
            return false;
        }

        public bool VerifyToken(string token)
        {
            // 檢查驗證碼是否正確 (略).
            return true;
        }


        User CheckPassword(string userId, string pwd)
        {
            var user = new User()
            {
                UserId = userId,
                Email = "mike@ioc.com"
            };
            return user;
        }


    }
}
