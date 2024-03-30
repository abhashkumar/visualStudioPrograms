using System;
using System.Linq;
using System.Text.Json;
using System.Threading;

namespace ParallelLinq
{
    /*
     * Parallel LINQ (PLINQ) is basically the same as we have in LINQ. But with parallel functionality, 
     * we can define the maximum degree of parallelism and we can also use a cancellation token to cancel the operation and so on.
     * 
     * 
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var cities = new[] {
                new City { Id = 1,  CityName = "Turku"  , Country = "Finland" },
                new City { Id = 2,  CityName = "Paris"  , Country = "France" },
                new City { Id = 3,  CityName = "Oslo"    ,  Country = "Norway" } ,
                new City { Id = 4,  CityName = "Helsinki"     , Country = "Finland" },

                new City { Id = 5,  CityName = "Turku"  , Country = "Finland" },
                new City { Id = 6,  CityName = "Paris"  , Country = "France" },
                new City { Id = 7,  CityName = "Oslo"    ,  Country = "Norway" } ,
                new City { Id = 8,  CityName = "Helsinki"     , Country = "Finland" } ,

                new City { Id = 9,  CityName = "Turku"  , Country = "Finland" },
                new City { Id = 10,  CityName = "Paris"  , Country = "France" },
                new City { Id = 11,  CityName = "Oslo"    ,  Country = "Norway" } ,
                new City { Id = 12,  CityName = "Helsinki"     , Country = "Finland"},

                new City { Id = 13,  CityName = "Turku"  , Country = "Finland" },
                new City { Id = 14,  CityName = "Paris"  , Country = "France" },
                new City { Id = 15,  CityName = "Oslo"    ,  Country = "Norway" } ,
                new City { Id = 16,  CityName = "Helsinki"     , Country = "Finland"},

                new City { Id = 17,  CityName = "Turku"  , Country = "Finland" },
                new City { Id = 18,  CityName = "Paris"  , Country = "France" },
                new City { Id = 19,  CityName = "Oslo"    ,  Country = "Norway" } ,
                new City { Id = 20,  CityName = "Helsinki"     , Country = "Finland"}
             };
            var fincities = cities.Where(x => x.Country == "Finland");
            foreach(var _city in fincities)
            {
                Console.WriteLine(JsonSerializer.Serialize(_city));
            }
            //You can observe the order of the numbers. They are in random order.
            //This is because we have already seen in the past that when we use parallelism, we typically cannot control the order of the operations.
            //That is why AsOrdered()
            var parFincities = cities.AsParallel().AsOrdered().Where(x => x.Country == "Finland");
            Console.WriteLine("========================");
            foreach (var _city in parFincities)
            {
                Console.WriteLine(JsonSerializer.Serialize(_city));
            }

            //Creating an instance of CancellationTokenSource
            var CTS = new CancellationTokenSource();
            //Setting the time when the token is going to cancel the Parallel Operation
            CTS.CancelAfter(TimeSpan.FromMilliseconds(200));
            //Creating a Collection of integer numbers
            var numbers = Enumerable.Range(1, 20);

            //Fetching the List of Even Numbers using PLINQ
            var evenNumbers = numbers
                .AsParallel() //Parallel Processing
                .AsOrdered() //Original Order of the numbers
                .WithDegreeOfParallelism(2) //Maximum of two threads can process the data
                .WithCancellation(CTS.Token) //Cancel the operation after 200 Milliseconds
                .Where(x => x % 2 == 0) //This logic will execute in parallel
                .ToList();
            Console.WriteLine("Even Numbers Between 1 and 20");
            foreach (var number in evenNumbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine(numbers.AsParallel().Sum());
            Console.ReadKey();
        }
    }
    class City
    {
        public int Id { get; set; }

        public string CityName { get; set; }

        public string Country { get; set; }
    }
}
