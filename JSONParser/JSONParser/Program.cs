// composite pattern, interpreter pattern, strategy pattern
// https://lldcoding.com/design-lld-json-parser-machine-coding
// validates and return the element(good recursion example)
// recursion inside a loop(pretty good): try to understand the recursive pattern 


using System.Text;

public interface JsonElement
{
    Object GetValue();
}
public class JsonString: JsonElement
{
    string value;
    public JsonString(string value)
    {
       this.value = value;
    }
    public Object GetValue() => value;
}
public class JsonArray: JsonElement
{
    List<JsonElement> elements;
    public JsonArray(List<JsonElement> elements)
    {
        this.elements = elements;
    }

    public object GetValue()
    {
        return elements;
    }
}
public class JsonObject_: JsonElement
{
    public Dictionary<string, JsonElement> elements;
    public JsonObject_(Dictionary<string, JsonElement> elements)
    {
      this.elements  = elements;
    }
    public Object GetValue()
    {
        return elements;
    }
}

// like this we can have elements for boolean, number and null, we will not cover that here
public enum JsonCharacters
{
    OPEN_CURLEY_BRACE = '{',
    CLOSE_CURLY_BRACE = '}',
    OPEN_SQUARE_BRACKET = '[',
    DOUBLE_QUOTE = '"',
    CLOSE_SQUARE_BRACKET = ']',
    COLON = ':',
    COMMA = ','
}

public class JsonParsor
{
    private int index;
    private String json;

    private void SkipWhiteSpace()
    {
        while (char.IsWhiteSpace(json[index]))
        {
            index++;
        }
    }
    private void Consume(char expected)
    {
        if (json[index] == expected)
            index++;
        else
            throw new Exception($"Expected: {expected}");
    }
    public JsonElement Parse(string josn)
    {
        this.index = 0;
        this.json = josn;
        SkipWhiteSpace();
        return parseValue();
    }

    private JsonElement ParseValue()
    {
        char currentchar = json[index];
        if (currentchar == (char)JsonCharacters.OPEN_CURLEY_BRACE)
            return ParseObject();
        else if (currentchar == (char)JsonCharacters.OPEN_SQUARE_BRACKET)
            return ParseArray();
        else if (currentchar == (char)JsonCharacters.DOUBLE_QUOTE)
            return ParseString();


        //handle more conditions for number, boolean and null
        throw new Exception("Invalid JSON");

    }

    private JsonElement ParseString()
    {
        StringBuilder sb = new StringBuilder();
        Consume((char)JsonCharacters.DOUBLE_QUOTE);
        SkipWhiteSpace();



        while (json[index] != (char)JsonCharacters.DOUBLE_QUOTE)
        {
            sb.Append(json[index++]);
        }

        Consume((char)JsonCharacters.DOUBLE_QUOTE);
        return new JsonString(sb.ToString());
    }

    private JsonArray ParseArray()
    {
        List<JsonElement> elements = new();

        // Consume the opening square bracket
        Consume((char)JsonCharacters.OPEN_CURLEY_BRACE);

        //skip white space
        SkipWhiteSpace();

        // think why we are not increasing the index, because wheneven we will check
        // the condition, the index will already be increased because of consuming specialChars(JsonCharacters) and regular chars
        while (json[index] != (char)JsonCharacters.CLOSE_CURLY_BRACE) {
            JsonElement element = ParseValue();
            elements.Add(element);

            if (json[index] == (char)JsonCharacters.COMMA)
            {
                Consume((char)JsonCharacters.COMMA);
            }
        }

        Consume((char)JsonCharacters.CLOSE_SQUARE_BRACKET);
        return new JsonArray(elements);
    }

    private JsonElement ParseObject()
    {
        Dictionary<string, JsonElement> elements = new Dictionary<string, JsonElement>();

        //Consume opening bracket
        Consume((char)JsonCharacters.OPEN_CURLEY_BRACE);

        // think why we are not increasing the index, because wheneven we will check
        // the condition, the index will already be increased because of consuming specialChars(JsonCharacters) and regular chars
        while (json[index] != (char)JsonCharacters.CLOSE_CURLY_BRACE)){
            string elementkey = ParseString().GetValue().ToString();
            SkipWhiteSpace();

            Consume((char)JsonCharacters.COLON);
            SkipWhiteSpace();

            JsonElement elementvalue = ParseValue();

            elements.Add(elementkey, elementvalue);
            SkipWhiteSpace();

            if (json[index] == (char)JsonCharacters.COMMA)
            {
                Consume((char)JsonCharacters.COMMA);
                SkipWhiteSpace();
            }
        }
        Consume((char)JsonCharacters.CLOSE_CURLY_BRACE);
        return new JsonObject_(elements);
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        
    }
}