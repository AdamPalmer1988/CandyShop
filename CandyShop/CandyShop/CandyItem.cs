using System;
using System.Collections.Generic;


public class CandyItem
{


    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public CandyItem(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

}