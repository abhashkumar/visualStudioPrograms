using System;

namespace ConsoleApp5
{
    public class A
    {
        public int x = 8;
        protected int y = 56;
        private int p  = 89;
    }
    public class B : A
    {
    }
    public class C : B
    {

    }

    public class D : C
    {
        public void man()
        {
            D d_ = new D();
            Console.WriteLine(d_.y);
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new D().man();
            Console.WriteLine(new D().x);
        }
    }

}
