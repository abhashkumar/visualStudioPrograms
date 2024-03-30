using System;
using System.Threading.Tasks;
namespace returnResultFromTask
{
    public class Employee
    {
        public int id;
        public string name;
        public Employee(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int k = 9;
            Task<int> task1 = Task.Run(() => { 
               return  increment(9); 
           });
            Task<Employee> task2 = Task.Factory.StartNew(() =>
           {
               return new Employee(1, "Abhash");
           });
            Console.WriteLine(task1.Result);
            Employee emp = task2.Result;
            Console.WriteLine($"{emp.id}, {emp.name}");
            Console.WriteLine("mAin thread end");
        }

        public static int increment(int num)
        {
            Console.WriteLine("Child thread processing");
            return ++num;
        }
    }
}
