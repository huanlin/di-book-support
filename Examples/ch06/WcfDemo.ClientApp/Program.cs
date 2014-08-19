using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfDemo.ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceUnity = new WcfDemoService_Unity.Service1Client();
            Console.WriteLine(serviceUnity.Hello());

            var serviceAutofac = new WcfDemoService_Autofac.Service1Client();
            Console.WriteLine(serviceAutofac.Hello());

            Console.WriteLine("程式執行完畢，按 Enter 鍵結束。");
            Console.ReadLine();
        }
    }
}
