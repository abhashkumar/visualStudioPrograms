using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskWaitAll
{
    class Program
    {
        public static List<Task> taskList = new List<Task>();
        static void Main(string[] args)
        {
            List<int> l = Enumerable.Range(1, 10000).ToList();
            foreach (int i in l)
            {
                taskList.Add(publish(i));
            }
            Task.WaitAll(taskList.ToArray());
            Console.Write("Finish all tasks");
            Task<int> t1 = new Task<int>(() => publishNUm(9));
            t1.Start();
            Console.WriteLine(t1.Result);
            var p =  publishNUm2(5);
            Console.WriteLine(p);
            Console.WriteLine("finished waiting");
        }
        public static async Task  publish(int x)
        {
            Console.WriteLine("before --------------");
            await Task.Delay(100);
            Console.WriteLine($"Publisdhed {x}---------");
        }
        public static int publishNUm(int x)
        {
            Console.WriteLine($"number = {x}");
            return x + 5;
        }
        public static int publishNUm2(int x)
        {
            Console.WriteLine($"number = {x}");
            Task.Delay(5000).Wait();
            return Task.Run<int>(() => x + 5).Result;
        }
    }
}
