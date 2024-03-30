
using HotChocolate;
namespace MyGraphQLServer
{

    public class Query
    {
        [GraphQLDescription("Retrieve an employee by ID")]
        public Employee GetEmployeeById(int id)
        {
            // TODO: Implement a data access layer to retrieve an employee by ID
            return new Employee
            {
                Id = id,
                FirstName = "John",
                LastName = "Doe",
                Address = "123 Main St",
                SSN = "123-45-6789",
                ZipCode = "12345"
            };
        }

        [GraphQLDescription("Retrieve a book")]
        public Book GetBook() => new Book
        {
            Title = "C# in depth.",
            Author = new Author
            {
                Name = "Jon Skeet"
            }
        };
    }

}
