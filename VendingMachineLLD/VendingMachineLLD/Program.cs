//https://lldcoding.com/design-lld-a-vending-machine-machine-coding
// payement classe :> coin payment, card payment etc
// paymentProcessor: addPayment, cancelTransaction, ProcessPayment, getBalance
// Vending Machine: ItemDatabase, Dispense , validateTransaction, Complete Transaction. storeTransaction
// ItemDatbase: Dictionary<string, Item> items, add items, getItem
// Item: ItemCount , unitPrice
// Display: Display price, display message, Display balance


/*
 * 
 * What is Vending Machine ? A vending machine is an automated machine that provides items such as snacks, 
 * beverages, cigarettes, and lottery tickets to consumers after cash, a credit card, or other forms of payment are inserted into the machine or otherwise made.
 * 
 */

/*
 * select a product_validate product availability, insert payment method_diaplay balance with the help of balance processor,complete transaction 
*/

// https://www.udemy.com/course/system_design_lld_hld/learn/lecture/41932960#overview
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}