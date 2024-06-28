using CandyShop;

StoreFront willyWonka = new StoreFront();
ShoppingCart shoppingBasket = new ShoppingCart();
ShoppingCart completedOrders = new ShoppingCart();
PaymentMethod money = new PaymentMethod(50);
bool errorTest = true;

string keepPlaying = "Y";

Console.WriteLine("Welcome to the Candy Shop");

Console.ForegroundColor = ConsoleColor.Green;

Console.WriteLine($"You have ${money.getBalance()} to spend.");

Console.ResetColor();


while (errorTest)
{


    Console.WriteLine("\nThis is our current inventory");//should we put this in storefront?

    willyWonka.displayStoreFront();

   Console.WriteLine("\nPlease select the item number you wish to add to your shopping cart");



    string numberChoice = Console.ReadLine();
    int stringNumberChoice = int.Parse(numberChoice);

    if (stringNumberChoice < 1 || stringNumberChoice > willyWonka.stockItems.Count)
    {
        Console.WriteLine($"There are {willyWonka.stockItems.Count} items in the store front. Please select an item from 1-{willyWonka.stockItems.Count}");
    }

    else
    {
        shoppingBasket.AddItem(willyWonka.getCandyItem(stringNumberChoice - 1));
    }

    Console.WriteLine("Would you like to continue? (Y/N) ");
    keepPlaying = Console.ReadLine();   //allow input to be upper or lower?

    if (keepPlaying == "Y")
    {
        errorTest = true;
    }

    else { errorTest = false; } 
  
}

Console.WriteLine("What would you like to do next?");
Console.WriteLine("1. Display Cart");
Console.WriteLine("2. Checkout");

string userOption = Console.ReadLine();

if (userOption == "1")
{
    shoppingBasket.DisplayCart();
    Console.WriteLine("Would you like to checkout?");
    string checkoutOption = Console.ReadLine();

    if (checkoutOption == "Y")
    {
        shoppingBasket.Checkout();
    }
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


        Console.WriteLine("Please enter your 12-digit credit card number:");
        string cardNumber = Console.ReadLine();

        while (!IsValidCreditCardNumber(cardNumber))
        {
            Console.WriteLine("Invalid credit card number. Please enter a 12-digit credit card number:");
            cardNumber = Console.ReadLine();
        }

        Console.WriteLine("Please enter your 4-digit expiration date (MMYY):");
        string expirationDate = Console.ReadLine();
        while (!IsValidExpirationDate(expirationDate))
        {
            Console.WriteLine("Invalid expiration date. Please enter a 4-digit expiration date (MMYY):");
            expirationDate = Console.ReadLine();
        }

        Console.WriteLine("Please enter your 3-digit CVV:");
        string cvv = Console.ReadLine();
        while (!IsValidCVV(cvv))
        {
            Console.WriteLine("Invalid CVV. Please enter a 3-digit CVV:");
            cvv = Console.ReadLine();
        }

        Console.WriteLine("Credit card information is valid!");
        shoppingBasket.Checkout();


        static bool IsValidCreditCardNumber(string cardNumber)
        {
            return cardNumber.Length == 12 && long.TryParse(cardNumber, out _);
        }

        static bool IsValidExpirationDate(string expirationDate)
        {
            return expirationDate.Length == 4 && int.TryParse(expirationDate, out _);
        }

        static bool IsValidCVV(string cvv)
        {
            return cvv.Length == 3 && int.TryParse(cvv, out _);
        }
    }


    else if (userPaymentMethod == "Check")

    
    {
        Console.WriteLine("Please enter your 9-12 digit account number on check:");
        string accountNumber = Console.ReadLine();
        while (!IsValidAccountNumber(accountNumber))
        {
            Console.WriteLine("Invalid account number. Please enter a 9-12 digit account number:");
            accountNumber = Console.ReadLine();
        }

        Console.WriteLine("Account number is valid!");
        shoppingBasket.Checkout();
    }

    static bool IsValidAccountNumber(string accountNumber)
    {
        // Check if the account number length is between 9 and 12 and contains only digits
        return accountNumber.Length >= 9 && accountNumber.Length <= 12 && long.TryParse(accountNumber, out _);
    }

}