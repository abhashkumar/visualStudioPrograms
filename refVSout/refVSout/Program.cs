using System;
using System.Security.Cryptography.X509Certificates;

namespace refVSout
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Product p1 = new Product(8, 9);
            Product p2 = new Product(18, 19);
            Product p3 = new Product(90, 90);

            CheckChange1(ref p1);
            CheckChange2(p2);
            CheckChange3(p3);
            Console.WriteLine($"{p1.x},{p1.y}");
            Console.WriteLine($"{p2.x},{p2.y}");
            Console.WriteLine($"{p3.x},{p3.y}");
            int x = 5;
            Console.WriteLine(Add10(ref x));
            int y;
            Add20(out y);
            Console.WriteLine(y);

        }
        public static void CheckChange1(ref Product p)
        {
            // it will change the object itself
            p = new Product(78, 88);
        }
        public static void CheckChange2(Product p)
        {
            // no change in the original objectt, new object gets created
            p = new Product(88, 90);
        }
        public static void CheckChange3(Product p)
        {
            // object is change here will reflected in the original object 
            p.x = 60;
            p.y = 60;
        }

        // ref has to initialised before calling
        public static int Add10(ref int x)
        {
            return x + 10;
        }

        // out variable has to be initialzed inside the call
        public static void Add20(out int y)
        {
            y = 10;
            y += 20;
        }

    }

    class Product
    {
        public int x;
        public int y;
        public Product(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

}
