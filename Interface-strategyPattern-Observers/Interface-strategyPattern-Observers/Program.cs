public interface IdriveStrategy
{
    public void wayToDrive();
}

public class normalVahicleStrategy : IdriveStrategy
{
    public void wayToDrive()
    {
        Console.WriteLine("driving with default speed as normal");
    }
}

public class powerBooster: IdriveStrategy
{
    public void wayToDrive()
    {
        Console.WriteLine("driving with default speed speed as high");
    }
}

public class smallVahicleDrive: IdriveStrategy
{
    public void wayToDrive()
    {
        Console.WriteLine("driving with default speed as low");
    }
}


public class Vahicle
{
    public int countWheels;
    public int engines;
    public IdriveStrategy driveStrategy;
    public Vahicle(int countWheels, int engines, IdriveStrategy driveStrategy)
    {
        this.countWheels = countWheels;
        this.engines = engines;
        this.driveStrategy = driveStrategy;
    }
    public void wayToDrive()
    {
        Console.WriteLine($"driving with {countWheels} wheels, with {engines} engine(s)");
        driveStrategy.wayToDrive();
    }
}

public class BiCycle : Vahicle
{
    public BiCycle(int countWheels, int engines, IdriveStrategy driveStrategy) : base(countWheels, engines, driveStrategy)
    {
    }
}

public class SportVahicle : Vahicle
{
    public SportVahicle(int countWheels, int engines, IdriveStrategy driveStrategy) : base(countWheels, engines, driveStrategy)
    {
    }
}

public class NormalVahicle : Vahicle
{
    public NormalVahicle(int countWheels, int engines, IdriveStrategy driveStrategy) : base(countWheels, engines, driveStrategy)
    {
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        new BiCycle(2, 0, new smallVahicleDrive()).wayToDrive();
        new SportVahicle(4, 1, new powerBooster()).wayToDrive();
        new NormalVahicle(4, 1, new normalVahicleStrategy()).wayToDrive();
    }
}