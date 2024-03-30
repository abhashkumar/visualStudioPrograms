using System;

namespace ConsoleApp3
{
    class singleton
    {

        singleton s = null;
        private singleton()
        {
            if (s == null)
            {
                s = new singleton();
            }
        }
        private int name { get; set; }
        public void name_()
        {
            Console.WriteLine(this.name);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
