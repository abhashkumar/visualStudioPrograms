
interface EmployeeDao
{
    public void create(string client, string data);
    public void delete(string client, string data);
    public void update(string client, string data);
}

class Employee : EmployeeDao
{
    public void create(string client, string data)
    {
        Console.WriteLine("Data got created");
    }

    public void delete(string client, string data)
    {
        Console.WriteLine("Data got deleted");
    }

    public void update(string client, string data)
    {
        Console.WriteLine("Data got updated");
    }
}

class EmployeeProxy : EmployeeDao
{
    EmployeeDao employee;
    public EmployeeProxy(EmployeeDao employee)
    {
        this.employee = employee;
    }
    public void create(string client, string data)
    {
        if (client.Equals("ADMIN"))
        {
            employee.create(client, data);
        }
        else
        {
            throw new NotImplementedException();
        }
        
    }

    public void delete(string client, string data)
    {
        if (client.Equals("ADMIN"))
        {
            employee.delete(client, data);
        }
        else
        {
            throw new NotImplementedException();
        }
    }

    public void update(string client, string data)
    {
        if (client.Equals("ADMIN"))
        {
            employee.update(client, data);
        }
        else
        {
            throw new NotImplementedException();
        }
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        EmployeeDao employee = new Employee();
        EmployeeProxy empProxy = new EmployeeProxy(employee);

        empProxy.create("USER", "test");
    }
}