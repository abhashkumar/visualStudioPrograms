/*
  Avoid duplicate code
  Easy to maintain
  Flexible Software
  Eaxy to understand
  Reduce complexity
  Easy to test
 * 
 * Single responsibility Principal : A class should have only one reason to change or should have one responsibility
 * 
    Think of a scenerio where you have an Invoice class which has CalculateBill, PrintInvoice, and SaveToDB function 
    so if in future if you want to change the logic of anyone these function you are basically changing the due to multiple reasons
    SO its better to creater class for Calcluate, Printing and SavingToDB 

 * Open/Closed principal: Open for extension but closed for modification
 * 
  Now think of a scenerio where you have an InvoiceDao class in which there is a function SaveToDB, and this file is tested and is working
  fine in production. Suppose in future you get a scenerio where you also want to save the invoice into a file, one easy option you can think of is adding a fuction 
  SaveAsFile in the InvoiceDao class, but that breaks the principal so its better to define an interface IinvoiceDao which can have Save method, now this class 
  can be implemented by InVoiceDatabase, InvoiceFile and save method can be implemented in bothe the class, so we have extended the functionlity rather then modying it
  In future also if we have to implement something like saveToMongoDB we can implement the same interface and override the save method
 * 
 * Liskov Substitution Principal : If class B is a subtype of class A, then we should be able to replace the object of A with B without breaking the behaviour of the program,
   Subclass should extend the capability of parent class not narrow it down
   See below example

    
 * Interface Segmentation Principal: Interfaces should be such that client should not implement unnecessary function they do not need 
 
 * Dependency Inversion Principal: Class should depend on interfaces rather then concrete class
 * 
 * https://www.youtube.com/watch?v=XI7zep97c-Y&ab_channel=Concept%26%26Coding-byShrayansh
 * https://www.udemy.com/course/system_design_lld_hld/learn/lecture/41932786#overview
 * 
 */

interface Bike
{
    void TurnOnEngine();
    void Accelerate();
}

class MotorCycle : Bike
{
    bool isEngineOn;
    int speed;
    public void Accelerate()
    {
        speed += 10;
    }

    public void TurnOnEngine()
    {
        isEngineOn = true;
    }
}

//  violates Liskov substitution principal, because the moment we pass BiCycle to a program which was working with motorcycle will break it. 
class BiCycle : Bike
{
    bool isEngineOn;
    int speed;
    public void Accelerate()
    {
        // do something
    }

    public void TurnOnEngine()
    {
        throw new NotImplementedException("there is no engine");
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}