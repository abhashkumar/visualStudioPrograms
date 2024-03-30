public class Context
{
    Dictionary<string, int> Map = new Dictionary<string, int>();
    public void Put(string key, int value) => Map.Add(key, value);
    public int Get(string key) => Map[key];
}

public interface AbstractExpression
{
    public int Interpret(Context context);
}

public class NumberTerminalExpression : AbstractExpression
{
    string stringVal;
    public NumberTerminalExpression(string stringVal)
    {
        this.stringVal = stringVal;
    }

    public int Interpret(Context context)
    {
        return context.Get(stringVal);
    }
}

public class BinaryNonTerminalExpression : AbstractExpression
{
    AbstractExpression leftExpression;
    AbstractExpression rightExpression;
    char op;

    public BinaryNonTerminalExpression(AbstractExpression leftExpression, AbstractExpression rightExpression, char op)
    {
        this.leftExpression = leftExpression;
        this.rightExpression = rightExpression;
        this.op = op;
    }
    public int Interpret(Context context)
    {
        switch (this.op)
        {
            case '+':
                return leftExpression.Interpret(context) + rightExpression.Interpret(context);
            case '*':
                return leftExpression.Interpret(context) * rightExpression.Interpret(context);
            default:
                return 0;
        }
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        //((a*b) + (c*d))
        Context context = new Context();
        context.Put("a", 1);
        context.Put("b", 2);
        context.Put("c", 3);
        context.Put("d", 4);

        AbstractExpression expression = new BinaryNonTerminalExpression(
             new BinaryNonTerminalExpression(
                 new NumberTerminalExpression("a"), new NumberTerminalExpression("b"), '*'
             ),
             new BinaryNonTerminalExpression(
                 new NumberTerminalExpression("c"), new NumberTerminalExpression("d"), '*'
             ), '+'
         );
        int value = expression.Interpret(context);
        Console.WriteLine(value);
    }
}