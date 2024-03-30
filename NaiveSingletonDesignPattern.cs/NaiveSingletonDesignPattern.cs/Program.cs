using System;

namespace NaiveSingletonDesignPattern.cs
{
    class Singleton
    {
        private static Singleton _instance;
        private Singleton()
        {

        }
        public static Singleton GetInstance()
        {
            if (_instance == null)
                _instance = new();
            return _instance;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Singleton s1 = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();
            if (s1 == s2)
                Console.WriteLine("Both are same objects");
            Console.ReadLine();
        }
    }
}
