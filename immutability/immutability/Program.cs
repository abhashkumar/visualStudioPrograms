using System.Collections.ObjectModel;
using static System.Console;

namespace immutability
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 6, 3, 4, 8 };
            // if read only collections is a collecton of class object, then the properties of each 
            // object can be changed, unless you make that class itself as immutable
            ReadOnlyCollection<int> rd = new ReadOnlyCollection<int>(arr);
            foreach(var i in rd)
            {
                WriteLine(i);
            }
            WriteLine("Hello World!");
        }
    }
}
