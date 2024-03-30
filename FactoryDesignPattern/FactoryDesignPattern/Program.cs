using System;

namespace FactoryMethodDesignPattern
{/*
  *
Product
This is an interface for creating the objects. [here CreditCard]

ConcreteProduct
This is a class which implements the Product interface.[MoneyBack, Platinum]

Creator
This is an abstract class and declares the factory method, which returns an object of type Product.[FactoryMethod class]

ConcreteCreator
This is a class which implements the Creator class and overrides the factory method to return an instance of a ConcreteProduct.[MoneyBackFactory, ClientFactorys]
  * 
  * 
  * 
  */
    public abstract class FactoryMethod
    {
        public abstract CreditCard MakeProduct();

        //no need to use this though since MakeProduct is part of this interface only 
        public CreditCard GetProduct => this.MakeProduct();
    }
    public interface CreditCard
    {
        string GetCardType();
        int GetCreditLimit();
        int GetAnnualCharges();
    }
    public class MoneyBack : CreditCard
    {
        public int GetAnnualCharges() => 1500;

        public string GetCardType() => "MoneyBack";

        public int GetCreditLimit() => 200000;

    }
    public class Platinum : CreditCard
    {
        public int GetAnnualCharges() =>  2000;

        public string GetCardType() => "Platinum";

        public int GetCreditLimit() => 500000;
    }
    class MoneyBackFactory : FactoryMethod
    {
        public override CreditCard MakeProduct() => new MoneyBack();
    }
    class PlatinumFactory : FactoryMethod
    {
        public override CreditCard MakeProduct() => new Platinum();
    }
    class Program
    {
        static void Main(string[] args)
        {
            CreditCard cr1 = new MoneyBackFactory().GetProduct;
            //GetProduct is in FactoryMethod, which create product of the current class being called(GetProduct() => this.MakeProduct() => new MoneyBack())

            Console.WriteLine($"{cr1.GetCardType()} , {cr1.GetAnnualCharges()}, {cr1.GetCreditLimit()}");
            CreditCard cr2 = new PlatinumFactory().MakeProduct();
            Console.WriteLine($"{cr2.GetCardType()} , {cr2.GetAnnualCharges()}, {cr2.GetCreditLimit()}");
        }
    }
}
