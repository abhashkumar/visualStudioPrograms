using System;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string p = "";
            int x = 5;

            string s = "*";
            for (int i = 1; i < x; i++ )
            {
                Console.WriteLine(s);
                s += "*";   
            }

        }
    }
}

/*
*
* *
* * *
* * * *
*/