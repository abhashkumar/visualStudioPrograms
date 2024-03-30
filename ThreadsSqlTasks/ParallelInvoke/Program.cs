using System;
using System.Threading.Tasks;
using System.Threading;
namespace ParallelInvoke
{
    class Program
    {
        static void Main(string[] args)
        {
            ParallelOptions parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = 3
            };

            Parallel.Invoke(parallelOptions,
                            NormalAction,
                            delegate()
                            {
                                Console.WriteLine($"Inside inline Delegate{Thread.CurrentThread.ManagedThreadId}");
                            },
                            () =>
                            {
                                Console.WriteLine($"Inside Anonymious function{Thread.CurrentThread.ManagedThreadId}");
                            }
                );
        }
        static void NormalAction()
        {
            Thread.Sleep(2000);
            Console.WriteLine($"Normal Action{Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
