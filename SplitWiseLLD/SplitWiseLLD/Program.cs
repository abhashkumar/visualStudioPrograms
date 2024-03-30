// https://workat.tech/machine-coding/editorial/how-to-design-splitwise-machine-coding-ayvnfo1tfst6
// you need to implement the data model properly, find the mapping between entities that is cardinality

public class User
{
    // just user info
    private String id;
    private String name;
    private String email;
    private String phone;

    public User(String id, String name, String email, String phone)
    {
        this.id = id;
        this.name = name;
        this.email = email;
        this.phone = phone;
    }

    public String getId()
    {
        return id;
    }

    public void setId(String id)
    {
        this.id = id;
    }

    public String getName()
    {
        return name;
    }

    public void setName(String name)
    {
        this.name = name;
    }

    public String getEmail()
    {
        return email;
    }

    public void setEmail(String email)
    {
        this.email = email;
    }

    public String getPhone()
    {
        return phone;
    }

    public void setPhone(String phone)
    {
        this.phone = phone;
    }
}

public abstract class Split
{
    // strategy pattern important class
    // split will happen, paid to whom and how much paid is going to be same for all kind of split strategy
    private User user; // paid to, paid by info is specific to expense
    private double amount;

    public Split(User user)
    {
        this.user = user;
    }

    public User getUser()
    {
        return user;
    }

    public void setUser(User user)
    {
        this.user = user;
    }

    public double getAmount()
    {
        return amount;
    }

    public void setAmount(double amount)
    {
        this.amount = amount;
    }
}

public class EqualSplit: Split
{
    // Spliting equally whim whom 
    public EqualSplit(User user): base(user) { }
}

public class ExactSplit: Split
{

    // spliting based on the amount whom(paid to)
    public ExactSplit(User user, double amount):base(user)
    {
        setAmount(amount);
    }
}

public class PercentSplit : Split
{
    double percent;

    // spliting based in percentage with whom(paid to)
    public PercentSplit(User user, double percent): base(user)
    {
        this.percent = percent;
    }
    public double getPercent()
    {
        return percent;
    }

    public void setPercent(double percent)
    {
        this.percent = percent;
    }
}

public class ExpenseMetadata
{
    // just meta data info for the expense
    private String name;
    private String imgUrl;
    private String notes;

    public ExpenseMetadata(String name, String imgUrl, String notes)
    {
        this.name = name;
        this.imgUrl = imgUrl;
        this.notes = notes;
    }

    public String getName()
    {
        return name;
    }

    public void setName(String name)
    {
        this.name = name;
    }

    public String getImgUrl()
    {
        return imgUrl;
    }

    public void setImgUrl(String imgUrl)
    {
        this.imgUrl = imgUrl;
    }

    public String getNotes()
    {
        return notes;
    }

    public void setNotes(String notes)
    {
        this.notes = notes;
    }
}

public abstract class Expense
{
    // one expanse can consist of mutiple specific kind of splits, so suppose one expense you have done for four friends, there will be four splits for this expense
    // factory pattern > this will be the base class for specific kind of expense, like the expense is going to split equally etc, the sub classes will have info on 
    // validating the kind of split
    private String id;

    // amount for that expense
    private double amount;

    // one expense will have one payer  paid by and multiple payto with specific splitting strategy that info will be stored in List<split>
    private User paidBy;
    private List<Split> splits;
    private ExpenseMetadata metadata;

    public Expense(double amount, User paidBy, List<Split> splits, ExpenseMetadata metadata)
    {
        this.amount = amount;
        this.paidBy = paidBy;
        this.splits = splits;
        this.metadata = metadata;
    }

    public String getId()
    {
        return id;
    }

    public void setId(String id)
    {
        this.id = id;
    }

    public double getAmount()
    {
        return amount;
    }

    public void setAmount(double amount)
    {
        this.amount = amount;
    }

    public User getPaidBy()
    {
        return paidBy;
    }

    public void setPaidBy(User paidBy)
    {
        this.paidBy = paidBy;
    }

    public List<Split> getSplits()
    {
        return splits;
    }

    public void setSplits(List<Split> splits)
    {
        this.splits = splits;
    }

    public ExpenseMetadata getMetadata()
    {
        return metadata;
    }

    public void setMetadata(ExpenseMetadata metadata)
    {
        this.metadata = metadata;
    }

    public abstract bool validate();
}

