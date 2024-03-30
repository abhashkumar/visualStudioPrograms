using System;
using System.Threading;

namespace SemaphoreW
{
    class Program
    {
        static Semaphore _semaphore = new Semaphore(2,2);
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
            _semaphore.WaitOne();
            Console.WriteLine($"Writing... {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(5000);
            Console.WriteLine($"Completed writing...{Thread.CurrentThread.ManagedThreadId}");
            _semaphore.Release();
        }
    }
}
