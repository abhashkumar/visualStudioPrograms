using System;

namespace DependencyInjection
{
    public interface IService
    {
        public int GetDefValueLen();
    }
    class Client
    {
        private IService _service;
        public Client(IService service)
        {
            _service = service;
        }
        public int GetResultantValue()
        {
            return this._service.GetDefValueLen();
        }
    }
    class Service1:IService
    {
        public int GetDefValueLen()
        {
            return this.GetRestingValue();
        }

        public int GetRestingValue()
        {
            return ("Resting").Length;
        }
    }
    class Service2 : IService
    {
        public int GetDefValueLen()
        {
            return this.GetJestValue();
        }

        public int GetJestValue()
        {
            return ("Jest").Length;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Client cl1 = new Client(new Service1());
            Console.WriteLine(cl1.GetResultantValue());
            Client cl2 = new Client(new Service2());
            Console.WriteLine(cl2.GetResultantValue());
        }
    }
}
