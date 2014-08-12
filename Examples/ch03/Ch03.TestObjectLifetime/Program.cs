using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch03.TestObjectLifetime
{
    class Program
    {
        static void Main(string[] args)
        {
            // 預設情形下，Unity 不會保存相依物件的參考，而無人參考的物件會由 CLR 會自動釋放，
            // 故以下測試不會出現記憶體耗盡的問題。
            //new TestUnity().Run();

            // 預設情形下，Autofac 會自動管理 disposable 物件，導致以下測試出現記憶體耗盡的錯誤。
            new TestAutofac().Run();

            Console.ReadLine();
        }
    }
}
