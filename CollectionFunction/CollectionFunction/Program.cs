using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CollectionFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("Hello World!");
            string t1 = "plus";
            string t2 = t1;
            t1 = t1 + "minus";
            Console.WriteLine(t1);
            Console.WriteLine(t2);

            List<int> l = new List<int>();
            int p = l.Count;
            int max = Math.Max(4, 5);
            HashSet<int> hs = new HashSet<int>();
            StringBuilder sb = new StringBuilder();

            Dictionary<int, int> hs1 = new Dictionary<int, int>();
            Console.WriteLine(-50 % 8);
            int[] array_ = new int[5];
            foreach(int i in array_)
            {

            }
            //List<int> l = new List<int>();
            //Array.ForEach(digits, p => l.Add(p));
            //Array.Fill(leftArray, 1);
            //HashSet<int> hs = new HashSet<int>();
            //foreach(int i in hs)
            //{
            //    hs.Remove(i);
            //}
            string a1 = "Level 1";
            string a2 = "Level 2";
            Console.WriteLine(string.Compare(a2, a1));
            try
            {
                int[] array = new int[3];
                array[3] = 3;
                Console.Write("A");
            }
            catch (IndexOutOfRangeException)
            {
                Console.Write("B");
            }
            Console.Write("C");
            String s = "Hello\0world";
            Console.WriteLine(s.Length);
            String s1 = "42", s3 ="43";
            testFunc(ref s1, out s3);
            Console.WriteLine($"{s1 + s3}");

            */
            List<int> l = new List<int>();
            l.Add(1);
            l.Add(1);
            l.Add(2);
            l.Add(3);

            var p = l.FirstOrDefault((x) => x == 5);
            Console.WriteLine(p);

            // An error will be thrown more then one matching element
            // var q = l.SingleOrDefault((x) => x == 1);
            // Console.Write(q);


             var q = l.SingleOrDefault((x) => x == 5);
             Console.Write(q);
        }
        public static void testFunc(ref string s1, out string s3)
        {
            s1 += "0";
            s3 = "0";
            
        }
    }
}
