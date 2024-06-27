using CandyShop;

StoreFront willyWonka = new StoreFront();
ShoppingCart shoppingBasket = new ShoppingCart();
ShoppingCart completedOrders = new ShoppingCart();
PaymentMethod money = new PaymentMethod(50);
bool errorTest = true;


while (errorTest)
{
    string keepPlaying = "Y";

    Console.WriteLine("Welcome to the Candy Shop");
    Console.WriteLine($"You have ${money.getBalance()} to spend.");
    Console.WriteLine("This is our current inventory");

    willyWonka.displayStoreFront();

    Console.WriteLine("Please select the item number you wish to add to your shopping cart");

    string numberChoice = Console.ReadLine();
    int stringNumberChoice = int.Parse(numberChoice);

 /*
    Console.WriteLine("How many would you like to buy?");
    string quantityChoice = Console.ReadLine();
    int stringQuantityChoice = int.Parse(quantityChoice);
*/

    if (stringNumberChoice < 1 || stringNumberChoice > willyWonka.stockItems.Count)
    {
        Console.WriteLine($"There are {willyWonka.stockItems.Count} items in the store front. Please select an item from 1-{willyWonka.stockItems.Count}");
    }

    else
    {
        shoppingBasket.AddItem(willyWonka.getCandyItem(stringNumberChoice - 1));
    }

    Console.WriteLine("Would you like to continue? Y/N");
    keepPlaying = Console.ReadLine();

    if (keepPlaying == "Y")
    {
        errorTest = true;
    }

    else { errorTest = false; }
  
}

Console.WriteLine("What would you like to do next?");
Console.WriteLine("1. Display Cart");
Console.WriteLine("2. Checkout");
//Console.WriteLine("3. Put Items Back");

string userOption = Console.ReadLine();

if (userOption == "1")
{
    shoppingBasket.DisplayCart();
}

else if (userOption == "2") //maybe switch case 
{

    Console.WriteLine("Would you like to use Cash, Credit, or Check?");
    string userPaymentMethod = Console.ReadLine();

    if (userPaymentMethod == "Cash")
    {
        decimal change = money.getBalance() - shoppingBasket.CalculateTotal(); //What if not enough money handed over?
        Console.WriteLine($"Thank you! You have ${change} left");
        shoppingBasket.Checkout();
    }

    else if (userPaymentMethod == "Credit")
    {
        Console.WriteLine("Please enter your 12 digit credit card number:"); //What if incorrect credit card number
        string creditCardNumber = Console.ReadLine();

        Console.WriteLine("Please enter your 4 digit expiration date. In example, if your expiration date is March 2024" +
            "you would enter 0324"); //In the past? Not 4 digits?
        string expirationDate = Console.ReadLine();

        Console.WriteLine("Please enter your 3 digit cvv found on the back of your card."); //What if its not 3 digits
        string cvv = Console.ReadLine();

        money.creditPayment(creditCardNumber, expirationDate, cvv);
        shoppingBasket.Checkout();
    }

    else if (userPaymentMethod == "Check")
    {
        Console.WriteLine("Please enter your check number:");
        string checkNumber = Console.ReadLine();
        money.checkPayment(checkNumber);
        shoppingBasket.Checkout();
    }

}