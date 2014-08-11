using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Ch02.Ex01
{
    static class MyDIContainer
    {
        private static Dictionary<string, Type> typeMap; // 用來保存型別對應表

        static MyDIContainer()
        {
            // 建立型別對應表。
            typeMap = new Dictionary<string, Type>();
            typeMap.Add("EmailService", typeof(EmailService));
            typeMap.Add("ShortMessageService", typeof(ShortMessageService));

            // 若往後需要增加其他型別對應，就加在這裡。
        }

        public static object Reslove(string typeName) 
        {
            // 查表，取得型別名稱所對應的型別物件。
            var resolvedType = typeMap[typeName];

            // 利用 reflection 機制來呼叫型別的預設建構函式，以建立物件。
            object instance = Activator.CreateInstance(resolvedType);
            return instance;
        }
    }
}
