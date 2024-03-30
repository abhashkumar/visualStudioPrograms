
// state design pattern and chain of responsibility(used for logging/logger)
// https://gitlab.com/shrayansh8/interviewcodingpractise/-/blob/main/src/LowLevelDesign/DesignATM/ATM.java
// https://www.udemy.com/course/system_design_lld_hld/learn/lecture/41933106#overview

class User
{
    public string name { get; set; }
    public Card card { get; set; }
}

public class BankAccount
{
    public double accountBalance;
}

public class Card
{
    public string Id { get; set; }
    public string pin {  get; set; }
    public BankAccount linkedbankAccount { get; set; }
}

public class NoteConfiguration
{
    public int count1HundredNotes;
    public int count5HunderedNotes;
    public int count2ThousandsNotes;
    public NoteConfiguration(int count1HundredNotes, int count5HunderedNotes, int count2ThousandsNotes)
    {
        this.count5HunderedNotes = count5HunderedNotes;
        this.count1HundredNotes = count1HundredNotes;
        this.count2ThousandsNotes = count2ThousandsNotes;
    }
}

public class ATM
{
    public AtmState currentState { get; set; }

    public NoteConfiguration noteConfiguration { get; set; }

    public ATM(NoteConfiguration noteConfiguration) 
    {
        this.noteConfiguration = noteConfiguration;
    }

    public int Balance => 100 * noteConfiguration.count1HundredNotes + 500 * noteConfiguration.count5HunderedNotes + 2000 * noteConfiguration.count2ThousandsNotes;


}

// This class will contain all the operation that can only be executed when the atm is in specific state
public abstract class AtmState
{
    public virtual void InsertCard(ATM atm, Card aCard)
    {
        Console.WriteLine("OOPS Some issue occurred");
    }
    public virtual void AuthenticatePin(ATM atm, Card card, string pin)
    {
        Console.WriteLine("OOPS Some issue occurred");
    }
    public virtual void RunOperation(ATM atm, ATMOperation operation)
    {
        Console.WriteLine("OOPS Some issue occurred");
    }
    public virtual void CashWithdrawl(ATM atm,Card card, int balance)
    {
        Console.WriteLine("OOPS Some issue occurred");
    }
    public virtual void DisplayBalance(ATM atm, Card card)
    {
        Console.WriteLine("OOPS Some issue occurred");
    }
    public virtual void ReturnCard()
    {
        Console.WriteLine("OOPS Some issue occurred");
    }
    public virtual void Exit(ATM atm) 
    {
        Console.WriteLine("OOPS Some issue occurred");
    }
}

public class IdleState: AtmState
{
    public override void InsertCard(ATM atm, Card Card)
    {
        Console.WriteLine("Card inserted");
        atm.currentState = new HasCardState();
    }
}

public class HasCardState : AtmState
{
    public override void AuthenticatePin(ATM atm, Card card, string pin)
    {
       if(card != null && card.pin.Equals(pin))
       {
            Console.WriteLine("Successfully authenticated pin");
            atm.currentState = new SelectOperationState();
       }
        else
        {
            Console.WriteLine("Validation failed");
            Exit(atm);
        }
    }
    public override void Exit(ATM atm)
    {
      ReturnCard();
      atm.currentState = new IdleState();
    }
    public override void ReturnCard()
    {
        Console.WriteLine("Please collect your card");
    }
}

public enum ATMOperation
{
    DEPOSITCASH,
    CASHWITHDRAW,
    BALANCENQUIRY
}

public class SelectOperationState : AtmState
{
    public override void RunOperation(ATM atm, ATMOperation operation)
    {
        switch (operation)
        {
            case ATMOperation.DEPOSITCASH:
                Console.WriteLine("Cash deposit successful");
                break;
            case ATMOperation.CASHWITHDRAW:
                atm.currentState = new CashWithdrawingState();
                break;
            case ATMOperation.BALANCENQUIRY:
                atm.currentState = new DisplayBalanceState();
                break;
            default:
                Console.WriteLine("Oops something went wrong");
                break;
        }
    }
    public override void Exit(ATM atm)
    {
        ReturnCard();
        atm.currentState = new IdleState();
    }
    public override void ReturnCard()
    {
        Console.WriteLine("Please collect your card");
    }
}

