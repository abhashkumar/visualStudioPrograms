using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            A a = new C();
            a.doSomething();
        }
    }

    class A
    {
        public virtual void doSomething()
        {
            Console.WriteLine("test1");
        }
    }
    class B: A
    {
        public override void doSomething()
        {
            Console.WriteLine("test2");
        }

    }
    class C : B
    {
        public new void doSomething()
        {
            Console.WriteLine("test3");
        }
    }
}
