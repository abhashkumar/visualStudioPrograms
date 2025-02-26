using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            A a0 = new A();
            a0.doSomething();   
            A a1 = new B();
            a1.doSomething();
            A a2 = new C();
            a2.doSomething();
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
