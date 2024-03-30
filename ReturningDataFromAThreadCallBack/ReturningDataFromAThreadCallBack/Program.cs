public delegate void returnDataCallBack(int num);
public class NumberHelper
{
    private int _number;

    private  returnDataCallBack _callback;
    public NumberHelper(int number, returnDataCallBack callback)
    {
        _number = number;
        _callback = callback;
    }

    public void calculate ()
    {
        int result = _number + 10;
        if (_callback != null)
        {
            _callback(result);
        }
    }

}




public  class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        // passing a callback
        NumberHelper helper = new NumberHelper(85, (result) =>
        {
            Console.WriteLine(result);
        });

        Thread th = new Thread(() => helper.calculate());
        th.Start();
        Console.ReadKey();
    }
}