using System.Data.Common;
using System.Diagnostics.Contracts;

public abstract class AnimalFactory
{
    // abstract class returning object of factory and also allowing us to create object 
    //GetAnimal takes type of animal{cat lion shark or Octopus}
    public abstract Animal GetAnimal(string type);
    public static AnimalFactory createAnimalFactory(string FactoryType)
    {
        if (FactoryType.Equals("Sea"))
            return new SeaAnimalFactory();
        else
            return new LandAnimalFactory();
    }
}
public class SeaAnimalFactory : AnimalFactory
{
    public override Animal GetAnimal(string type)
    {
        switch (type)
        {
            case "Octopus":
                return new Octopus();
            case "Shark":
                return new Shark();
            default:
                return null;
        }
    }
}
public class LandAnimalFactory : AnimalFactory
{
    public override Animal GetAnimal(string type)
    {
        switch (type)
        {
            case "Cat":
                return new Cat();
            case "Lion":
                return new Lion();
            default:
                return null;
        }
    }
}
public interface Animal
{
    public string Speak();
}
public class Cat : Animal
{
    public string Speak()
    {
        return "MEOW";
    }
}

public class Lion : Animal
{
    public string Speak()
    {
        return "ROAR";
    }

}

public class Octopus : Animal
{
    public string Speak()
    {
        return "SQAWCK";
    }
}

public class Shark : Animal
{
    public string Speak()
    {
        return "Cant Speak";
    }
}
public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}