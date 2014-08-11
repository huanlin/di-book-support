using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Ch02.Patterns
{
    public class PerThreadContext
    {
        // 用一個靜態的 ThreadLocal<T> 來管理各執行緒的 context 物件。
        private static ThreadLocal<PerThreadContext> _threadedContext;

        static PerThreadContext()
        {
            _threadedContext = new ThreadLocal<PerThreadContext>();
        }

        // 共享的狀態
        public DateTime OnceUponATime { get; private set; }

        // 把建構函式宣告為私有，不讓外界任意 context 物件。
        private PerThreadContext()
        {
            OnceUponATime = DateTime.Now;
        }

        public static PerThreadContext Current
        {
            get
            {
                // 如果目前的執行緒中沒有 context 物件...
                if (_threadedContext.IsValueCreated == false)
                {
                    // 就建立一個，並保存至 thread-local storage。
                    _threadedContext.Value = new PerThreadContext();
                    //Console.WriteLine("已建立 context 於執行緒 ID {0}", Thread.CurrentThread.ManagedThreadId);
                }
                return _threadedContext.Value;
            }
        }

    }
}
