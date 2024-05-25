public class Engine
{
    public string Name { get; set; }
}

public class Vehicle
{
    public virtual int GetNumberOfWheels => 2;
    public virtual Engine engine => new Engine() { Name = "DEFAULT"};
}

public class MotoCycle: Vehicle
{

}

public class Car: Vehicle
{
    public override int GetNumberOfWheels => 4;
}

public class BiCycle: Vehicle
{
    public override Engine engine => null;
}

internal class Program
{
    private static void Main(string[] args)
    {
        List<Vehicle> list = new List<Vehicle>();
        list.Add(new Car());
        list.Add(new MotoCycle());
        list.Add(new BiCycle());
        foreach(var vahicle in list)
        {
            Console.WriteLine(vahicle.engine.Name);
        }
    }
}

// Now to fix the above issue create a call of EngineVahicle which extends Vehicle and it will have Engine class reference
// Car and Motorcycle will extend the EngineVehicle class and BiCycle will extend the vehicle, and vehicle call will not have
// the engine reference
// So you cant write vehicle.Engine.name since engine is not available in vehicle