using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public interface DbSpecific
    {
        public void logDB();
    }
    public class DbFIle : DbSpecific, ExampleLogger
    {
        public void log()
        {
            Console.WriteLine("log test");
        }

        public void logDB()
        {
            Console.Write("log DB test");
        }
    }
}
