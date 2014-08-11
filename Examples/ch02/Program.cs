using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ch02
{
    class Program
    {
        static void Main(string[] args)
        {
            LoginDemo1();

            LoginDemo2();

            Console.WriteLine("<<< Ambient Context 範例 >>>");
            Patterns.TestContext.Run();
        }

        static void LoginDemo1()
        {
            Console.WriteLine("<<< Ex01 >>>");

            var demo = new Ex01.MainApp();
            demo.Login("michael", "1234", "ShortMessageService");

            Console.WriteLine("");
        }

        static void LoginDemo2()
        {
            Console.WriteLine("<<< Ex02 >>>");

            // 向 DI 容器註冊型別對應。
            Ex02.MyDIContainer.Register<Ex02.IMessageService, Ex02.ShortMessageService>();

            var app = new Ex02.MainApp();
            app.Login("michael", "1234");

            Console.WriteLine("");
        }
    }
}
