namespace CandyShop;

public class ShoppingCart
{
    //properties
    public List<CandyItem> shoppingCartItems { get; set; } = new List<CandyItem>();   

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
            var itemCounts = shoppingCartItems.GroupBy(item => item).Select(group => new {Candy=group.Key,Count=group.Count()});
            foreach (var item in itemCounts)
            {
                Console.WriteLine($"{item.Candy.Name}: ${item.Candy.Price} Amount: {item.Count}");
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
        }

        decimal total = CalculateTotal();
        Console.WriteLine($"\nTotal: ${total:F2}");
        Console.WriteLine("Thank you for your purchase!");
    }

}


