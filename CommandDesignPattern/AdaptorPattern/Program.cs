//Actual - Adapter - Adaptee


public class Adapter
{
    public IConvertToPoundAdaptee poundAdaptee;
    public Adapter(IConvertToPoundAdaptee poundAdaptee)
    {
        this.poundAdaptee= poundAdaptee;
    }
    
    public double getData(double data)
    {
        return poundAdaptee.getInPound(data) * 0.45;
    }
} 

public interface IConvertToPoundAdaptee
{
    public double getInPound(double value);
}

public class ConvertToPoundAdaptee: IConvertToPoundAdaptee
{
    public double getInPound(double value) {
        return value;
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        IConvertToPoundAdaptee poundAdaptee = new ConvertToPoundAdaptee();

        Adapter adapter = new Adapter(poundAdaptee);
        Console.WriteLine(adapter.getData(750));
    }
}