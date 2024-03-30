using System;
using System.Collections.Generic;

namespace CustomException
{
    class badEnteredNumer: Exception
    {
        public badEnteredNumer()
        {

        }
        public badEnteredNumer(int number) : base($"invalid number entered:{number}")
        {

        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int number = 70;
            if(number > 50)
            {
                try
                {
                    throw new badEnteredNumer(number);
                }
                catch(badEnteredNumer ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            string s = "abhshKumar";
            Dictionary<char, int> d = new Dictionary<char, int>();
            foreach(char c in s)
            {
                if (d.ContainsKey(c)) d[c] += 1;
                else
                    d.Add(c, 1);
            }
            foreach( var p in d)
            {
                Console.WriteLine(p.Value);
            }
        }
    }
}
