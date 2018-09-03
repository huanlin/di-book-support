using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Unity;

namespace Ex01.HelloUnity
{
    class Program
    {
        static void Main(string[] args)
        {
            // (1) 建立 Unity 容器。
            IUnityContainer container = new UnityContainer();

            // (2) 向 Unity 容器註冊型別。
            container.RegisterType<ISayHello, SayHelloInEnglish>();

            // (3) 在程式某處，要求解析型別，以取得元件的執行個體。
            ISayHello hello = container.Resolve<ISayHello>();

            // (4) 呼叫元件的方法。
            hello.Run();

            Console.ReadKey(); // 等待按任意鍵結束程式。
        }
    }
}
