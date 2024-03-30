public interface ibasePizza
{
    public double cost();
}
public class Margarita: ibasePizza
{
    public double cost()
    {
        return 100;
    }
}

public class Vegdelight: ibasePizza
{
    public double cost() { return 75; }
}

public class ExtraCheese: ibasePizza
{
    public ibasePizza basePizza;
    public ExtraCheese(ibasePizza basePizza)
    {
        this.basePizza = basePizza;
    }
    public double cost()
    {
        return basePizza.cost()  + 20;
    }

}

public class ExtrachickenBalls : ibasePizza
{
    public ibasePizza basePizza;

    public ExtrachickenBalls(ibasePizza basePizza)
    {
        this.basePizza = basePizza;
    }

    public double cost()
    {
        return basePizza.cost() + 50;
    }
}



internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var pizza1 = new ExtrachickenBalls(new ExtrachickenBalls(new ExtraCheese(new Vegdelight())));
        Console.WriteLine(pizza1.cost());
        var pizza2 = new ExtraCheese(new Margarita());
        Console.WriteLine(pizza2.cost());
    }
}