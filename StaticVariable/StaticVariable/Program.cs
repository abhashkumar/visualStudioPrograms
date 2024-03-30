using system.Collections.Generic;
public class Program
{
    int p = 10;
    static int q = 5;
    public static void Main()
    {
        /*
        String line;
        line = Console.ReadLine();
        int N = Convert.ToInt32(line);
        line = Console.ReadLine();
        char[] ch = new char[N];
        ch = line.Split().Select(str => char.Parse(str)).ToArray();

        String out_ = solve(N, ch);
        Console.Out.WriteLine(out_);
        */
        Program pr = new Program();
        // you cant use this here this cant be used in static scope and static function
        Console.WriteLine(pr.p);

        // This is wrong cant do, can be called by the clas name only
        //Console.WriteLine(pr.q);
        Console.WriteLine(Program.q);


        string[] arr = { "(())", "adsdasdasd", "0099(())", ")(adsdasd", "()dasdasd" };
        


        foreach (var item in arr)
        {
            Stack<char> s = new Stack<char>();
            

        }




    }

    static String solve(int N, char[] ch)
    {
        // Write your code here
        String result = string.Join("", ch);

        return result;
    }
}