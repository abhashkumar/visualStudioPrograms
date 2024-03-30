public interface iObservable
{
    public void add(iObserver observer);
    public void remove(iObserver observer);
    public void notify();
    public double getData();
    public void setData(double data);
}

public interface iObserver
{
    public void update(iObservable observable);
}


public class MobileObserver: iObserver
{
    public void update(iObservable observable)
    {
        Console.WriteLine($"message received on mobile, current data: {observable.getData()}");
    }
}

public class EmailObserver : iObserver
{
    public void update(iObservable observable)
    {
        Console.WriteLine($"message received on email, current data: {observable.getData()}");
    }
}


public class WeatherObservable : iObservable
{
    public  List<iObserver> observers;
    public double weather = 0;
    public WeatherObservable()
    {
        observers = new List<iObserver>();
    }
    public void add(iObserver observer)
    {
        observers.Add(observer);
    }

    public double getData()
    {
        return weather;  
    }

    public void notify()
    {
        observers.ForEach(observer => observer.update(this));   
    }

    public void remove(iObserver observer)
    {
        observers.Remove(observer);
    }

    public void setData(double data)
    {
        if(data != weather)
        {
            weather = data;
            notify();
        }
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        var mobileOb = new MobileObserver();
        var emailOb = new EmailObserver();
        var weatherObj = new WeatherObservable();
        weatherObj.add(mobileOb);
        weatherObj.add(emailOb);
        weatherObj.setData(30);
        weatherObj.setData(27);
        weatherObj.setData(24);
        weatherObj.setData(24);
        weatherObj.remove(mobileOb);
        weatherObj.setData(25);
    }
}