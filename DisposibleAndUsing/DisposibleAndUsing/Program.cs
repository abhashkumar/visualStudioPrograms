using System;

namespace DisposibleAndUsing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    class A : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
