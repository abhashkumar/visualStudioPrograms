using System.Security.Cryptography.X509Certificates;

public  class Program
{
    public static void Main(string[] args)
    {
        string[] s =  { "eat", "tea", "ate", "bat", "tab", "sit", "tis", "its", "", "pat", "apt", "tap" };

        Dictionary<string, List<string>> ds =  new Dictionary<string, List<string>>();
        foreach(string item in s)
        {
            /*
            var chars = item.ToCharArray();
            Array.Sort(chars);
            string temp = new String(chars);
            */

            string temp = new String(item.OrderBy(x => x).ToArray());

            if (!ds.ContainsKey(temp))
            {
                ds.Add(temp, new List<string>() { item});
            }
            else
            {
                ds[temp].Add(item);
            }
        }
        foreach(var key in ds.Keys) 
        { 
            var data = ds[key];
            Console.WriteLine("***********************");
            foreach(string item in data)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("***********************");
            int x = 3;
            double p = (x * 1.0) / 2;
            Console.WriteLine(p);
        }
 
    }
}