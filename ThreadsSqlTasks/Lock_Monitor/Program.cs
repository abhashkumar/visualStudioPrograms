using System;
using System.Threading;

namespace Lock_Monitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Thread th1 = new Thread(displayResults);
            Thread th2 = new Thread(displayResults);
            Thread th3 = new Thread(displayResults);
            th1.Start();
            th2.Start();
            th3.Start();
        }
        private static object _lockObject = new object();
        public static void displayResults()
        {
            /*
            Console.WriteLine("displaying resuts:1");
            Thread.Sleep(100);
            Console.WriteLine("displaying results:2");
            */
            lock(_lockObject)
            {
                Console.WriteLine("displaying resuts:1");
                Thread.Sleep(100);
                Console.WriteLine("displaying results:2");
            }
        }
    }
}
