using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionNetCore
{
    public interface IHelloWorldService
    {
        public int GetStringLength();
    }
    public class serviceXelo : IHelloWorldService
    {
        public int GetStringLength()
        {
            return "HelloWorldLength".Length;
        }
    }
}
