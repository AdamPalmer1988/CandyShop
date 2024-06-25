namespace CandyShop;

public class StoreFront
{
    public List<CandyItem> stockItems { get; set; } = new List<CandyItem>();    

    //constructor
    public StoreFront()
    {
        CandyItem tootsieRoll = new CandyItem("Tootsie Roll", 0.05m);
        CandyItem blowPops = new CandyItem("Blow Pops", 0.25m);
        CandyItem jawBreaker = new CandyItem("Jaw Breaker", 1.00m);
        CandyItem laffyTaffy = new CandyItem("Laffy Taffy", 0.10m);
        CandyItem pixieStix = new CandyItem("Pixie Stix", 0.05m);
        CandyItem candyBar = new CandyItem("Candy Bar", 2.00m);
        CandyItem licorice = new CandyItem("Licorice", 2.50m);
        CandyItem nerds = new CandyItem("Nerds", 0.1m);
        CandyItem popRocks = new CandyItem("Pop Rocks", 0.75m);
        CandyItem gum = new CandyItem("Gum", 0.1m);
        CandyItem mANDms = new CandyItem("M&Ms", 2.00m);
        CandyItem skittles = new CandyItem("Skittles", 2.00m);

        stockItems.Add(tootsieRoll);
        stockItems.Add(blowPops);
        stockItems.Add(jawBreaker);
        stockItems.Add(laffyTaffy);
        stockItems.Add(pixieStix);
        stockItems.Add(licorice);
        stockItems.Add(nerds);
        stockItems.Add(popRocks);
        stockItems.Add(gum);
        stockItems.Add(mANDms);
        stockItems.Add(skittles);
        stockItems.Add(candyBar);

    }

    public void displayStoreFront()
    {
            if (stockItems.Count == 0)
            {
                Console.WriteLine("We are sold out!");
            }

            else
            {
            int counter = 1;
                Console.WriteLine("Items in your storefront:");
                foreach (var item in stockItems)
                {
                    Console.WriteLine($"{counter}. {item.Name}: Price: ${item.Price}");
                    counter++;
                }
            }
    }

}
