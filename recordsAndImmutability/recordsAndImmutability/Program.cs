//https://www.daveabrock.com/2020/11/02/csharp-9-records-immutable-default/

using System;
using System.Text.Json;

namespace recordsAndImmutability
{
    public class Program
    {
        static void Main(string[] args)
        {
            UserName user1 = new UserName { firstName = "Abhash", lastName = "kumar", Age = 30 };
            UserName user2 = user1 with { firstName = "Aditya" };
            Console.WriteLine(JsonSerializer.Serialize(user1));
            Console.WriteLine(JsonSerializer.Serialize(user2));

            //This will throw error init property can only be initialized once and cant be modified
            //user1.lastName = "choudhary";

            //equality works
            Console.WriteLine(user1 == user2);

            // Creating a person record
            Person person = new Person("John", "Doe", 30);

            // Destructuring the person record into individual variables
            var (firstName, lastName, age) = person;

            // Output the deconstructed values
            Console.WriteLine($"First Name: {firstName}");
            Console.WriteLine($"Last Name: {lastName}");
            Console.WriteLine($"Age: {age}");
            user1.Age = 30;
            user1.Age = 35;
            user1.Age = 35;
        }
    }

    //positional syntax, properties are immutable by default, no need init
    record Person(string FirstName, string LastName, int Age);

    //Nominal syntax, properties will be immutable only when you apply init, here age is mutable
    public record UserName
    {
        public string firstName { get; init; }
        public string lastName { get; init; }

        public int Age { get; set; }
    }
}
