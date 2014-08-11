using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch01
{
    class Program
    {   
        static void Main(string[] args)
        {
            #region Ex01 非 DI 版本
            /*
            var demo1 = new Ex01.MainApp();
            demo1.Login("michael", "1234");            
             */
            #endregion

            #region Ex01 略有 DI 味道的版本
            var demo = new Ex01_DI.MainApp();
            demo.Login("michael", "1234", "ShortMessageService");
            #endregion
        }
    }
}
