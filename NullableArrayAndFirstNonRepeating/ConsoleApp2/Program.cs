using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string s1 = "aab";
            string s2 = "aaa";
            String s3 = "alphabet";
            Console.WriteLine(FindNonRepeatingv1(s1));
            Console.WriteLine(FindNonRepeatingv1(s2));
            Console.WriteLine(FindNonRepeatingv1(s3));
        }
        public static int firstNoneRepeating(string s)
        {
            int index = int.MaxValue;
            Dictionary<char, int> dt = new Dictionary<char, int>();
            for(int i = 0; i < s.Length; i++)
            {
                if (!dt.ContainsKey(s[i]))
                {
                    dt.Add(s[i], i);
                }
                else
                {
                    dt[s[i]] = int.MaxValue;
                }
            }
            foreach(var k in dt)
            {
                if (k.Value < index)
                    index = k.Value;
            }
            return index == int.MaxValue ? -1 : index;
        }
        public static int FindNonRepeatingv1(string s)
        {
            Dictionary<char, int> dt = new Dictionary<char, int>();
            for(int i = 0;i < s.Length;i++)
            {
                if (!dt.ContainsKey(s[i]))
                {
                    dt.Add(s[i], 1);
                }
                else
                {
                    dt[s[i]] += 1;
                }
            }
            int index = -1;
            for(int i = 0;i < s.Length;i++)
            {
                if (dt[s[i]] == 1)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }
}
