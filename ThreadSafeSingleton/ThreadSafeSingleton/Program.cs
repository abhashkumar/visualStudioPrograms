using System;
using System.Threading;

namespace ThreadSafeSingleton
{
    sealed class ThreadSafeSingleton
    {
        private static ThreadSafeSingleton _instance;
        private ThreadSafeSingleton() { }
        private static readonly object _lock = new();
        public static ThreadSafeSingleton GetInstance(string value)
        {
            lock (_lock)
            {
                if(_instance == null)
                {
                    _instance = new();
                    _instance.Value = value;
                }
            }
            return _instance;
        }
        public string Value { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Thread th1 = new Thread(() => { TestSingleton("Foo"); });
            Thread th2 = new(() => { TestSingleton("Bar"); });
            th1.Start();
            th2.Start();
            th1.Join();
            th2.Join();
        }
        public static void TestSingleton(string value)
        {
            ThreadSafeSingleton s1 = ThreadSafeSingleton.GetInstance(value);
            Console.WriteLine(s1.Value);
        }
    }
}
