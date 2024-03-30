interface Colleague
{
    public void PlaceBid(int amount);
    public void ReceiveNotification(int amount);
    public string GetName();
}

class Bidder : Colleague
{
    AuctionMediator auctionMediator;
    string name;
    public Bidder(string name, AuctionMediator auctionMediator)
    {
        this.name = name;
        this.auctionMediator = auctionMediator;
        auctionMediator.addBidder(this);
    }

    public string GetName()
    {
        return name;
    }

    public void PlaceBid(int amount)
    {
        auctionMediator.PlaceBid(amount, name);
    }

    public void ReceiveNotification(int amount)
    {
        Console.WriteLine($"bid placed by someone of amount ${amount} and received by {name}");
    }
}


interface AuctionMediator
{
    public void PlaceBid(int amount, string name);
    public void addBidder(Colleague bidder);
}

class Auctioner : AuctionMediator
{
    List<Colleague> bidders = new List<Colleague>();

    public void addBidder(Colleague bidder)
    {
        bidders.Add(bidder);
    }

    public void PlaceBid(int amount, string name)
    {
        bidders.Where(bidder => bidder.GetName() != name).ToList().ForEach(bidder => bidder.ReceiveNotification(amount));
    }
}


internal class Program
{
    private static void Main(string[] args)
    {
        AuctionMediator auctioner = new Auctioner();
        Bidder b1 = new Bidder("b1", auctioner);
        Bidder b2 = new Bidder("b2", auctioner);
        Bidder b3 = new Bidder("b3", auctioner);
        b1.PlaceBid(100);
    }
}