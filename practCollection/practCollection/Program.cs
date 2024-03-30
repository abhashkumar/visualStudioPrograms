using System;
using System.Collections;
using System.Collections.Generic;

namespace practCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue to = new Queue();
            to.Enqueue(7);
            to.Enqueue("xcv");
            Queue<int> numbers = new Queue<int>();
            numbers.Enqueue(19);
            numbers.Enqueue(12);
            numbers.Enqueue(31);

            IEnumerator<int> q;
            q = numbers.GetEnumerator();
            while (q.MoveNext())
            {
                Console.WriteLine(q.Current);
            }
            int[] x = new int[5] { 4,3,2,1,5};
            foreach(int i in x)
            {
                Console.WriteLine(i);
            }
            x = new int[8];
            foreach (int i in x)
            {
                Console.WriteLine(i);
            }
            int[] y = { 6, 3, 9, 7, 4 };
            foreach (int i in y)
            {
                Console.WriteLine(i);
            }
            SortedList s = new SortedList();
            s.Add(1, "p");
            s.Add(0, "w");
            s.Add(-1, "y");
            s.Add(2, "x");
            foreach(DictionaryEntry p in s)
            {
                Console.WriteLine($"{p.Key} {p.Value}");
            }
            SortedList<string, string> sq = new SortedList<string, string>();
            sq.Add("1", "p");
            sq.Add("0", "w");
            sq.Add("-1", "y");
            sq.Add("2", "x");
            Console.WriteLine($"testing with index and key: {sq["0"]}");
            foreach (KeyValuePair<string, string> p in sq)
            {
                Console.WriteLine($"{p.Key} {p.Value}");
            }
        }

    }
}
