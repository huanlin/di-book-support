using System;
using System.Linq;
using Unity;
using Unity.RegistrationByConvention;
using Ch07.Common.Contracts;

namespace Ex04.AutoRegistration
{
    static class Program
    {
        static void Main(string[] args)
        {
            AutoRegisterationDemo();
        }

        static void AutoRegisterationDemo()
        {
            Console.WriteLine("\n<<< AutoRegisterDemo >>>");

            // 設定 Unity 容器：自動註冊型別
            var container = new UnityContainer();
            var classes = from t in AllClasses.FromLoadedAssemblies()
                          where t.Name.IndexOf("Service") > 0
                          select t;

            container.RegisterTypes(
                classes,  // 掃描目前已經載入此應用程式的全部組件。
                WithMappings.FromAllInterfaces,    // 尋找所有介面。
                getName: WithName.TypeName,
                overwriteExistingMappings: false);

            // 解析物件
            var msgService = container.Resolve<IMessageService>("EmailService");
            msgService.SendMessage("Michael", "Hello!");
        }

    }
}
