namespace CandyShop;

public class ShoppingCart
{
    public List<CandyItem> Items { get; set; }

    public ShoppingCart() 
    {
        Items = new List<CandyItem>();
    }

    public void AddItem(CandyItem item)
    {
        Items.Add(item);    
        Console.WriteLine($"{item.Name} added to the cart.");
    }

    public void DisplayCart()
    {
        if (Items.Count == 0)
        {
            Console.WriteLine("\nYour cart is empty.");
            return;
        }

        Console.WriteLine("\nItems in your cart:");
        foreach (var item in Items)
        {
            Console.WriteLine($"- {item.Name}: ${item.Price} ${item.Quantity}");
        }
    }

    public decimal CalculateTotal()
    {
        decimal total = 0;
        foreach (var item in Items) 
        {
            total += item.Price;
        }
        return total;
    }

    public void Checkout()
    {
        DisplayCart();
        if (Items.Count == 0) 
        {
            Console.WriteLine("Nothing to checkout.");
            return;
        }

        decimal total = CalculateTotal();
        Console.WriteLine($"\nTotal: ${total:F2}");
        Console.WriteLine("Thank you for your purchase!");
        Items.Clear();
    }
}

/*
static void Main(string[] args)
{
    ShoppingCart cart = new ShoppingCart();
    List<CandyItem> candyStore = new List<CandyItem>
    {
        new CandyItem("Tootsie Rolls", 0.05m),
        new CandyItem("Blow Pops", 0.25m),
        new CandyItem("Jaw Breaker", 1.00m),
        new CandyItem("Laffy Taffy", 0.10m),
        new CandyItem("Pixie Stix", 0.05m),
        new CandyItem("Candy Bars", 2.00m),
        new CandyItem("Licorice", 2.50m),
        new CandyItem("Nerds", 0.10m),
        new CandyItem("Pop Rocks", 0.75m),
        new CandyItem("Gum", 0.10m),
        new CandyItem("M&Ms", 2.00m),
        new CandyItem("Skittles", 2.00m)
    };

    while (true)
    {
        Console.WriteLine("\nCandy Store Menu: ");
        for (int i = 0; i < candyStore.Count; i++)
        {
            Console.WriteLine($"{i = 1}. {candyStore[i].Name} - ${candyStore[i].Price:F2} each");
        }
        Console.WriteLine("5. View Cart");
        Console.WriteLine("6. Checkout");
        Console.WriteLine("7. Exit");
    }
}
*/