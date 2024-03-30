using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace stringFunctions
{
    public class Program
    {
        static void Main(string[] args)
        {
            string s = "madam";
            string result = "";
            
            Dictionary<char, bool> d = new Dictionary<char, bool>();

            foreach(var c in s)
            {
                if(!d.ContainsKey(c))
                {
                    result += c;
                    d[c] = true;
                }
            }
            Console.WriteLine(result);

            Dictionary<char, int> count = new Dictionary<char, int>();

            foreach(var c in s)
            {
                if (count.ContainsKey(c))
                {
                    count[c]++;
                }
                else
                {
                    count[c] = 1;
                }
            }
            string result2 = "";
            foreach(var c in s)
            {
                if (count[c] < 2)
                    result2 += c;
            }
            Console.WriteLine(result2);

            var x = s.Distinct().ToArray();

            string res = new string(x);

            Console.WriteLine(res);

            var x1 = s.Where(c => s.IndexOf(c) == s.LastIndexOf(c)).ToArray();
            Console.WriteLine(new String(x1));

            var p = s.Where(c => s.Where(x => x == c).Count() < 2).ToArray();
            Console.WriteLine(new String(p));


            var counter = s.Select(c => new
            {
                character = c,
                count = s.Where(x => x == c).Count(),
            }).Distinct().ToArray().ToDictionary(x => x.character, x => x.count);

            

        }

    }
}
