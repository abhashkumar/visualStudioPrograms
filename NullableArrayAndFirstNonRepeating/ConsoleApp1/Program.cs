using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int?[] arr =  { null, null, 2, 3, null, null,5, null }; 
            if(arr.Length > 0)
            {
                if(arr[0] == null)
                {
                    for(int i = arr.Length - 1; i > 0; i--)
                    {
                        if(arr[i] != null)
                        {
                            arr[0] = arr[i];
                            break;
                        }
                    }
                }
                for(int i = 1; i < arr.Length; i++)
                {
                    if (arr[i] == null)
                        arr[i] = arr[i - 1];
                }
            }
            foreach(int i in arr)
            {
                Console.WriteLine(i);
            }
        }
    }
}
