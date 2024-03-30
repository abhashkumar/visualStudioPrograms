using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace standardVsParallelFor
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Array = { 40, 50, 60, 70, 80, 90 };
            //for(int i = 0; i < 10;i++)
            //{
            //    Console.WriteLine(i);
            //    Thread.Sleep(2000);
            //}
            //Parallel.For(0, 10, (count) =>
            //{
            //    Console.WriteLine(count);
            //    Thread.Sleep(2000);
            //});
            Parallel.For(0, Array.Length, (i) => 
            {
                Console.WriteLine(i);
                Array[i] = Array[i] + 5;
            });
            Console.WriteLine("########################");
            foreach(int i in Array)
            {
                Console.WriteLine(i);
            }
            int[] pArray = Enumerable.Range(5, 50).ToArray();
            Parallel.ForEach(pArray, i => {
                Console.WriteLine(i);
            });
        }
    }
}
