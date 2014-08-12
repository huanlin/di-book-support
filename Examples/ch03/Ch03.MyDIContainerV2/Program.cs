using Ch03.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch03.MyDIContainerV2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 向 DI 容器註冊型別對應。
            MyDIContainer.Register<IMessageService, ShortMessageService>();

            var app = new MainApp();
            app.Login("michael", "1234");
        }
    }

    class MainApp
    {
        public void Login(string userId, string pwd)
        {
            var msgService = MyDIContainer.Resolve<IMessageService>();
            var authService = new AuthenticationService(msgService); // 注入相依物件。
            if (authService.TwoFactorLogin(userId, pwd))
            {
                // 與主題無關，故省略。
            }
        }
    }
}
