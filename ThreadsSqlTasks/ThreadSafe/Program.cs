using System;
using System.Threading;
namespace ThreadSafe
{
    public class Number
    {
        int _number;
        public Number(int  num)
        {
            this._number = num;
        }
        public void AddNumberToGiven()
        {
            Console.WriteLine(this._number);
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Number newNum = new Number(78);
            Thread th = new Thread(newNum.AddNumberToGiven);
            th.Start();
        }
    }
}
