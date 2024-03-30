using System;
using System.Threading.Tasks;

namespace multipleAwaits
{
    class Program
    {
        static  async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            await publish1();
            Console.WriteLine("tester1");
            Console.WriteLine("tester2");
            await publish2();
            Console.WriteLine("*************");
            Console.ReadKey();

        }

        public static async Task publish1()
        {
            await Task.Delay(5000);
            Console.WriteLine("inside publish1");
        }

        public static async Task publish2()
        {
            await Task.Delay(100);
            Console.WriteLine("inside publish2");
        }
    }
}
