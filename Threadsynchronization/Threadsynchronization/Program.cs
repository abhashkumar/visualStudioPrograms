using System;
using System.Threading;

namespace Threadsynchronization
{
    class Program
    {
        private static readonly object lockObj = new object();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            for(int i = 0;i < 4; i++)
            {
                //new Thread(DoWorkLock).Start();
                new Thread(DoWorkMonitor).Start();
            }
            Console.ReadKey();
        }
        public static void DoWorkLock()
        {
            lock (lockObj)
            {
                Console.WriteLine($"starting work...{Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(2000);
                Console.WriteLine($"completed {Thread.CurrentThread.ManagedThreadId}");
            }
        }
        public static void DoWorkMonitor()
        {
            //Monitor.Enter(lockObj);
            //Console.WriteLine($"starting work...{Thread.CurrentThread.ManagedThreadId}");
            //Thread.Sleep(2000);
            //Console.WriteLine($"completed {Thread.CurrentThread.ManagedThreadId}");
            //Monitor.Exit(lockObj);
            try
            {
                Monitor.Enter(lockObj);
                Console.WriteLine($"starting work...{Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(2000);
                throw new Exception();
                Console.WriteLine($"completed {Thread.CurrentThread.ManagedThreadId}");
            }
            catch(Exception ex)
            {
                Console.WriteLine("exception occured: " + ex.StackTrace);
            }
            finally
            {
                Monitor.Exit(lockObj);
            }
        }
    }
}
