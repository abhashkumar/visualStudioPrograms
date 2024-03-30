using System;

namespace InbuiltEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            publisher pb = new publisher();
            new Subscriber1(pb);
            new Subscriber2(pb);
            pb.startProcess();
        }
    }
    public class publisher
    {
        public event EventHandler event1;
        public void startProcess()
        {
            Console.WriteLine("Starting process");
            Onevent1(EventArgs.Empty);
        }
        public virtual void Onevent1(EventArgs e)
        {
            event1?.Invoke(this, e);
        }
    }
    class Subscriber1
    {
        public Subscriber1(publisher pb)
        {
            pb.event1 += subscriberFunc1;
        }
        public static void subscriberFunc1(object sender, EventArgs e)
        {
            Console.WriteLine("subscriberFunc1");
        }
    }
    class Subscriber2
    {
        public Subscriber2(publisher pb)
        {
            pb.event1 += subscriberFunc2;
        }
        public static void subscriberFunc2(object sender, EventArgs e)
        {
            Console.WriteLine("subscriberFunc2");
        }
    }
}
