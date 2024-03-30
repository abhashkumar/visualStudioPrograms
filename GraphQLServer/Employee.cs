using HotChocolate;
namespace MyGraphQLServer
{

    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string SSN { get; set; }

        public string ZipCode { get; set; }
    }
    public class Book
    {
        public string Title { get; set; }

        public Author Author { get; set; }
    }

    public class Author
    {
        public string Name { get; set; }
    }


}
