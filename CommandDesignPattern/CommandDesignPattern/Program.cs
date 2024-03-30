//CLIENT - INVOKER - COMMAND - RECEIVER
public interface Icommand
{
    public void Execute();
    public void Undo();
}

public class TurnOnACCommand: Icommand
{
    ACReceiver ac;

    public TurnOnACCommand(ACReceiver ac)
    {
        this.ac = ac;
    }
    public void Execute()
    {
        ac.TurnOn();
        Console.WriteLine("AC is on");
    }
    public void Undo()
    {
        ac.TurnOff();
        Console.WriteLine("AC is off");
    }
}

public class TurnOffACCommand : Icommand
{
    ACReceiver ac;

    public TurnOffACCommand(ACReceiver ac)
    {
        this.ac = ac;
    }
    public void Execute()
    {
        ac.TurnOff();
    }

    public void Undo()
    {
        ac.TurnOn();
    }

}

public class ACReceiver
{
    bool isACOn;
    double temp;
    public void TurnOn()
    {
        isACOn = true;
    }
    public void TurnOff()
    {
        isACOn = false;
    }
    public void setTemp(double temp)
    {
        this.temp = temp;
    }

}
public class MyRemoteInvoker
{
    public Icommand command;
    public Stack<Icommand> history;

    public MyRemoteInvoker()
    {
        history= new Stack<Icommand>();
    }

    public void SetCommand(Icommand command)
    {
        this.command = command;
    }
    public void PressButton()
    {
        command.Execute();
        history.Push(command);
    }

    public void UndoLastCommand()
    {
        if(history.Count > 0)
        {
            var command = history.Pop();
            command.Undo();
        }
    }

}
internal class Program
{
    private static void Main(string[] args)
    {
        ACReceiver ac = new ACReceiver();
        TurnOnACCommand acOn = new TurnOnACCommand(ac);

        MyRemoteInvoker Mrt= new MyRemoteInvoker();
        Mrt.SetCommand(acOn);

        Mrt.PressButton();
        Mrt.UndoLastCommand();

    }
}