
public abstract class Template
{
    public abstract void Verify(double amount);
    public abstract void Debit(double amount);
    public abstract double CalculateFees(double amount);

    public abstract void Credit(double amount);

    public void PerformTransaction(double amount)
    {
        Verify(amount);
        Debit(amount);
        double fee = CalculateFees(amount);
        Credit(amount - fee);
    }

}

public class PayToFriend:Template
{
    public override double CalculateFees(double amount)
    {
        return amount * 0;
    }

    public override void Credit(double amount)
    {
        Console.WriteLine($"{amount} credited to friend");
    }

    public override void Debit(double amount)
    {
        Console.WriteLine($"{amount} debited from you");
    }

    public override void Verify(double amount)
    {
        Console.WriteLine($"{amount} is ready to deduct");
    }
}

public class PayToMerchant : Template
{
    public override double CalculateFees(double amount)
    {
        return amount * 0.01;
    }

    public override void Credit(double amount)
    {
        Console.WriteLine($"{amount} credited to merchant");
    }

    public override void Debit(double amount)
    {
        Console.WriteLine($"{amount} debited from you");
    }

    public override void Verify(double amount)
    {
        Console.WriteLine($"{amount} is ready to deduct");
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        PayToFriend payToFriend = new PayToFriend();
        payToFriend.PerformTransaction(20);

        PayToMerchant payToMerchant = new PayToMerchant();
        payToMerchant.PerformTransaction(209);
    }
}