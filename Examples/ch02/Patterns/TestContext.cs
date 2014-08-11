using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ch02.Patterns
{
    public class TestContext
    {
        public static void Run()
        {
            ShowTime();
            System.Threading.Thread.Sleep(2000);
            
            var t1 = new Thread(ShowTime);
            var t2 = new Thread(ShowTime);

            t1.Start();
            System.Threading.Thread.Sleep(2000);
            t2.Start();
            System.Threading.Thread.Sleep(2000);

            ShowTime();

            /*執行結果：
              Thread 1: 2014/5/4 下午 01:37:09
              Thread 3: 2014/5/4 下午 01:37:11
              Thread 4: 2014/5/4 下午 01:37:13
              Thread 1: 2014/5/4 下午 01:37:09
             */
        }

        private static void ShowTime()
        {
            Console.WriteLine("Thread {0}: {1} ",
                Thread.CurrentThread.ManagedThreadId,
                PerThreadContext.Current.OnceUponATime);
        }

    }
}
