using System;
using System.Threading;

namespace ManualResetEventW
{
    class Program
    {
        static ManualResetEvent _mre = new ManualResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new Thread(Write).Start();
            for(int i = 0; i < 5;i++)
            {
                new Thread(Read).Start();
            }
        }
        public static void Write()
        {
            Console.WriteLine("started writing...");
            _mre.Reset();
            Thread.Sleep(5000);
            Console.WriteLine("Completed writing...");
            _mre.Set();
        }
        public static void Read()
        {
            Console.WriteLine("waiting...");
            // will release all the waiting thread here
            _mre.WaitOne();
            Console.WriteLine("Reading...");
        }
    }
}
