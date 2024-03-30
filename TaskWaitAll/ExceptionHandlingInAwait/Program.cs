using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Asynchronious
{
    class Test
    {
        public Task ShowAsync()
        {
            return Task.Run(() =>
            {
                try
                {
                    Task.Delay(2000);
                    throw new Exception("My Own Exception");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            });
        }
        public async void Call()
        {
            try
            {
                await ShowAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    class Program
    {
        public static void Main(String[] args)
        {
            Test t = new Test();
            t.Call();
            Console.ReadLine();
        }
    }
}