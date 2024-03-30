using System;
// static constructor does not have any modifier and parameter
// can be used only to initialize static data member
// gets called once at very beginning when the class is referenced or object is created 
namespace StaticConstructor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            A a = new A();
            Console.WriteLine(A.A_x);
            Console.WriteLine(a.B_x);

            // static constructor will not be called here 
            A a2 = new A();
            Console.WriteLine(a2.B_x);
        }
    }


    public class A
    {
        public static int A_x;
        public int B_x;
        static A()
        {
            // static constructor can only initialize static variable
            A_x = 10;
            Console.WriteLine("static constructor A_x = " + A_x);
        }
        public A()
        {
            // non static constructor can initialize static variable 
            A_x = 15;
            B_x = 20;
            Console.WriteLine("default Contructor");
        }
    }
}
