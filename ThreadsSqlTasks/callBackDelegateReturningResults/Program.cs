using System;
using System.Threading;

namespace callBackDelegateReturningResults
{
    class Program
    {
        public delegate void returnCallBackDelegate(int number);
        public class Number
        {
            int num;
            returnCallBackDelegate returnCallback;
            public Number(int num, returnCallBackDelegate ret)
            {
                this.num = num;
                this.returnCallback = ret;
            }
            public void add()
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine(this.num + 5);
                this.returnCallback(this.num);
            }
        }
        static void Main(string[] args)
        {
            int num = 110;
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            returnCallBackDelegate returnCallbackDelegate_ = new returnCallBackDelegate(caller);
            Number number_ = new Number(num, returnCallbackDelegate_);
            Thread th = new Thread(number_.add);
            th.Start();
        }
        public static void caller(int result)
        {
            Console.WriteLine($"Inside delegate {result}");
        }
    }
}
