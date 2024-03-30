internal class Program
{
    //delegate int add(int x, int y);
    private static void Main(string[] args)
    {
        // using anonymous function with func delegate, if you dont want to use func then define a degate outside of the class 
        Func<int, int, int> add = delegate (int x, int y)
        {
            return x + y;
        };

        Console.WriteLine(add(5 , 3));
    }
}