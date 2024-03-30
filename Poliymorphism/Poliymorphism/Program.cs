using System;
namespace Polymorphism
{
    class A
    {
        public virtual void Test1() { Console.WriteLine("A1::Test()"); }
        public void Test2() { Console.WriteLine("A2::Test()"); }
    }

    class B : A
    {
        public override void Test1() { Console.WriteLine("B1::Test()"); }
        public new void Test2() { Console.WriteLine("B2::Test()"); }
    }

    class C : B
    {
        public void Test1() { Console.WriteLine("C1::Test()"); }
        public void Test2() { Console.WriteLine("C2::Test()"); }
    }

    class Program
    {
        static void Main(string[] args)
        {

            A a = new A();
            B b = new B();
            C c = new C();

            a.Test1(); 
            b.Test1(); 
            c.Test1(); 

            a = new B();
            a.Test1();
            a.Test2();

            b = new C();
            b.Test1();
            b.Test2();

            Console.ReadKey();
        }
    }
}