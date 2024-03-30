using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            callMe();
            Console.WriteLine("Finished executing");
            Console.ReadKey();
        }
        public static async void callMe()
        {
            Task<int> t = method1Return();
            method2();
            // int x = await method1Return();
            // If I use t.result rather then t, it actually waits the callme fucntion to finish
            // but await does not wait, look how line 12 prints in csse of result and in case of await
            int x = t.Result;
            method3(x);
        }
        public static void method3(int x)
        {
            Console.WriteLine(x);
        }
        public static async Task method1()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    Console.WriteLine($"method 1 {i}");
                    Task.Delay(100).Wait();
                }
            });
        }
        public  static void method2()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"method 2 {i}");
                Task.Delay(100);
            }
        }
        public static async Task<int> method1Return()
        {
            int count = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    Console.WriteLine($"methodReturn 1 {i}");
                    count += 1;
                    Task.Delay(100).Wait();
                }
            });
            return count;
        }
    }
}
