using System;
using System.Collections.Generic;
using System.Text;

public class Gold
{
    public string Name { get; set; }
    public long Amount { get; set; }

    public Gold(long amount)
    {
        Name = "gold";
        Amount = amount;
    }
}