public class DisplayBalanceState : AtmState
{
    public override void DisplayBalance(ATM atm, Card card)
    {
        Console.WriteLine($"Current Balance {card.linkedbankAccount.accountBalance}");
        Exit(atm);
    }
    public override void Exit(ATM atm)
    {
        ReturnCard();
        atm.currentState = new IdleState();
    }
    public override void ReturnCard()
    {
        Console.WriteLine("Please collect your card");
    }
}

public class CashWithdrawingState : AtmState
{
    public override void CashWithdrawl(ATM atm, Card card, int balance)
    {

        if (balance > card.linkedbankAccount.accountBalance || balance > atm.Balance)
            Exit(atm);

        CashWithDrawlProcessor processor = new TwoThousandProcessor(new FiveHundredProcessor(new OneHundredProcessor(null)));
        processor.Process(atm, balance);
        Exit(atm);
    }

    public override void Exit(ATM atm)
    {
        ReturnCard();
        atm.currentState = new IdleState();
        Console.WriteLine("Exit happens");
    }

    public override void ReturnCard()
    {
        Console.WriteLine("Please collect your card");
    }

}

public abstract class CashWithDrawlProcessor
{
    public CashWithDrawlProcessor nextProcessor;
    public CashWithDrawlProcessor(CashWithDrawlProcessor nextProcessor)
    {
        this.nextProcessor = nextProcessor;
    }
    public virtual void Process(ATM atm, int balance)
    {
        if(nextProcessor != null)
        {
            nextProcessor.Process(atm, balance);
        }
    }
}

// chane of responsibility
public class TwoThousandProcessor : CashWithDrawlProcessor
{
    public TwoThousandProcessor(CashWithDrawlProcessor processor): base(processor)
    {
        
    }
    public override void Process(ATM atm, int balance)
    {
        int notes = balance / 2000;

        if(notes > 0)
        {
            if(atm.noteConfiguration.count2ThousandsNotes >= notes)
            {
                balance -= notes * 2000;
                atm.noteConfiguration.count2ThousandsNotes -= notes;
            }
            else
            {
                balance -= atm.noteConfiguration.count2ThousandsNotes * 2000;
                atm.noteConfiguration.count2ThousandsNotes = 0;
            }
        }

        if(balance > 0)
        {
            base.Process(atm, balance);
        }

    }

}

public class FiveHundredProcessor : CashWithDrawlProcessor
{
    public FiveHundredProcessor(CashWithDrawlProcessor processor) : base(processor)
    {

    }
    public override void Process(ATM atm, int balance)
    {
        int notes = balance / 500;

        if (notes > 0)
        {
            if (atm.noteConfiguration.count5HunderedNotes >= notes)
            {
                balance -= notes * 500;
                atm.noteConfiguration.count5HunderedNotes -= notes;
            }
            else
            {
                balance -= atm.noteConfiguration.count5HunderedNotes * 500;
                atm.noteConfiguration.count5HunderedNotes = 0;
            }
        }

        if (balance > 0)
        {
            base.Process(atm, balance);
        }

    }

}

public class OneHundredProcessor : CashWithDrawlProcessor
{
    public OneHundredProcessor(CashWithDrawlProcessor processor) : base(processor)
    {

    }
    public override void Process(ATM atm, int balance)
    {
        int notes = balance / 100;

        if (notes > 0)
        {
            if (atm.noteConfiguration.count1HundredNotes >= notes)
            {
                balance -= notes * 100;
                atm.noteConfiguration.count1HundredNotes -= notes;
            }
            else
            {
                balance -= atm.noteConfiguration.count1HundredNotes * 100;
                atm.noteConfiguration.count1HundredNotes = 0;
            }
        }

        if (balance > 0)
        {
            Console.WriteLine("Something went Wrong");
        }

    }

}


internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}