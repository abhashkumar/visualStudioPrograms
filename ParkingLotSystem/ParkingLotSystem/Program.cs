public class ParkingLotSystem
{
    public List<User> users;
    private List<Floor> floors;
    public  DashBoard dashBoard;
    private BillingSystem billingSystem;
    public ParkingLotSystem(List<User> users, List<Floor> floors, DashBoard dashBoard, BillingSystem billingSystem)
    {
        this.users = users;
        this.floors = floors;
        this.dashBoard = dashBoard;
        this.billingSystem = billingSystem;
    }
    public void AddFloor(Floor floor) => floors.Add(floor);
    public List<Floor> getFloor => floors;
    public void AddUsers(User user) => users.Add(user);
    public void AddBill(Bill bill) => billingSystem.AddBill(bill);

}

public class BillingSystem
{
    private List<Bill> bills;
    public BillingSystem(List<Bill> bills)
    {
        this.bills = bills;
    }
    public void AddBill(Bill bill) => bills.Add(bill);
}

public class DashBoard
{
    public void getInfo(List<Floor> floors)
    {
        foreach(var floor in floors)
        {
            int smallSlot = 0;
            int midSlot = 0;
            int largeSlot = 0;

            foreach(var slot in floor.GetSlots)
            {
                if (slot.isVaccent)
                {
                    if (slot.slotType == slotType.Large)
                        largeSlot += 1;
                    else if (slot.slotType == slotType.mid)
                        midSlot += 1;
                    else
                        smallSlot += 1;
                }
            }
            Console.WriteLine($"vaccency in Floor {floor.FloorNumber} small:{smallSlot} mid:{midSlot} large:{largeSlot}");
        }
    }
}

public class Bill
{
    public int billId;
    public Slot billFor;
    public DateTime startTime;
    public bool isPaid;
    public double getCost()
    {
        if (DateTime.Now >= startTime.AddHours(1))
            return billFor.GetCost();
        else
        {
            return (DateTime.Now - startTime).TotalHours * billFor.GetCost();
        }
    }
}
public class Floor
{
    public int FloorNumber;
    private List<Slot> slots;

    public Floor(int number, List<Slot> slots)
    {
        this.FloorNumber = number;
        this.slots = slots;
    }
    public bool isFloorAvailable => slots.Any(slot => slot.isVaccent);
    public void AddSlot(Slot slot) => slots.Add(slot);
    public List<Slot> GetSlots => slots;
        
}

public class Slot
{
    public int slotId;
    public slotType slotType;
    public bool isVaccent;
    public Slot(int slotId, slotType slotType, bool isVaccent)
    {
        this.slotId = slotId;
        this.slotType = slotType;
        this.isVaccent = isVaccent;
    }

    public double GetCost()
    {
        switch (slotType)
        {
            case slotType.Large:
                return 100;
            case slotType.mid:
                return 70;
            case slotType.small:
                return 50;
            default:
                return 200;
        }
    }
    public void vacateSlot()
    {
        this.isVaccent = true;
    }
}
public enum slotType
{
    small,
    mid,
    Large
}
public class User
{
    public string Id { get; set; }
    public Role role { get; set; }

    public User(string Id, Role role)
    {
        this.Id = Id;
        this.role = role;
    }
}

public enum Role
{
    Cashier,
    Guard,
    Manager
}

internal class Program
{
    private static void Main(string[] args)
    {
        var slot1 = new Slot(1, slotType.mid, true);
        var slot2 = new Slot(2, slotType.Large, true);
        var slot3 = new Slot(3, slotType.small, true);
        
        Floor floor = new Floor(1, new List<Slot> { slot1, slot2, slot3});

        var users = new List<User> { new User("1", Role.Cashier)};

        var billingSystem = new BillingSystem(new List<Bill>());
        var dashBoard = new DashBoard();

        var parkingSlot = new ParkingLotSystem(users, new List<Floor> { floor }, dashBoard, billingSystem);
        slot2.isVaccent = false;
        parkingSlot.dashBoard.getInfo(parkingSlot.getFloor);
    }
}