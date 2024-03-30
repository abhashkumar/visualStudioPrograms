//Originator(object which state we want to store) , Memento(properties of object which we want to keep track of)
//caretaker(keeps a stack of Memento to undo the functionlity)
using System.Text.Json;

public class Originator
{
    public int width;
    public int height;
    public Originator(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public void SetHeight(int height) => this.height = height;
    public void SetWidth(int width) => this.width = width;

    public int GetHeight() => this.height;
    public int GetWidth() => this.width;

    public Memento SetState() => new Memento(width, height);
    public void Restore(Memento? stateToRestore)
    {
        if(stateToRestore != null)
        {
            this.height = stateToRestore.height;
            this.width = stateToRestore.width;
        }
    }
}

public class Memento
{
    public int width;  
    public int height;
    public Memento(int width, int height)
    {
        this.width = width;
        this.height = height;
    }
}

public class CareTaker
{
    Stack<Memento> history = new Stack<Memento>();
    public void AddMemento(Memento memento) => history.Push(memento);
    public Memento? Undo() => history?.Pop();
}

internal class Program
{
    private static void Main(string[] args)
    {
        CareTaker careTaker = new();

        Originator obj = new(5, 7);
        careTaker.AddMemento(obj.SetState());

        obj.SetHeight(15);
        obj.SetWidth(17);

        careTaker.AddMemento(obj.SetState());

        obj.SetHeight(10);

        Console.WriteLine($"Before Restore height {obj.GetHeight()}");

        var stateToReStore = careTaker.Undo();
        obj.Restore(stateToReStore);
        Console.WriteLine($"After Restore height {obj.GetHeight()}");
    }
}