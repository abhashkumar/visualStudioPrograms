using System;

namespace string_Permutation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string s = "ABCD";
            new Program().permute(s, "");
        }
        public void permute(string s, string answer) {
            if(s.Length == 0)
            {
                Console.WriteLine(answer);
                return;
            }
            for(int i = 0; i < s.Length; i++)
            {
                string pans = answer + s[i];
                string rem =  s.Remove(i, 1);
                permute(rem, pans);
            }
        }
    }
}
