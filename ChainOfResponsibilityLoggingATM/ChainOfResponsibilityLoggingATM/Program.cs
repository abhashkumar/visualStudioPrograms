

public enum LogLevel
{
    INFO,
    DEBUG,
    ERROR
}

public abstract class LogProcessor
{
    LogProcessor? nextLogProcessor;
    public LogProcessor(LogProcessor? nextlLogProcessor)
    {
        nextLogProcessor = nextlLogProcessor;
    }

    public virtual void Log(LogLevel logLevel, string message)
    {
        if (nextLogProcessor != null)
        {
            nextLogProcessor.Log(logLevel, message);
        }
    }
}

public class InfoLogProcess : LogProcessor
{
    public InfoLogProcess(LogProcessor? nextlLogProcessor = null) : base(nextlLogProcessor)
    {
    }
    public override void Log(LogLevel logLevel, string message)
    {
        if(logLevel <= LogLevel.INFO)
        {
            Console.WriteLine("Info:" + message);
        }
        base.Log(logLevel, message);
    }
}

public class DebugLogProcess : LogProcessor
{
    public DebugLogProcess(LogProcessor? nextlLogProcessor = null) : base(nextlLogProcessor)
    {
    }
    public override void Log(LogLevel logLevel, string message)
    {
        if (logLevel <= LogLevel.DEBUG)
        {
            Console.WriteLine("Debug:"  + message);
        }
        base.Log(logLevel, message);
    }
}


public class ErrorLogProcess : LogProcessor
{
    public ErrorLogProcess(LogProcessor? nextlLogProcessor = null) : base(nextlLogProcessor)
    {
    }
    public override void Log(LogLevel logLevel, string message)
    {
        if (logLevel <= LogLevel.ERROR)
        {
            Console.WriteLine("Error:" + message);
        }
        base.Log(logLevel, message);
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        LogProcessor logProcessor = new InfoLogProcess(new DebugLogProcess(new ErrorLogProcess()));
        logProcessor.Log(LogLevel.INFO, "Info occured");
    }
}