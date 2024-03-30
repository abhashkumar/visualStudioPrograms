//composite design pattern is used where you need to implement a tree like structure like a file system 
// or nested JSON 
// or a expression evaluation 6 * (5 + 7)
// difference between interpreter and this is in interpreter 

using System.Linq.Expressions;

public interface IExpression
{
    public int Evaluate();
}

public class NumberExpression : IExpression
{
    int number;
    public NumberExpression(int num)
    {
        number = num;
    }
    public int Evaluate() => number;
}
public enum Operator{
    ADD,
    SUB,
    MUL,
    DIV,
    MOD,
}
public class OperationExpression : IExpression
{
    IExpression left;
    IExpression right;
    Operator op;
    public OperationExpression(IExpression left, IExpression right, Operator op)
    {
        this.left = left;
        this.right = right;
        this.op = op;

    }
    public int Evaluate()
    {
        switch (op)
        {
            case Operator.ADD:
                    return left.Evaluate() + right.Evaluate();
            case Operator.MUL:
                return left.Evaluate() * right.Evaluate();
            case Operator.DIV:
                return left.Evaluate() / right.Evaluate();
            case Operator.MOD:
                return left.Evaluate() % right.Evaluate();
            default:
                return 0;
        }
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        var left = new NumberExpression(6);
        var right = new OperationExpression(new NumberExpression(5), new NumberExpression(7), Operator.ADD);
        IExpression exp = new OperationExpression(left, right, Operator.MUL);
        int val = exp.Evaluate();
        Console.WriteLine(val);
    }
}