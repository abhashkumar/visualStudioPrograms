using System;

namespace delegates
{
    class Program
    {
        public delegate string greetings(string name);
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
            greetings gd = new greetings(greetingName);
            String x = gd("Abhash");
            Console.WriteLine(x);

            greetings gd1 = delegate(string name)
            {
                Console.WriteLine($"Welcome {name}");
                return name + "##########";
            };
            String y = gd1("Abhash");
            Console.WriteLine(y);

            greetings gd2 = (name) =>
            {
                Console.WriteLine($"Welcome {name} to lambda");
                return name + " lambda";
            };
            string z = gd2("Abhash");
            Console.WriteLine(z);

            Func<string, string> fn = new Func<string, string>(greetingName);
            Console.WriteLine(fn("Abhash"));

            Action<string> ac = new Action<string>((name) => {
                Console.Write($"{name} in Action method");
            });

            Predicate<string> pr = new Predicate<string>((name) =>
            {
                return name.Equals("Abhash");
            });
            Console.WriteLine(pr("Abhash"));
        }
        public static string greetingName(string name)
        {
            Console.WriteLine($"hello {name}");
            return name+"---";
        }
    }
}