public class EqualExpense: Expense
{
    // we could have saved memory here though
    public EqualExpense(double amount, User paidBy, List<Split> splits, ExpenseMetadata expenseMetadata): base(amount, paidBy, splits, expenseMetadata)
    {
    
    }

    // so the strategy will be of equal split at this point
    public override bool validate()
    {
        foreach (Split split in getSplits()) 
        {
            if (!(split is EqualSplit)) {
                return false;
            }
        }
        return true;
    }
}

public class ExactExpense : Expense
{
    public ExactExpense(double amount, User paidBy, List<Split> splits, ExpenseMetadata expenseMetadata): base(amount, paidBy, splits, expenseMetadata)
    {
    
    }

    
    public override bool validate()
    {
        foreach (Split split in getSplits()) {
            if (!(split is ExactSplit)) {
                return false;
            }
        }

        //in this scenerio the sum total should be same as paid amount
        double totalAmount = getAmount();
        double sumSplitAmount = 0;
        foreach(Split split in getSplits())
        {
            ExactSplit exactSplit = (ExactSplit)split;
            sumSplitAmount += exactSplit.getAmount();
        }

        if (totalAmount != sumSplitAmount)
        {
            return false;
        }

        return true;
    }
}

public class PercentExpense: Expense
{
    public PercentExpense(double amount, User paidBy, List<Split> splits, ExpenseMetadata expenseMetadata):base(amount, paidBy, splits, expenseMetadata)
    {
    
    }

    public override bool validate()
    {
        foreach (Split split in getSplits()) {
            if (!(split is  PercentSplit)) {
                return false;
            }
        }

        double totalPercent = 100;
        double sumSplitPercent = 0;
        foreach (Split split in getSplits())
        {
        PercentSplit exactSplit = (PercentSplit)split;
        sumSplitPercent += exactSplit.getPercent();
        }

        if (totalPercent != sumSplitPercent)
        {
        return false;
        }

        return true;
    }
}

public enum ExpenseType
{
    EQUAL,
    EXACT,
    PERCENT
}

public class ExpenseService
{
    public static Expense createExpense(ExpenseType expenseType, double amount, User paidBy, List<Split> splits, ExpenseMetadata expenseMetadata)
    {
        switch (expenseType)
        {
            case ExpenseType.EXACT:
                return new ExactExpense(amount, paidBy, splits, expenseMetadata);
            case ExpenseType.PERCENT:
                foreach (Split split in splits)
                {
                    PercentSplit percentSplit = (PercentSplit)split;
                    split.setAmount((amount * percentSplit.getPercent()) / 100.0);
                }
                return new PercentExpense(amount, paidBy, splits, expenseMetadata);
            case ExpenseType.EQUAL:
                int totalSplits = splits.Count;
                double splitAmount = ((double)Math.Round(amount * 100 / totalSplits)) / 100.0;
                foreach(Split split in splits)
                {
                    split.setAmount(splitAmount);
                }
                splits[0].setAmount(splitAmount + (amount - splitAmount * totalSplits));
                return new EqualExpense(amount, paidBy, splits, expenseMetadata);
            default:
                return null;
        }
    }
}

public class ExpenseManager
{
    // important class
    public List<Expense> expenses;
    public Dictionary<String, User> userMap;
    public Dictionary<String, Dictionary<String, Double>> balanceSheet;

    public ExpenseManager()
    {
        // will have list of expense: now you got it, Expanse manager have list of expenses and each expense will gave list of splits
        expenses = new List<Expense>();

        // just a user map, key is userId and value in userobject
        userMap = new Dictionary<String, User>();

        // storing all the info transaction like debit and credit
        // so that means suppose if x -> y(x paid y z amount)
        // there will be 2 entries in the balancesheet(x, (y, z)) and (y, (x, -z)) 
        balanceSheet = new Dictionary<String, Dictionary<String, Double>>();
    }

    public void addUser(User user)
    {
        userMap.Add(user.getId(), user);
        balanceSheet.Add(user.getId(), new Dictionary<String, Double>());
    }

