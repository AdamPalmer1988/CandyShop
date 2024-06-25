using System;
using System.Collections.Generic;


public class CandyItem
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public CandyItem(string name, decimal price)
    {
        Name = name;
        Price = price;

    }

}