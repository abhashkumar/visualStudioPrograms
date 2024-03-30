using System;
using System.Collections.Generic;
using System.Linq;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new DataStore<int, string>().Printer(5, "tester");
            new DataStore<bool, decimal>().Printer(false, (decimal)45.90);
            new DataStore().Printer<string>("Thor");
            new DataStore().Printer<int>(78);
            int[] data = { 4, 8, 1, 2, 45, 6 };
            new DataStore().SortThings<int>(data);
            String[] data2 = { "Bill", "Gill", "Aill", "sill", "pill" };
            new DataStore().SortThings<String>(data2);
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
            foreach (var item in data2)
            {
                Console.WriteLine(item);
            }
            data2 = new string[]{ "Bill", "Gill", "Aill", "sill", "pill" };
            new DataStore<string>().SortThings(data2);
            foreach (var item in data2)
            {
                Console.WriteLine(item);
            }
        }
    }
    class DataStore<T, U> { 
        public void Printer(T data1, U data2)
        {
            Console.WriteLine(data1);
            Console.WriteLine(data2);
        }
    }

    class DataStore
    {
        public void Printer<T>(T data)
        {
            Console.WriteLine(data);
        }
        public x[] SortThings<x>(x[] data)
        {
            Array.Sort(data);
            List<int> l = new List<int>();
            return data;
        }
    }

    class DataStore<T>
    {
        public void Printer(T data)
        {
            Console.WriteLine(data);
        }
        public T[] SortThings(T[] data)
        {
            // We dont need to return anything because sort is an inplace, returned just for learning purpose
            Array.Sort(data);
            List<int> l = new List<int>();
            return data;
        }
    }
}
