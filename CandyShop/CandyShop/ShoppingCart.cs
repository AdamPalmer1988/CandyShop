namespace CandyShop;

public class ShoppingCart
{
    //properties
    public List<CandyItem> shoppingCartItems { get; set; }

    //constructor

    //method
    public void AddItem(CandyItem item)
    {
        shoppingCartItems.Add(item);
    }

    public void DisplayCart()
    {
        if (shoppingCartItems.Count == 0)
        {
            Console.WriteLine("Your cart is empty.");
        }

        else 
        { 
            Console.WriteLine("Items in your cart:");
            foreach (var item in shoppingCartItems)
            {
                Console.WriteLine($"{item.Name}: ${item.Price}");
            }
        }
    }

    public decimal CalculateTotal()
    {
        decimal total = 0;
        foreach (var item in shoppingCartItems)
        {
            total += item.Price;
        }
        return total;
    }

    public void Checkout()
    {
        DisplayCart();
        if (shoppingCartItems.Count == 0)
        {
            Console.WriteLine("Nothing to checkout.");
            return;
        }

        decimal total = CalculateTotal();
        Console.WriteLine($"\nTotal: ${total:F2}");
        Console.WriteLine("Thank you for your purchase!");
        shoppingCartItems.Clear();
    }

}


