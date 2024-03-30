using System;
using System.Threading;
using System.Diagnostics;
// https://www.learncsharptutorial.com/threadpooling-csharp-example.php
// https://dotnettutorials.net/lesson/constructors-of-thread-class-csharp/
// After using threading namespace we need to call threadpool class
// using threadpool object we need to call method i.e. "QueueUserWorkItem" -
// which Queues function for an execution and a function executes when a thread becomes available from thread pool.
// ThreadPool.QueueUserWorkItem takes overloaded method called waitcallback - Represents a callback function to be executed by a thread pool thread.
// If no thread is available it will wait until one gets freed.

namespace ThreadPol
{
    class ThreadPol
    {
        public delegate int x(int p);
        static void Process(object obj)
        {
            /*
            Console.WriteLine("Inside Process");
            int num = Convert.ToInt32(obj);
            for (int i = 0; i < num; i++)
                Console.WriteLine(i);
            */
        }
        static void ProcessWithThreadMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                // We can also write like new Thread((object p) =>  {Process(p)} )
                // Thread obj = new Thread((object p) => { Process(p); });
                // you can also write 
                //new Thread((Object p) =>  {
                // Console.WriteLine("Inside Process");
                // int num = Convert.ToInt32(obj);
                // for (int i = 0; i < num; i++)
                //    Console.WriteLine(i);
                // });
                //
                // 

                Thread obj = new Thread(Process);
                obj.Start(5);
            }
        }
        static void ProcessWithThreadPoolMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(Process));
            }
        }
        public static void Main(string[] args)
        {
            // This is to understand thread
            Thread.CurrentThread.Name = "currently running thread";
            Console.WriteLine(Thread.CurrentThread.Name);

            // This is to understand threadpooling
            Stopwatch mywatch = new Stopwatch();
            Console.WriteLine("ThreadPool execution start");
            mywatch.Start();
            ProcessWithThreadPoolMethod();
            mywatch.Stop();
            Console.WriteLine($"total time to run {mywatch.ElapsedMilliseconds}");
            mywatch.Reset();
            Console.WriteLine("Thread start");
            mywatch.Start();
            ProcessWithThreadMethod();
            mywatch.Stop();
            Console.WriteLine($" total time to run {mywatch.ElapsedMilliseconds}");
        }
    }
}