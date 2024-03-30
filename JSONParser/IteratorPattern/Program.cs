public interface Iterator
{
    public bool HasNext();
    public Object Next();
}

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public Book(int Id, string Title)
    {
        this.Id = Id;
        this.Title = Title;
    }
}

public class BookIterator: Iterator
{
    private List<Book> books;
    private int index = 0;
    public BookIterator(List<Book> books)
    {
        this.books = books;
    }

    public bool HasNext()
    {
        return index <= books.Count - 1  ;
    }

    public object Next()
    {
        if (HasNext())
        {
            return books[index++];
        }
        return null;
    }
}

// Aggregator
public class Library
{
    List<Book> books = new List<Book>();
    
    public void AddBook(Book book) => books.Add(book);
    public Iterator GetIterator() => new BookIterator(books);
} 
internal class Program
{
    private static void Main(string[] args)
    {
        Library library = new Library();
        library.AddBook(new Book(1, "Physics"));
        library.AddBook(new Book(1, "Chemistry"));
        library.AddBook(new Book(1, "Biology"));
        library.AddBook(new Book(1, "Mathematics"));

        Iterator bookIterator = library.GetIterator();
        while (bookIterator.HasNext())
        {
            Console.WriteLine(((Book)bookIterator.Next()).Title);
        }
    }
}