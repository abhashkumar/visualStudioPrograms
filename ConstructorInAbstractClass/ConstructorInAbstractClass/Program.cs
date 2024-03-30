using System;
// why constructor in Abstract class: to initilize common variables
// concept of constructor chaining
namespace ConstructorInAbstractClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            B b1 = new B();
            b1.printA_X();

            B b2 = new B(34);
            b2.printA_X();


            b1.printA_X();
        }
    }

    public abstract class A
    {
        private int A_x = 10;
        protected A()
        {
            Console.WriteLine("default constructor of abstract class, A_x = " + A_x);
        }
        protected A(int a_x)
        {
            A_x = a_x;
            Console.WriteLine("In abstract class paarametrized constructor");
        }
        public int getA_X()
        {
            return A_x;
        }
    }

    public class B: A
    {
        public B()
        {
            Console.WriteLine("in subclass constructor");
        }

        public B(int x): base(x)
        {
            Console.WriteLine("in subclass constructor");
        }
        public void printA_X()
        {
            Console.WriteLine(getA_X());
        }
    }
}
