using System;

namespace dynamicType
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            byte b = 5;
            dynamic a = b;
            Console.WriteLine(a.GetType());
            a += 100;
            Console.WriteLine(a.GetType());

            // once assigned an intiger in p its type can be changed, type known and fixed in compile time unlike dynamic type known in runtime and type casn be changed 
            var p = 15;
            Console.WriteLine(p.GetType());

        }
    }
}
