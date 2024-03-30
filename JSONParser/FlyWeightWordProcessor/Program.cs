public interface ILetter
{
    public void display(int x, int y);
}

public class Letter: ILetter
{
    char character;
    string font;
    int fontSize;
    public Letter(char character, string font, int fontSize)
    {
        this.font = font;
        this.fontSize = fontSize;
        this.character = character;
    }
    public void display(int x, int y)
    {
        Console.WriteLine($"{character} displayed at coordinate {x} and {y}");
    }
}

public class LetterFactory
{
    public Dictionary<char, ILetter>  cache = new Dictionary<char, ILetter>();

    public ILetter GetLetter(char key)
    {
        if (cache.ContainsKey(key))
            return cache[key];
        else
        {
            cache.Add(key, new Letter(key,"calibari", 11));
            return cache[key];
        }
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        LetterFactory letterFactory = new LetterFactory();
        ILetter letter = letterFactory.GetLetter('t');
        letter.display(0, 0);

        ILetter eletter = letterFactory.GetLetter('e');
        eletter.display(0, 1);


        ILetter sletter = letterFactory.GetLetter('s');
        sletter.display(0, 2);

        ILetter tletter = letterFactory.GetLetter('t');
        tletter.display(0, 0);
    }
}