    public void addExpense(ExpenseType expenseType, double amount, String paidBy, List<Split> splits, ExpenseMetadata expenseMetadata)
    {
        Expense expense = ExpenseService.createExpense(expenseType, amount, userMap[paidBy], splits, expenseMetadata);
        expenses.Add(expense);
        
        foreach (Split split in expense.getSplits())
        {
            String paidTo = split.getUser().getId();
            Dictionary<String, Double> balances = balanceSheet[paidBy];
            
            if (!balances.ContainsKey(paidTo))
            {
                balances.Add(paidTo, 0.0);
            }
            // x->y [+zamount]
            balances[paidTo] = balances[paidTo] + split.getAmount();

            
            // y-> x [-zamount]
            balances = balanceSheet[paidTo];
            if (!balances.ContainsKey(paidBy))
            {
                balances.Add(paidBy, 0.0);
            }
            balances[paidBy] = balances[paidBy] - split.getAmount();
        }
    }

    public void showBalance(String userId)
    {
        bool isEmpty = true;
        foreach (KeyValuePair<String, Double> userBalance in balanceSheet[userId])
        {
            if (userBalance.Value != 0)
            {
                isEmpty = false;
                printBalance(userId, userBalance.Key, userBalance.Value);
            }
        }

        if (isEmpty)
        {
            Console.WriteLine("No balances");
        }
    }

    public void showBalances()
    {
        bool isEmpty = true;
        foreach (KeyValuePair<String, Dictionary<String, Double>> allBalances in balanceSheet)
        {
            foreach (KeyValuePair<String, Double> userBalance in allBalances.Value)
            {
                if (userBalance.Value > 0)
                {
                    isEmpty = false;
                    printBalance(allBalances.Key, userBalance.Key, userBalance.Value);
                }
            }
        }

        if (isEmpty)
        {
            Console.WriteLine("No balances");
        }
    }

    private void printBalance(String user1, String user2, double amount)
    {
        String user1Name = userMap[user1].getName();
        String user2Name = userMap[user2].getName();
        if (amount < 0)
        {
            Console.WriteLine(user1Name + " owes " + user2Name + ": " + Math.Abs(amount));
        }
        else if (amount > 0)
        {
            Console.WriteLine(user2Name + " owes " + user1Name + ": " + Math.Abs(amount));
        }
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        ExpenseManager expenseManager = new ExpenseManager();

        expenseManager.addUser(new User("u1", "User1", "gaurav@workat.tech", "9876543210"));
        expenseManager.addUser(new User("u2", "User2", "sagar@workat.tech", "9876543210"));
        expenseManager.addUser(new User("u3", "User3", "hi@workat.tech", "9876543210"));
        expenseManager.addUser(new User("u4", "User4", "mock-interviews@workat.tech", "9876543210"));

        // O -> command type(expense or show) 1 paid by 2 amount 3 no of users 4 + noOfUsers expense type

        while (true)
        {
            var line = Console.ReadLine();
            if (line == null)
                continue;

            string[] commands = line.Split(" ");
            string commandType = commands[0];

            switch (commandType)
            {
                case "SHOW":
                    if (commands.Length == 1)
                    {
                        expenseManager.showBalances();
                    }
                    else
                    {
                        expenseManager.showBalance(commands[1]);
                    }
                    break;
                case "EXPENSE":
                    string paidBy = commands[1];
                    double amount = double.Parse(commands[2]);
                    int noOfUsers = int.Parse(commands[3]);
                    string expenseType = commands[4 + noOfUsers];
                    List<Split> splits = new List<Split>();
                    switch (expenseType)
                    {
                        case "EQUAL":
                            for (int i = 0; i < noOfUsers; i++)
                            {
                                splits.Add(new EqualSplit(expenseManager.userMap[commands[4 + i]]));
                            }
                            expenseManager.addExpense(ExpenseType.EQUAL, amount, paidBy, splits, null);
                            break;
                        case "EXACT":
                            for (int i = 0; i < noOfUsers; i++)
                            {
                                splits.Add(new ExactSplit(expenseManager.userMap[commands[4 + i]], double.Parse(commands[5 + noOfUsers + i])));
                            }
                            expenseManager.addExpense(ExpenseType.EXACT, amount, paidBy, splits, null);
                            break;
                        case "PERCENT":
                            for (int i = 0; i < noOfUsers; i++)
                            {
                                splits.Add(new PercentSplit(expenseManager.userMap[commands[4 + i]], double.Parse(commands[5 + noOfUsers + i])));
                            }
                            expenseManager.addExpense(ExpenseType.PERCENT, amount, paidBy, splits, null);
                            break;
                    }
                    break;
            }
        }

    }
}