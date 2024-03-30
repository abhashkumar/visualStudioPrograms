//like strategy pattern 

public interface IBreathe
{
    public void Breathe();
}

public class LandBretheImpl: IBreathe
{
    public void Breathe()
    {
        Console.WriteLine("Breathing by nose");
    }
}
public class WaterBreatheImpl : IBreathe
{
    public void Breathe()
    {
        Console.WriteLine("Breathing by gill");
    }
}

public class BirdBreathe: IBreathe
{
    public void Breathe()
    {
        Console.WriteLine("Breathing by narse");
    }
}

public abstract class LivingThings
{
    public IBreathe breathe;
    public LivingThings(IBreathe breathe)
    {
        this.breathe = breathe;
    }
    public abstract void BreathingProcess();


    //We could have run like this as well
    public void BreathingProcess2()
    {
        this.breathe.Breathe();
    }
}

public class Dog : LivingThings
{
    //did not understand why initialized the breathe from the subclass and called from the subclass
    //what we could have done is to make BreathingProcess a complethe method and call breathe.Breathe(),
    //the breathe object will still be initialized by subclass constructor 
    public Dog(IBreathe breathe) : base(breathe) { }

    public override void BreathingProcess()
    {
          breathe.Breathe();
    }
}

public class Fish : LivingThings
{
    public Fish(IBreathe breathe) : base(breathe) { }

    public override void BreathingProcess()
    {
        breathe.Breathe();
    }
}

public class Crow : LivingThings
{
    public Crow(IBreathe breathe) : base(breathe) { }

    public override void BreathingProcess()
    {
        breathe.Breathe();
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        Crow cr = new Crow(new BirdBreathe());
        cr.BreathingProcess();
        cr.BreathingProcess2();
    }
}