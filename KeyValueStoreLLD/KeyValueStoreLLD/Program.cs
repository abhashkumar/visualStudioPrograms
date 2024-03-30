/*
public class ValueInfo
{
    private string value;
    private Type type;
    public ValueInfo(string value, Type type)
    {
        this.value = value;
        this.type = type;
    }

    public bool IsValidType(Type type)
    {
        return type == this.type;
    }
}

public class X1: ValueInfo
{
    public X1(string s, Type type) : base(s, type) { }
}



public class KeyalueStore
{
    public Dictionary<string, Dictionary<string, ValueInfo>> store;
    public KeyalueStore()
    {
        this.store = new Dictionary<string, Dictionary<string, ValueInfo>> ();
    }

    private Type GetType(string value)
    {
        if (value[0] == '"')
        {
            return typeof(string);
        }
        else if(value[0] == 't' || value[0] == 'f'){
            return typeof(bool);
        }
        else if (value.Contains("."))
        {
            return typeof(double);
        }
        else
        {
            return typeof(int);
        }
    }
    public void Put(string Key, List<Tuple<string, string>> Values)
    {

    }
}
*/


// https://workat.tech/machine-coding/practice/design-key-value-store-6gz6cq124k65
using System.Text.Json;

public class KeyValueStore
{
    private Dictionary<string, Dictionary<string, object>> store;
    private readonly ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();
    public KeyValueStore(Dictionary<string, Dictionary<string, object>> store)
    {
        store = new Dictionary<string, Dictionary<string, object>>();
    }

    public string GetKey(string key)
    {
        try
        {
            rwLock.EnterReadLock();
            if (store.ContainsKey(key))
            {
                return JsonSerializer.Serialize(store);
            }
            return "";
        } // finally block will be executed even after a return 
        finally { rwLock.ExitReadLock(); }
    }

    public void Put(string key, List<KeyValuePair<string, object>> pairs)
    {
        try
        {
            rwLock.EnterWriteLock();
            if (store.ContainsKey(key))
            {
                var dict = store[key];
                foreach(var item in pairs)
                {
                    if (item.Value.GetType() != dict[item.Key].GetType())
                        throw new ArgumentException($"data type mismatch for {item.Key}");
                }
                foreach(var item in pairs)
                {
                    dict[item.Key] = item.Value;
                }
            }
            else
            {
                Dictionary<string, object> dict = new Dictionary<string, object>();
                foreach (var item in pairs)
                {
                    dict.Add(item.Key, item.Value);
                }
                store.Add(key, dict);
            }
        }
        finally { rwLock.ExitWriteLock(); }
       
    }

    public List<string> Search(string attributeKey, string attributeValue)
    {
        try
        {
            rwLock.EnterWriteLock();
            List<string> list = new List<string>();
            foreach (var item in store)
            {
                var key = item.Key;
                var value = item.Value;
                if (value.Any(x => x.Key == attributeKey && x.Value.ToString() == attributeKey.ToString()))
                {
                    list.Add(key);
                }
            }
            return list;
        }
        finally { rwLock.ExitWriteLock(); }
    }

    public void Delete(string key)
    {
        try
        {
            rwLock.EnterWriteLock();
            if (store.ContainsKey(key))
            {
                store.Remove(key);
            }
        }
        finally
        {
            rwLock.ExitWriteLock();
        }
    }

    public List<string> GetKeys()
    {
        try
        {
            rwLock.EnterReadLock();
            return store.Keys.ToList();
        }
        finally
        {
            rwLock.ExitReadLock();
        }

    }
    
}
internal class Program
{
    private static void Main(string[] args)
    {


        /*      
                Object x = 5;
                Object y = true;
                Object z = 6.7;
                Object r = "test";

                //typeof takes a type in argument like typeof(int), you cant write typeof(5)

                // get type will give you type of the variable
                Console.WriteLine(x.GetType());
                Console.WriteLine(y.GetType());
                Console.WriteLine(z.GetType());
                Console.WriteLine(r.GetType());
                var p = new ValueInfo("6", typeof(int));
                Console.WriteLine(p.GetType());
                var q = new X1("8", typeof(int));
                Console.WriteLine(q.GetType());
                Console.WriteLine(q is ValueInfo);*/
                Console.WriteLine("Hello, World!");
    }
}