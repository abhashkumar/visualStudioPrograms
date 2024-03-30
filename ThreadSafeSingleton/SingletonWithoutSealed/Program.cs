using System;

namespace SingletonWithoutSealed
{
    class Singleton
    {
        private static Singleton obj = null;
        private static string value = "p";
        private Singleton()
        {
            value = "inContructor";
            Console.WriteLine("constructor accessed");
        }
        public static Singleton getInstance(string val_)
        {
            if(obj == null)
            {
                obj = new();
                value = val_;
            }
            return obj;
        }
        public void GetValue()
        {
            Console.WriteLine(value);
        }
        public class DerivedSIngleton: Singleton
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // object is obtainded by the public which intern calls the constructor by only once
            Singleton s = Singleton.getInstance("A");
            s.GetValue();
            Singleton s_ = Singleton.getInstance("B");
            s.GetValue();
            Console.WriteLine(s == s_);// Prints True

            // directly accessing constructor due to constructor chaining, multiple times different object can be created 
            Singleton.DerivedSIngleton DS = new Singleton.DerivedSIngleton();
            DS.GetValue();
            s_.GetValue();
            Singleton.DerivedSIngleton DS_ = new Singleton.DerivedSIngleton();
            Console.WriteLine(DS == DS_);// Prints False
        }
    }
}
