using System;
using System.Threading;

namespace MutexW
{
    class Program
    {
        static Mutex _mutex = new Mutex();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            for (int i = 0; i < 5; i++)
            {
                new Thread(Write).Start();
            }
        }
        public static void Write()
        {
            Console.WriteLine($"waiting...{Thread.CurrentThread.ManagedThreadId}");
            _mutex.WaitOne();
            Console.WriteLine($"Writing... {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(5000);
            Console.WriteLine($"Completed writing...{Thread.CurrentThread.ManagedThreadId}");
            _mutex.ReleaseMutex();
        }
    }
}
