using System.Threading.Tasks;
/*
 * The ContinueWith function is a method available on the task that allows executing code after the task has finished execution. 
 * In simple words it allows continuation.
 * Things to note here is that ContinueWith also returns one Task. That means you can attach ContinueWith one task returned by this method.
 * 
 * ContinueWith doesn't save any kind of state, the continuation operation is attached using ContinueWith run on the default thread scheduler in case a scheduler is not provided.

await: when encountering this keyword the state is saved and once the task on which await is done completes its execution the flow picks up the saved state data and starts the execution statement after await. 
(Note: State is having detail about executioncontext/synchronizationcontext.).

 * 
 */

public class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        int x = 14;
        if(await IsEven(x) && await IsDivisibleBy5(x))
        {
            Console.WriteLine("number is divisible by 10");
        }
        else
        {
            Console.WriteLine("not divisible by 10");
        }


        var isDivisbleBy10 = IsEven_(x).ContinueWith((t) =>
        {
            Console.WriteLine(t.Result);
            if (t.Result)
            {
                IsDivisibleBy5_(x).ContinueWith((t) =>
                {
                    Console.WriteLine(t.Result);
                    if (t.Result)
                        Console.WriteLine("IS divisible by 10");
                    else
                        Console.WriteLine("not divisble by 10");
                });
            }
            else
            {
                Console.WriteLine("not divisble by 10");
            }
                
        });

        Console.ReadKey();
    }

    public static async Task<bool> IsEven(int x)
    {
        return await Task.Run<bool>(() => x % 2 == 0);
    }

    public static async Task<bool> IsDivisibleBy5(int x)
    {
        return await Task.Run<bool>(() => x % 5 == 0);
    }

    public static  Task<bool> IsEven_(int x)
    {
        return  Task.Run<bool>(() => x % 2 == 0);
    }

    public static  Task<bool> IsDivisibleBy5_(int x)
    {
        return  Task.Run<bool>(() => x % 5 == 0);
    }

}