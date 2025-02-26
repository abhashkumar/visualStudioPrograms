using System;
using System.Threading.Tasks;
using System.Threading;

namespace AsynCawait
{
    class Program
    {
        // https://www.fatalerrors.org/a/thread-task-asyncawait-iasyncresult.html
        static void Main(string[] args)
        {
            Console.WriteLine("-------Main thread start-------");
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Task<int> task = GetStrLengthAsync();
            Console.WriteLine("Main thread continues to execute");
            Console.WriteLine("Task Return value" + task.Result);
            Console.WriteLine("-------End of the main thread-------");
        }

        static async Task<int> GetStrLengthAsync()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("GetStrLengthAsync Method begins execution");
            //Returned <string> String type, not Task<string>
            string str = await GetString();
            Console.WriteLine("GetStrLengthAsync Method execution ends");
            return str.Length;
        }

        static Task<string> GetString()
        {
            //Console.WriteLine("GetString Method begins execution")
            return Task<string>.Run(() =>
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(2000);
                return "GetString Return value";
            });
        }
    }
}
