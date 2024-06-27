using System.Reflection.Emit;

namespace CandyShop;

public class PaymentMethod
{
    //properties
    decimal balance { get; set; }
    //constructor

    public PaymentMethod(decimal balance)
    {
        this.balance = balance;
    }
    

    //methods

    public decimal getBalance()
    {
        return balance;
    }

    public void checkPayment(string checkNumber)
    {
        Console.WriteLine(checkNumber);
    }

    public void creditPayment(string cardNumber, string expiration, string cvv)
    {
        Console.WriteLine($"Card Number: {cardNumber} Expiration: {expiration} CVV: {cvv}");
    }
}
