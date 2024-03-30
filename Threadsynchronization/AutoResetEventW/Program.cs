using System;
using System.Threading;

namespace AutoResetEventW
{
    class Program
    {
        static AutoResetEvent _are = new AutoResetEvent(true);
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
            _are.WaitOne();
            Console.WriteLine($"Writing... {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(5000);
            Console.WriteLine("Completed writing...");
            _are.Set();
        }
    }
}
